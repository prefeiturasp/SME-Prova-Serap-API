using MediatR;
using SME.SERAp.Prova.Aplicacao.Queries.ObterProvaCadernosPorProvaId;
using SME.SERAp.Prova.Infra.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class ObterProvaCadernosAreaAdministrativoUseCase : IObterProvaCadernosAreaAdministrativoUseCase
    {

        private readonly IMediator mediator;

        public ObterProvaCadernosAreaAdministrativoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<ProvaCadernoRetornoDto> Executar(long provaId)
        {
            var retorno = new ProvaCadernoRetornoDto();
            var cadernos = await mediator.Send(new ObterProvaCadernosPorProvaIdQuery(provaId));

            if (cadernos.Any())
                retorno.Cadernos = cadernos.Select(t => t.Caderno).ToArray();
            else
                retorno.Cadernos = Array.Empty<string>();

            return retorno;
        }
    }
}
