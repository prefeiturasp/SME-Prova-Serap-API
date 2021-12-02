using System.ComponentModel.DataAnnotations;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Infra
{
    public class PreferenciaUsuarioRabbitDto
    {
        public PreferenciaUsuarioRabbitDto()
        {

        }
        public PreferenciaUsuarioRabbitDto(long alunoRA, int tamanhoFonte, int familiaFonte)
        {
            AlunoRA = alunoRA;
            TamanhoFonte = tamanhoFonte;
            FamiliaFonte = familiaFonte;
        }

        public long AlunoRA { get; set; }
        public int TamanhoFonte { get; set; }
        public int FamiliaFonte { get; set; }
    }
}
