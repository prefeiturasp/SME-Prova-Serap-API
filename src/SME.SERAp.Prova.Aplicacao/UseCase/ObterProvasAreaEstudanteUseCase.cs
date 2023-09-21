using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasAreaEstudanteUseCase : IObterProvasAreaEstudanteUseCase
    {
        private readonly IMediator mediator;

        public ObterProvasAreaEstudanteUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<IEnumerable<ObterProvasRetornoDto>> Executar()
        {
            var claimsParaBuscar = new string[] { "ANO", "TIPOTURNO", "MODALIDADE", "RA" };
            var claimsDoUsuario = await mediator.Send(new ObterUsuarioLogadoInformacoesPorClaimsQuery(claimsParaBuscar));

            if (claimsDoUsuario == null)
                throw new NegocioException("Dados do usuário logado não localizado");

            var alunoLogadoAno = claimsDoUsuario.FirstOrDefault(a => a.Chave == "ANO")?.Valor;
            if (string.IsNullOrEmpty(alunoLogadoAno))
                throw new NegocioException("Ano do aluno logado não localizado");

            var alunoLogadoTurno = claimsDoUsuario.FirstOrDefault(a => a.Chave == "TIPOTURNO")?.Valor;
            if (string.IsNullOrEmpty(alunoLogadoTurno))
                throw new NegocioException("Turno do aluno logado não localizado");

            var alunoLogadoModalidade = claimsDoUsuario.FirstOrDefault(a => a.Chave == "MODALIDADE")?.Valor;
            if (string.IsNullOrEmpty(alunoLogadoModalidade))
                throw new NegocioException("Modalidade do aluno logado não localizado");

            var alunoRa = claimsDoUsuario.FirstOrDefault(a => a.Chave == "RA")?.Valor;
            if (string.IsNullOrEmpty(alunoRa))
                throw new NegocioException("Não foi possível obter o RA do usuário logado.");

            var tiposParaBuscar = new int[] { (int)TipoParametroSistema.TempoExtraProva, (int)TipoParametroSistema.TempoAlertaProva };
            var parametrosParaUtilizar = await mediator.Send(new ObterParametroSistemaPorTiposEAnoQuery(tiposParaBuscar, DateTime.Now.Year));

            if (parametrosParaUtilizar == null)
                throw new NegocioException("Parametros do sistema não localizado");

            var parametroTempoExtra = parametrosParaUtilizar.FirstOrDefault(a => a.Tipo == TipoParametroSistema.TempoExtraProva);

            var tempoExtra = 600;
            if (parametroTempoExtra != null)
                tempoExtra = int.Parse(parametroTempoExtra.Valor);

            var parametroTempoAlerta = parametrosParaUtilizar.FirstOrDefault(a => a.Tipo == TipoParametroSistema.TempoAlertaProva);

            var tempoAlerta = 300;
            if (parametroTempoAlerta != null)
                tempoAlerta = int.Parse(parametroTempoAlerta.Valor);

            var turmasAluno = await mediator.Send(new ObterTurmasAlunoPorRaQuery(long.Parse(alunoRa)));
            if (turmasAluno == null || !turmasAluno.Any())
                throw new NegocioException("Turma do aluno não localizado");

            var turmaAtual = turmasAluno.FirstOrDefault(t => t.Ano == alunoLogadoAno
                                                             && t.Modalidade == int.Parse(alunoLogadoModalidade)
                                                             && t.TipoTurno == int.Parse(alunoLogadoTurno));

            if (turmaAtual == null) return default;

            var provas = await mediator.Send(new ObterProvasPorAnoEModalidadeQuery(alunoLogadoAno, int.Parse(alunoLogadoModalidade), turmaAtual.EtapaEja, turmaAtual.AnoLetivo));
            
            var provasAdesao = (await mediator.Send(new ObterProvasAdesaoPorAlunoRaETurmaQuery(long.Parse(alunoRa), turmaAtual.Id)))
                .Where(c => !provas.Select(x => x.Id).Contains(c.Id));

            provas = JuntarListasProvas(provas, provasAdesao);

            provas = await TratarProvasPorTipoDeficiencia(provas, long.Parse(alunoRa));

            if (provas != null && provas.Any())
                return await ObterProvasRetorno(tempoExtra, tempoAlerta, alunoRa, provas);

            return default;
        }

        private async Task<IEnumerable<ObterProvasRetornoDto>> ObterProvasRetorno(int tempoExtra, int tempoAlerta, string alunoRa, IEnumerable<ProvaAnoDto> provas)
        {
            var provasParaRetornar = new List<ObterProvasRetornoDto>();

            var provasIds = provas.Select(a => a.Id).Distinct().ToArray();

            var provasDoAluno = await mediator.Send(new ObterProvaAlunoPorProvaIdsRaQuery(provasIds, long.Parse(alunoRa)));

            foreach (var prova in provas)
            {
                // TODO funcionalidade de audio e video bloqueada somente para provas com deficiencia, liberar esta funcionalidade para as demais provas 
                // após testes de carga com videos e audios.
                var exibirVideo = prova.ExibirVideo && prova.Deficiente;
                var exibirAudio = prova.ExibirAudio && prova.Deficiente;

                var caderno = "A";
                
                if (prova.PossuiBIB && DateTime.Now.Date <= prova.Fim.Date)
                {
                    caderno = await mediator.Send(new ObterCadernoAlunoPorProvaIdRaQuery(prova.Id, long.Parse(alunoRa)));

                    if (string.IsNullOrEmpty(caderno))
                        continue;

                    // TODO: removida mensagem, pois, se houver outras provas, não carrega nenhuma.
                    // throw new NegocioException($"Usuário informado {alunoRa} não possui caderno para a prova {prova.Id}");
                }                

                var provaAluno = provasDoAluno.FirstOrDefault(a => a.ProvaId == prova.Id);
                
                if (provaAluno is { Status: ProvaStatus.Finalizado or ProvaStatus.FinalizadoAutomaticamente })
                {
                    provasParaRetornar.Add(new ObterProvasRetornoDto(prova.Descricao,
                        prova.TotalItens,
                        (int)provaAluno.Status,
                        prova.ObterDataInicioDownloadMais3Horas(),
                        prova.ObterDataInicioMais3Horas(),
                        prova.ObterDataFimMais3Horas(),
                        prova.Id, prova.TempoExecucao,
                        tempoExtra, tempoAlerta, ObterTempoTotal(provaAluno), provaAluno?.CriadoEm, prova.Senha, prova.Modalidade,
                        provaAluno.FinalizadoEm, prova.QuantidadeRespostaSincronizacao, prova.UltimaAtualizacao, caderno,
                        prova.ProvaComProficiencia, prova.ApresentarResultados, prova.ApresentarResultadosPorItem,
                        prova.FormatoTai, prova.FormatoTaiItem, prova.FormatoTaiAvancarSemResponder, prova.FormatoTaiVoltarItemAnterior, exibirVideo, exibirAudio));
                    continue;
                }

                if (DateTime.Now.Date < prova.InicioDownload.GetValueOrDefault().Date ||
                    DateTime.Now.Date > prova.Fim.Date) continue;
                
                var status = ProvaStatus.NaoIniciado;
                if (provaAluno != null)
                    status = provaAluno.Status;

                provasParaRetornar.Add(new ObterProvasRetornoDto(prova.Descricao,
                    prova.TotalItens,
                    (int)status,
                    prova.ObterDataInicioDownloadMais3Horas(),
                    prova.ObterDataInicioMais3Horas(),
                    prova.ObterDataFimMais3Horas(),
                    prova.Id, prova.TempoExecucao,
                    tempoExtra, tempoAlerta, ObterTempoTotal(provaAluno),
                    provaAluno?.CriadoEm, prova.Senha,
                    prova.Modalidade, null, prova.QuantidadeRespostaSincronizacao, prova.UltimaAtualizacao, caderno,
                    prova.ProvaComProficiencia, prova.ApresentarResultados, prova.ApresentarResultadosPorItem,
                    prova.FormatoTai, prova.FormatoTaiItem, prova.FormatoTaiAvancarSemResponder, prova.FormatoTaiVoltarItemAnterior, exibirVideo, exibirAudio));
            }

            return provasParaRetornar;
        }

        private static int ObterTempoTotal(ProvaAluno provaAluno)
        {
            if (provaAluno != null)
            {
                TimeSpan tempoTotal = DateTime.Now - provaAluno.CriadoEm;
                return (int)tempoTotal.TotalSeconds;
            }
            return 0;
        }

        private static IEnumerable<ProvaAnoDto> JuntarListasProvas(IEnumerable<ProvaAnoDto> provas, IEnumerable<ProvaAnoDto> provasAdesao)
        {
            var retorno = new List<ProvaAnoDto>();
            
            if (provas != null && provas.Any())
                retorno.AddRange(provas);
            
            if (provasAdesao != null && provasAdesao.Any())
                retorno.AddRange(provasAdesao);

            return retorno.Distinct();
        }

        private async Task<IEnumerable<ProvaAnoDto>> TratarProvasPorTipoDeficiencia(IEnumerable<ProvaAnoDto> provas, long alunoRa)
        {
            var detalhes = await mediator.Send(new ObterDetalhesAlunoCacheQuery(alunoRa));
            if (detalhes.Deficiencias != null && detalhes.Deficiencias.Any())
            {
                var provasDeficienteIds = provas
                    .Where(t => t.Deficiente)
                    .Select(s => s.Id)
                    .Distinct()
                    .ToArray();

                var provasDeficienciasAluno = await mediator.Send(new ObterProvasPorDeficienciaQuery(provasDeficienteIds, detalhes.Deficiencias));

                if (provasDeficienciasAluno != null && provasDeficienciasAluno.Any())
                {
                    return provas.Where(x => provasDeficienciasAluno.Contains(x.Id));
                }
            }

            return provas.Where(a => !a.Deficiente);
        }
    }
}
