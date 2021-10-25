﻿using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterUsuarioPorLoginQueryHandler : IRequestHandler<ObterUsuarioPorLoginQuery, Usuario>
    {
        private readonly IRepositorioUsuario repositorioUsuario;

        public ObterUsuarioPorLoginQueryHandler(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario ?? throw new System.ArgumentNullException(nameof(repositorioUsuario));
        }
        public async Task<Usuario> Handle(ObterUsuarioPorLoginQuery request, CancellationToken cancellationToken)
        {
            return await repositorioUsuario.ObterPorLogin(request.Login);
        }
    }
}
