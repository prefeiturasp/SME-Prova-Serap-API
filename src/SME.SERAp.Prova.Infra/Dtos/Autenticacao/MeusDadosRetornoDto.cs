using MessagePack;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Infra
{
    [MessagePackObject (keyAsPropertyName: true)]
    public class MeusDadosRetornoDto
    {
        public MeusDadosRetornoDto()
        {

        }
        public MeusDadosRetornoDto(string nome, string ano, string turno, int tamanhoFonte, int familiaFonte, Modalidade modalidade,int inicioTurno, int fimTurno)
        {
            Nome = nome;
            Ano = ano;
            TipoTurno = turno;
            TamanhoFonte = tamanhoFonte;
            FamiliaFonte = familiaFonte;
            Modalidade = modalidade;
            InicioTurno = inicioTurno;
            FimTurno = fimTurno;
        }

        public string Nome { get; set; }
        public string Ano { get; set; }
        public string TipoTurno { get; set; }
        public int TamanhoFonte { get; set; }
        public Modalidade Modalidade { get; set; }
        public int FamiliaFonte { get; set; }
        public int InicioTurno { get; set; }
        public int FimTurno { get; set; }
    }
}
