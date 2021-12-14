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
    public class ObterProvasAnterioresAreaEstudanteUseCase : IObterProvasAnterioresAreaEstudanteUseCase
    {
        private readonly IMediator mediator;
        public ObterProvasAnterioresAreaEstudanteUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<IEnumerable<ObterProvasRetornoDto>> Executar()
        {
            var alunoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());            
            var provas = await mediator.Send(new ObterProvasAnterioresAlunoPorRaQuery(alunoRa));

            if (provas.Any())
            {

                if (alunoRa == 0)
                    throw new NegocioException("Não foi possível obter o RA do usuário logado.");

                var provasParaRetornar = new List<ObterProvasRetornoDto>();

                foreach (var prova in provas)
                {
                    provasParaRetornar.Add(MapearParaDto(prova));
                }

                return provasParaRetornar;
            }
            else return default;
        }

        private ObterProvasRetornoDto MapearParaDto(ProvaAlunoAnoDto provaAluno)
        {
            int tempoExtra = 0;
            int tempoAlerta = 0;
            var provaRetornoDto = new ObterProvasRetornoDto(provaAluno.Descricao,
                        provaAluno.TotalItens,
                        provaAluno.Status,
                        provaAluno.InicioDownload,
                        provaAluno.Inicio,
                        provaAluno.Fim,
                        provaAluno.Id, provaAluno.TempoExecucao,
                        tempoExtra, tempoAlerta, 0, provaAluno.DataInicioProvaAluno, provaAluno.Senha, provaAluno.Modalidade);
            provaRetornoDto.DataFimProvaAluno = provaAluno.DataFimProvaAluno;

            return provaRetornoDto;
        }
    }
}
