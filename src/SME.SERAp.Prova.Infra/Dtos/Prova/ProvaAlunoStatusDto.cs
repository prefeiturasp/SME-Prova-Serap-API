namespace SME.SERAp.Prova.Infra
{
    public class ProvaAlunoStatusDto
    {
        public ProvaAlunoStatusDto(int status)
        {
            Status = status;
        }

        public int Status { get; set; }
    }
}
