using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Infra
{
    public class MeusDadosRetornoDto
    {
        public MeusDadosRetornoDto(string nome, string ano, string turno, int tamanhoFonte, int familiaFonte, Modalidade modalidade,int inicioTurno)
        {
            Nome = nome;
            Ano = ano;
            TipoTurno = turno;
            TamanhoFonte = tamanhoFonte;
            FamiliaFonte = familiaFonte;
            Modalidade = modalidade;
            InicioTurno = inicioTurno;
        }

        public string Nome { get; set; }
        public string Ano { get; set; }
        public string TipoTurno { get; set; }
        public int TamanhoFonte { get; set; }
        public Modalidade Modalidade { get; set; }
        public int FamiliaFonte { get; set; }
        public int InicioTurno { get; set; }
    }
}
