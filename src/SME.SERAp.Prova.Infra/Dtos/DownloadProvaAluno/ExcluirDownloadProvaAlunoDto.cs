using System;

namespace SME.SERAp.Prova.Infra
{
    public class ExcluirDownloadProvaAlunoDto
    {
        public ExcluirDownloadProvaAlunoDto(long[] ids, DateTime dataAlteracao)
        {
            Ids = ids;
            DataAlteracao = dataAlteracao;
        }

        public long[] Ids { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
