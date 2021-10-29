using System;

namespace SME.SERAp.Prova.Dominio
{
    public class PreferenciasUsuario : EntidadeBase
    {
        public long UsuarioId { get; set; }
        public int TamanhoFonte { get; set; }
        public FamiliaFonte FamiliaFonte { get; set; }

        public PreferenciasUsuario()
        {
        }

        public PreferenciasUsuario(long usuarioId, int tamanhoFonte, FamiliaFonte familiaFonte)
        {
            UsuarioId = usuarioId;
            TamanhoFonte = tamanhoFonte;
            FamiliaFonte = familiaFonte;
        }
    }
}