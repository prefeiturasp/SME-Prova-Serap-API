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

            //TODO: UNIFICAR BUSCA DAS CLAIMS
            var alunoLogadoAno = await mediator.Send(new ObterUsuarioLogadoInformacaoPorClaimQuery("ANO"));
            if (string.IsNullOrEmpty(alunoLogadoAno))
                throw new NegocioException("Ano do aluno logado não localizado");

            var alunoLogadoTurno = await mediator.Send(new ObterUsuarioLogadoInformacaoPorClaimQuery("TIPOTURNO"));
            if (string.IsNullOrEmpty(alunoLogadoTurno))
                throw new NegocioException("Turno do aluno logado não localizado");

            var alunoLogadoModalidade = await mediator.Send(new ObterUsuarioLogadoInformacaoPorClaimQuery("MODALIDADE"));
            if (string.IsNullOrEmpty(alunoLogadoModalidade))
                throw new NegocioException("Modalidade do aluno logado não localizado");

            var tiposParaBuscar = new int[] {(int)TipoParametroSistema.TempoExtraProva, (int)TipoParametroSistema.TempoAlertaProva};
            var parametrosParaUtilizar = await mediator.Send(new ObterParametroSistemaPorTiposEAnoQuery(tiposParaBuscar, DateTime.Now.Year));

            var parametroTempoExtra = parametrosParaUtilizar.FirstOrDefault(a => a.Tipo == TipoParametroSistema.TempoExtraProva);

            int tempoExtra = 600;
            if (parametroTempoExtra != null)
                tempoExtra = int.Parse(parametroTempoExtra.Valor);

            var parametroTempoAlerta = parametrosParaUtilizar.FirstOrDefault(a => a.Tipo == TipoParametroSistema.TempoAlertaProva);

            int tempoAlerta = 300;
            if (parametroTempoAlerta != null)
                tempoAlerta = int.Parse(parametroTempoAlerta.Valor);

            var provas = await mediator.Send(new ObterProvasPorAnoEModalidadeQuery(alunoLogadoAno, DateTime.Today, int.Parse(alunoLogadoModalidade)));

            if (provas.Any())
            {
                var alunoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());

                var provasParaRetornar = new List<ObterProvasRetornoDto>();

                var provasIds = provas.Select(a => a.Id).Distinct().ToArray();

                var provasDoAluno = await mediator.Send(new ObterProvaAlunoPorProvaIdsRaQuery(provasIds, alunoRa));

                foreach (var prova in provas)
                {
                    var provaAluno = provasDoAluno.FirstOrDefault(a => a.ProvaId == prova.Id);

                    if (provaAluno != null && provaAluno.Status == ProvaStatus.Finalizado)
                        continue;

                    ProvaStatus status = ProvaStatus.NaoIniciado;
                    if (provaAluno != null)
                        status = provaAluno.Status;

                    
                    provasParaRetornar.Add(new ObterProvasRetornoDto(prova.Descricao, prova.TotalItens, (int)status, 
                        prova.InicioDownload, prova.Inicio, prova.Fim, prova.Id, prova.TempoExecucao, 
                        tempoExtra, tempoAlerta, ObterTempoTotal(provaAluno), provaAluno?.CriadoEm, prova.Senha, prova.Modalidade));
                }

                return provasParaRetornar;
            }
            else return default;
        }

        private static int ObterTempoTotal(ProvaAluno provaAluno)
        {
            if(provaAluno != null)
            {
                TimeSpan tempoTotal = DateTime.Now - provaAluno.CriadoEm;
                return (int)tempoTotal.TotalSeconds;
            }
            return 0;
        }
    }
}
