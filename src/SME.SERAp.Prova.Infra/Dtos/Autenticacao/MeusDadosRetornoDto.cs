namespace SME.SERAp.Prova.Infra
{
    public class MeusDadosRetornoDto
    {
        public MeusDadosRetornoDto(string nome, string ano, string turno)
        {
            Nome = nome;
            Ano = ano;
            TipoTurno = turno;
        }

        public string Nome { get; set; }
        public string Ano { get; set; }
        public string TipoTurno { get; set; }
    }
}
