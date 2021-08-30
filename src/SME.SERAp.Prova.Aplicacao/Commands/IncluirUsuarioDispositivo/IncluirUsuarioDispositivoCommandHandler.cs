using MediatR;
using SME.SERAp.Prova.Dados.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirUsuarioDispositivoCommandHandler : IRequestHandler<IncluirUsuarioDispositivoCommand, bool>
    {
        private readonly IRepositorioUsuarioDispositivo repositorioUsuarioDispositivo;

        public IncluirUsuarioDispositivoCommandHandler(IRepositorioUsuarioDispositivo repositorioUsuarioDispositivo)
        {
            this.repositorioUsuarioDispositivo = repositorioUsuarioDispositivo ?? throw new System.ArgumentNullException(nameof(repositorioUsuarioDispositivo));
        }
        public async Task<bool> Handle(IncluirUsuarioDispositivoCommand request, CancellationToken cancellationToken)
        {
            var usuariosDispositivos = await repositorioUsuarioDispositivo.ObterPorDispositivoRaAsync(request.DispositivoId, request.Ra);
            
            if (usuariosDispositivos != null && usuariosDispositivos.Any())
            {
                var idsParaRemover = usuariosDispositivos.Select(a => a.Id).ToArray();
                await repositorioUsuarioDispositivo.RemoverPorIds(idsParaRemover);
            }            

            return await repositorioUsuarioDispositivo.IncluirAsync(new Dominio.UsuarioDispositivo(request.DispositivoId, request.Ra, request.Ano)) > 0;
        }
    }
}
