using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class VerificaAlunoProvaComAudioPorRaQuery : IRequest<bool>
    {
        public VerificaAlunoProvaComAudioPorRaQuery(long alunoRa)
        {
            AlunoRa = alunoRa;
        }

        public long AlunoRa { get; set; }

    }
}
