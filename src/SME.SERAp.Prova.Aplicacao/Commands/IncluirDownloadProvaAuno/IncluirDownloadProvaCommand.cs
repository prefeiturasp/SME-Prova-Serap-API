using MediatR;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirDownloadProvaCommand : IRequest<long>
    {
        public IncluirDownloadProvaCommand(long alunoRa, DownloadProvaAlunoDto downloadProvaAlunoDto)
        {
            AlunoRa = alunoRa;
            DownloadProvaAlunoDto = downloadProvaAlunoDto;
            Situacao = 1;

        }

        public DownloadProvaAlunoDto DownloadProvaAlunoDto { get; set; }
        public long AlunoRa { get; set; }
        public int Situacao { get; set; }

    }
}

