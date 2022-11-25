using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class TesteFuncaoRQuery : IRequest<string>
    {
        
        public TesteFuncaoRQuery(int _base, int _expoente)
        {
            Base = _base;
            Expoente = _expoente;
        }

        public int Base { get; set; }
        public int Expoente { get; set; }

    }
}
