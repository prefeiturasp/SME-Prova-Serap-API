using System.ComponentModel.DataAnnotations;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Infra
{
    public class PreferenciaUsuarioDto : DtoBase
    {
        public int TamanhoFonte { get; set; }
        public int FamiliaFonte { get; set; }
    }
}
