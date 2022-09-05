namespace SME.SERAp.Prova.Infra.Dtos.Aluno
{
    public class DadosAlunoLogadoDto
    {
        public DadosAlunoLogadoDto(long ra, string dispositivoId)
        {
            Ra = ra;
            DispositivoId = dispositivoId;
        }

        public long Ra { get; set; }
        public string DispositivoId { get; set; }
    }
}
