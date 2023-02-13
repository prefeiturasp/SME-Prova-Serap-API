using MediatR;
using SME.SERAp.Prova.Infra.Dtos.ApiR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProximoItemApiRQuery : IRequest<ObterProximoItemApiRRespostaDto>
    {
        public ObterProximoItemApiRQuery(string estudante, string anoEscolarEstudante, decimal proficiencia, long[] idItem, decimal[] parA, decimal[] parB, decimal[] parC, string anoEscolarItem, string habilidade, string assunto, string subAssunto, int nIj, long[] respostas, long[] gabarito, long[] administrado)
        {
            Estudante = estudante;
            AnoEscolarEstudante = anoEscolarEstudante;
            Proficiencia = proficiencia;
            IdItem = idItem;
            ParA = parA;
            ParB = parB;
            ParC = parC;
            AnoEscolarItem = anoEscolarItem;
            Habilidade = habilidade;
            Assunto = assunto;
            SubAssunto = subAssunto;
            NIj = nIj;
            Respostas = respostas;
            Gabarito = gabarito;
            Administrado = administrado;
        }

        public string Estudante { get; set; }
        public string AnoEscolarEstudante { get; set; }
        public decimal Proficiencia { get; set; }
        public long[] IdItem { get; set; }
        public decimal[] ParA { get; set; }
        public decimal[] ParB { get; set; }
        public decimal[] ParC { get; set; }
        public string AnoEscolarItem { get; set; }
        public string Habilidade { get; set; }
        public string Assunto { get; set; }
        public string SubAssunto { get; set; }
        public int NIj { get; set; }
        public long[] Respostas { get; set; }
        public long[] Gabarito { get; set; }
        public long[] Administrado { get; set; }
    }
}
