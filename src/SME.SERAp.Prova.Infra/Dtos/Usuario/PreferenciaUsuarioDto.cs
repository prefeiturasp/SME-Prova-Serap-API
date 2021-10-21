using System.ComponentModel.DataAnnotations;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Infra
{
    public class PreferenciaUsuarioDto
    {
        public int TamanhoFonte { get; set; }
        public FamiliaFonte FamiliaFonte { get; set; }
    }
}
