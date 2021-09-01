namespace SME.SERAp.Prova.Infra
{
    public class MeusDadosRetornoDto
    {
        public MeusDadosRetornoDto(string nome, string ano)
        {
            Nome = nome;
            Ano = ano;
        }

        public string Nome { get; set; }
        public string Ano { get; set; }
    }
}
