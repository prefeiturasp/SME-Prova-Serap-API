using MediatR;
using SME.SERAp.Prova.Infra.Dtos;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class ObterDataHoraServidorUseCase : AbstractUseCase, IObterDataHoraServidorUseCase
    {
        public ObterDataHoraServidorUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<DataHoraServidorDto> Executar()
        {
            var tolerancia = await mediator.Send(new ObterParametroSistemaPorTipoEAnoQuery(Dominio.TipoParametroSistema.ToleranciaDataHoraServidor, DateTime.Now.Year));

            var datahoraServidor = new DataHoraServidorDto()
            {
                Tolerancia = int.Parse(tolerancia.Valor),
                DataHora = DateTime.Now
            };

            return datahoraServidor;
        }
    }
}
