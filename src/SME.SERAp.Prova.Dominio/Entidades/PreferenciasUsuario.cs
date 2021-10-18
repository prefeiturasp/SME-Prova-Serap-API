using System;

namespace SME.SERAp.Prova.Dominio
{
    public class PreferenciasUsuario : EntidadeBase
    {
        public long UsuarioId { get; set; }
        public int TamanhoFonte { get; set; }

        public PreferenciasUsuario()
        {
        }

        public PreferenciasUsuario(long usuarioId, int tamanhoFonte)
        {
            UsuarioId = usuarioId;
            TamanhoFonte = tamanhoFonte;
        }
    }
}