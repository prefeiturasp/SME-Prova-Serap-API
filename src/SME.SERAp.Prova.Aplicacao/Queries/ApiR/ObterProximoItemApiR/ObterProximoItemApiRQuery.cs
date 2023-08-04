using MediatR;
using SME.SERAp.Prova.Infra.Dtos.ApiR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProximoItemApiRQuery : IRequest<ObterProximoItemApiRRespostaDto>
    {
        public ObterProximoItemApiRQuery(string estudante, string anoEscolarEstudante, decimal proficiencia,
            long[] idItem, decimal[] parA, decimal[] parB, decimal[] parC, int nIj, long[] respostas, long[] gabarito, 
            long[] administrado, string componente)
        {
            Estudante = estudante;
            AnoEscolarEstudante = anoEscolarEstudante;
            Proficiencia = proficiencia;
            IdItem = idItem;
            ParA = parA;
            ParB = parB;
            ParC = parC;
            NIj = nIj;
            Respostas = respostas;
            Gabarito = gabarito;
            Administrado = administrado;
            Componente = componente;
        }

        public string Estudante { get; set; }
        public string AnoEscolarEstudante { get; set; }
        public decimal Proficiencia { get; set; }
        public long[] IdItem { get; set; }
        public decimal[] ParA { get; set; }
        public decimal[] ParB { get; set; }
        public decimal[] ParC { get; set; }
        public int NIj { get; set; }
        public long[] Respostas { get; set; }
        public long[] Gabarito { get; set; }
        public long[] Administrado { get; set; }
        public string Componente { get; set; }
    }
}
