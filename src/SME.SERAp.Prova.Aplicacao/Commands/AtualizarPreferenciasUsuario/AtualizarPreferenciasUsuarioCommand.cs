using MediatR;
using SME.SERAp.Prova.Dominio;
using System;

namespace SME.SERAp.Prova.Aplicacao
{
    public class AtualizarPreferenciasUsuarioCommand : IRequest<bool>
    {
        public AtualizarPreferenciasUsuarioCommand(PreferenciasUsuario preferenciasUsuario)
        {
            PreferenciasUsuario = preferenciasUsuario;
        }

        public PreferenciasUsuario PreferenciasUsuario { get; set; }
    }
}
