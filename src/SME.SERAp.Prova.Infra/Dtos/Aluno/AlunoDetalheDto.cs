namespace SME.SERAp.Prova.Infra.Dtos.Aluno
{
    public class AlunoDetalheDto : DtoBase
    {
        public string DreAbreviacao { get; set; }
        public string Escola { get; set; }
        public string Turma { get; set; }
        public string Nome { get; set; }
        public string NomeSocial { get; set; }

        public string NomeFinal()
        {
            return string.IsNullOrEmpty(NomeSocial) ? Nome : NomeSocial;
        }
    }
}
