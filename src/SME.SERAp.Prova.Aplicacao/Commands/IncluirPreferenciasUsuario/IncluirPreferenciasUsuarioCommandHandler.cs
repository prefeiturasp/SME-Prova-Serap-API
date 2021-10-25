using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirPreferenciasUsuarioCommandHandler : IRequestHandler<IncluirPreferenciasUsuarioCommand, bool>
    {
        private readonly IRepositorioPreferenciasUsuario repositorioPreferenciasUsuario;

        public IncluirPreferenciasUsuarioCommandHandler(IRepositorioPreferenciasUsuario repositorioPreferenciasUsuario)
        {
            this.repositorioPreferenciasUsuario = repositorioPreferenciasUsuario ??
                                                  throw new System.ArgumentNullException(
                                                      nameof(repositorioPreferenciasUsuario));
        }

        public async Task<bool> Handle(IncluirPreferenciasUsuarioCommand request, CancellationToken cancellationToken)
        {
            var entidade = new PreferenciasUsuario(request.UsuarioId, request.TamanhoFonte, request.FamiliaFonte);

            return await repositorioPreferenciasUsuario.SalvarAsync(entidade) > 0;
        }
    }
}