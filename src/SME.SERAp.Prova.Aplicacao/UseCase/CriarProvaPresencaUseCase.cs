using MediatR;
using SME.SERAp.Prova.Aplicacao.Interfaces.UseCase;
using SME.SERAp.Prova.Aplicacao.Queries.ExisteProvaPresencaPorNomeEAno;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.ProvaPresenca;
using SME.SERAp.Prova.Infra.Exceptions;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class CriarProvaPresencaUseCase : AbstractUseCase, ICriarProvaPresencaUseCase
    {
        public CriarProvaPresencaUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar(CriarProvaPresencaDto provaPresencaDto)
        {
            var existe = await mediator.Send(new ExisteProvaPresencaPorNomeEAnoQuery(provaPresencaDto.NomeProva, provaPresencaDto.AnoProva));
            if (existe)
            {
                throw new NegocioException($"Já existe uma prova de presença com o nome '{provaPresencaDto.NomeProva}' e ano '{provaPresencaDto.AnoProva}'.");
            }

            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.CriarProvaPresenca, provaPresencaDto));
            return true;
        }
    }
}