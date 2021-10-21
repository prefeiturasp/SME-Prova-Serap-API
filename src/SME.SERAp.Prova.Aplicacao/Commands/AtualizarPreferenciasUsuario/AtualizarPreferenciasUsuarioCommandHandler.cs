using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class AtualizarPreferenciasUsuarioCommandHandler : IRequestHandler<AtualizarPreferenciasUsuarioCommand, bool>
    {
        private readonly IRepositorioPreferenciasUsuario repositorioPreferenciasUsuario;

        public AtualizarPreferenciasUsuarioCommandHandler(
            IRepositorioPreferenciasUsuario repositorioPreferenciasUsuario)
        {
            this.repositorioPreferenciasUsuario = repositorioPreferenciasUsuario ??
                                                  throw new System.ArgumentNullException(
                                                      nameof(repositorioPreferenciasUsuario));
        }

        public async Task<bool> Handle(AtualizarPreferenciasUsuarioCommand request, CancellationToken cancellationToken)
            => await repositorioPreferenciasUsuario.SalvarAsync(request.PreferenciasUsuario) > 0;
    }
}