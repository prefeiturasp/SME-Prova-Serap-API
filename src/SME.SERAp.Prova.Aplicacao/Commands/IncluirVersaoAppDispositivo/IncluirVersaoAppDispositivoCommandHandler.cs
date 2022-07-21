using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dados.Interfaces;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirVersaoAppDispositivoCommandHandler : IRequestHandler<IncluirVersaoAppDispositivoCommand, bool>
    {
        private readonly IRepositorioCache repositorioCache;
        private readonly IMediator mediator;

        public IncluirVersaoAppDispositivoCommandHandler(IRepositorioCache repositorioCache,
            IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.repositorioCache = repositorioCache ?? throw new ArgumentNullException(nameof(repositorioCache));
        }

        public async Task<bool> Handle(IncluirVersaoAppDispositivoCommand request, CancellationToken cancellationToken)
        {
            var versaoAppDispositivo = new Dominio.VersaoAppDispositivo(
            request.VersaoAppDispositivo.VersaoCodigo,
            request.VersaoAppDispositivo.VersaoDescricao,
            request.VersaoAppDispositivo.DispositivoImei,
            request.VersaoAppDispositivo.AtualizadoEm);

            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.IncluirVersaoDispositivoApp, versaoAppDispositivo));
            await repositorioCache.SalvarRedisAsync(versaoAppDispositivo.DispositivoImei.ToString(), versaoAppDispositivo);

            return true;
        }
    }
}
