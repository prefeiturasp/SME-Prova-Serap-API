using System;

namespace SME.SERAp.Prova.Infra
{
    public class ProvaAlunoStatusDto
    {
        public ProvaAlunoStatusDto(int status, long? dataFim)
        {
            Status = status;
            DataFim = dataFim;
        }

        public int Status { get; set; }
        public long? DataFim { get; set; }
    }
}
