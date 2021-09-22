namespace SME.SERAp.Prova.Infra
{
    public class ProvaAlunoDto
    {
        public ProvaAlunoDto(long provaId, int status)
        {
            ProvaId = provaId;
            Status = status;
        }

        public long ProvaId { get; set; }
        public int Status { get; set; }
    }
}
