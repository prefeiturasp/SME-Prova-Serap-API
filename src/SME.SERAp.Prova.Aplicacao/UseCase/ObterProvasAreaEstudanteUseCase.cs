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

            alunoLogadoAno = UtilAluno.AjustarAnoAluno(alunoLogadoModalidade, alunoLogadoAno);
            var provas = await mediator.Send(new ObterProvasPorAnoEModalidadeQuery(alunoLogadoAno, DateTime.Today, int.Parse(alunoLogadoModalidade)));

            if (provas.Any())
            {
                var alunoRa = claimsDoUsuario.FirstOrDefault(a => a.Chave == "RA")?.Valor;

                if (string.IsNullOrEmpty(alunoRa))
                    throw new NegocioException("Não foi possível obter o RA do usuário logado.");

                var provasParaRetornar = new List<ObterProvasRetornoDto>();

                var provasIds = provas.Select(a => a.Id).Distinct().ToArray();

                var provasDoAluno = await mediator.Send(new ObterProvaAlunoPorProvaIdsRaQuery(provasIds, long.Parse(alunoRa)));

                foreach (var prova in provas)
                {
                    var provaAluno = provasDoAluno.FirstOrDefault(a => a.ProvaId == prova.Id);

                    if (provaAluno != null && (provaAluno.Status == ProvaStatus.Finalizado || provaAluno.Status == ProvaStatus.FinalizadoAutomaticamente))
                        continue;

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
                        tempoExtra, tempoAlerta, ObterTempoTotal(provaAluno), provaAluno?.CriadoEm, prova.Senha, prova.Modalidade));
                }

                return provasParaRetornar;
            }
            else return default;
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
    }
}
