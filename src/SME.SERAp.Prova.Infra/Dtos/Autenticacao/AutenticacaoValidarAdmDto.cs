namespace SME.SERAp.Prova.Infra
{
    public class AutenticacaoValidarAdmDto : DtoBase
    {
        public AutenticacaoValidarAdmDto(string codigo)
        {
            Codigo = codigo;
        }

        public string Codigo { get; set; }
    }
}
