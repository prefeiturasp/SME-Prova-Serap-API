using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Infra
{

    public class DownloadProvaAlunoFilaDto
    {
        public DownloadProvaAlunoFilaDto(DownloadProvaAlunoSituacao situacao, DownloadProvaAlunoDto downloadProvaAlunoDto, DownloadProvaAlunoExcluirDto downloadProvaAlunoExcluirDto)
        {
            Situacao = situacao;
            DownloadProvaAlunoDto = downloadProvaAlunoDto;
            DownloadProvaAlunoExcluirDto = downloadProvaAlunoExcluirDto;
        }

        public DownloadProvaAlunoSituacao Situacao { get; set; }
        public DownloadProvaAlunoDto DownloadProvaAlunoDto { get; set; }
        public DownloadProvaAlunoExcluirDto DownloadProvaAlunoExcluirDto { get; set; }
    }
}
