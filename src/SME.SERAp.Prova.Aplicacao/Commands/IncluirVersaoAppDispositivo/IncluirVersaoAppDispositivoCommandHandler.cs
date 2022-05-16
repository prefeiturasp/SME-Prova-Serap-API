using MediatR;
using SME.SERAp.Prova.Dados.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirVersaoAppDispositivoCommandHandler : IRequestHandler<IncluirVersaoAppDispositivoCommand, bool>
    {
        private readonly IRepositorioVersaoAppDispositivo repositorioVersaoAppDispositivo;

        public IncluirVersaoAppDispositivoCommandHandler(IRepositorioVersaoAppDispositivo repositorioVersaoAppDispositivo)
        {
            this.repositorioVersaoAppDispositivo = repositorioVersaoAppDispositivo ?? throw new ArgumentNullException(nameof(repositorioVersaoAppDispositivo));
        }

        public async Task<bool> Handle(IncluirVersaoAppDispositivoCommand request, CancellationToken cancellationToken)
        {
            await repositorioVersaoAppDispositivo.IncluirAsync(new Dominio.VersaoAppDispositivo(
                request.VersaoAppDispositivo.VersaoCodigo, 
                request.VersaoAppDispositivo.VersaoDescricao, 
                request.VersaoAppDispositivo.DispositivoImei, 
                request.VersaoAppDispositivo.AtualizadoEm));

            return true;
        }
    }
}
