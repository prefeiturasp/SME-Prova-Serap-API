using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dados.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirUsuarioCommandHandler : IRequestHandler<IncluirUsuarioCommand, bool>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public IncluirUsuarioCommandHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new System.ArgumentNullException(nameof(repositorioUsuario));
        }
        public async Task<bool> Handle(IncluirUsuarioCommand request, CancellationToken cancellationToken)
            => await repositorioUsuario.IncluirAsync(new Dominio.Usuario(request.Nome, request.Login)) > 0;
    }
}
