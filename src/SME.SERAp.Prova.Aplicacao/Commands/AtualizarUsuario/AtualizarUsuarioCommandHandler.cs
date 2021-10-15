using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand, bool>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public AtualizarUsuarioCommandHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario =
                repositorioUsuario ?? throw new System.ArgumentNullException(nameof(repositorioUsuario));
        }

        public async Task<bool> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
            => await repositorioUsuario.SalvarAsync(request.Usuario) > 0;
    }
}