using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using SME.SERAp.Prova.Infra.Utils;
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

            var alunoLogadoAno = claimsDoUsuario.FirstOrDefault(a => a.Chave == "ANO")?.Valor;
            if (string.IsNullOrEmpty(alunoLogadoAno))
                throw new NegocioException("Ano do aluno logado não localizado");

            var alunoLogadoTurno = claimsDoUsuario.FirstOrDefault(a => a.Chave == "TIPOTURNO")?.Valor;
            if (string.IsNullOrEmpty(alunoLogadoTurno))
                throw new NegocioException("Turno do aluno logado não localizado");

            var alunoLogadoModalidade = claimsDoUsuario.FirstOrDefault(a => a.Chave == "MODALIDADE")?.Valor;
            if (string.IsNullOrEmpty(alunoLogadoModalidade))
                throw new NegocioException("Modalidade do aluno logado não localizado");

            var tiposParaBuscar = new int[] { (int)TipoParametroSistema.TempoExtraProva, (int)TipoParametroSistema.TempoAlertaProva };
            var parametrosParaUtilizar = await mediator.Send(new ObterParametroSistemaPorTiposEAnoQuery(tiposParaBuscar, DateTime.Now.Year));

            var parametroTempoExtra = parametrosParaUtilizar.FirstOrDefault(a => a.Tipo == TipoParametroSistema.TempoExtraProva);

            int tempoExtra = 600;
            if (parametroTempoExtra != null)
                tempoExtra = int.Parse(parametroTempoExtra.Valor);

            var parametroTempoAlerta = parametrosParaUtilizar.FirstOrDefault(a => a.Tipo == TipoParametroSistema.TempoAlertaProva);

            int tempoAlerta = 300;
            if (parametroTempoAlerta != null)
                tempoAlerta = int.Parse(parametroTempoAlerta.Valor);

            var alunoRa = claimsDoUsuario.FirstOrDefault(a => a.Chave == "RA")?.Valor;

            if (string.IsNullOrEmpty(alunoRa))
                throw new NegocioException("Não foi possível obter o RA do usuário logado.");

            var turmasAluno = await mediator.Send(new ObterTurmasAlunoPorRaQuery(long.Parse(alunoRa)));
            var turmaAtual = turmasAluno.Where(t => t.Ano == int.Parse(alunoLogadoAno) 
                                                    && t.Modalidade == int.Parse(alunoLogadoModalidade) 
                                                    && t.TipoTurno == int.Parse(alunoLogadoTurno)).FirstOrDefault();

            alunoLogadoAno = UtilAluno.AjustarAnoAluno(alunoLogadoModalidade, alunoLogadoAno);

            var provas = await mediator.Send(new ObterProvasPorAnoEModalidadeQuery(alunoLogadoAno, int.Parse(alunoLogadoModalidade)));
            var provasAdesao = await mediator.Send(new ObterProvasAdesaoPorAlunoRaETurmaQuery(long.Parse(alunoRa), turmaAtual.Id));

            provas = JuntarListasProvas(provas?.ToList(), provasAdesao);

            provas = await TratarProvasComAudio(provas?.ToList(), long.Parse(alunoRa));

            if (provas.Any())
            {
                return await ObterProvasRetorno(tempoExtra, tempoAlerta, alunoRa, provas);
            }
            else return default;
        }

        private async Task<IEnumerable<ObterProvasRetornoDto>> ObterProvasRetorno(int tempoExtra, int tempoAlerta, string alunoRa, IEnumerable<ProvaAnoDto> provas)
        {
            var provasParaRetornar = new List<ObterProvasRetornoDto>();

            var provasIds = provas.Select(a => a.Id).Distinct().ToArray();

            var provasDoAluno = await mediator.Send(new ObterProvaAlunoPorProvaIdsRaQuery(provasIds, long.Parse(alunoRa)));

            foreach (var prova in provas)
            {
                var provaAluno = provasDoAluno.FirstOrDefault(a => a.ProvaId == prova.Id);

                if (provaAluno != null && (provaAluno.Status == ProvaStatus.Finalizado || provaAluno.Status == ProvaStatus.FinalizadoAutomaticamente))
                {
                    provasParaRetornar.Add(new ObterProvasRetornoDto(prova.Descricao,
                        prova.TotalItens,
                        (int)provaAluno.Status,
                        prova.ObterDataInicioDownloadMais3Horas(),
                        prova.ObterDataInicioMais3Horas(),
                        prova.ObterDataFimMais3Horas(),
                        prova.Id, prova.TempoExecucao,
                        tempoExtra, tempoAlerta, ObterTempoTotal(provaAluno), provaAluno?.CriadoEm, prova.Senha, prova.Modalidade,
                        provaAluno.FinalizadoEm));
                    continue;
                }

                if (DateTime.Now.Date >= prova.InicioDownload.Value.Date && DateTime.Now.Date <= prova.Fim.Date)
                {
                    ProvaStatus status = ProvaStatus.NaoIniciado;
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
                        prova.Modalidade));
                }

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

        private IEnumerable<ProvaAnoDto> JuntarListasProvas(List<ProvaAnoDto> provas, List<ProvaAnoDto> provasAdesao)
        {
            var retorno = new List<ProvaAnoDto>();
            if (provas != null && provas.Any())
                retorno.AddRange(provas);
            if (provasAdesao != null && provasAdesao.Any())
                retorno.AddRange(provasAdesao);
            
            return retorno.Distinct();
        }

        private async Task<IEnumerable<ProvaAnoDto>> TratarProvasComAudio(List<ProvaAnoDto> provas, long alunoRa)
        {
            var alunoNecessitaProvaComAudio = await mediator.Send(new VerificaAlunoProvaComAudioPorRaQuery(alunoRa));
            var provasComAudio = await mediator.Send(new ObterProvasComAudioPorIdsQuery(provas.Select(a => a.Id).ToArray()));
            if (!alunoNecessitaProvaComAudio)
            {                
                return provas.Where(a => !provasComAudio.Any(pa => pa == a.Id)).AsEnumerable();
            }            

            return provas.AsEnumerable();
        }
    }
}
