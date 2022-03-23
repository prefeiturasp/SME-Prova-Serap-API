namespace SME.SERAp.Prova.Infra
{
    public class AutenticacaoValidarAdmDto
    {
        public AutenticacaoValidarAdmDto(string codigo)
        {
            Codigo = codigo;
        }

        public string Codigo { get; set; }
    }
}
