using System;

namespace SME.SERAp.Prova.Infra
{
    public class DownloadProvaAlunoExcluirDto
    {
        public DownloadProvaAlunoExcluirDto(Guid[] codigos, DateTime dataAlteracao)
        {
            Codigos = codigos;
            DataAlteracao = dataAlteracao;
        }

        public Guid[] Codigos { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
