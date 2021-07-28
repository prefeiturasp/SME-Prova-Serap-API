using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class VerificaAutenticacaoUsuarioQuery : IRequest<bool>
    {
        public VerificaAutenticacaoUsuarioQuery(long alunoRA, string senha)
        {
            AlunoRA = alunoRA;
            Senha = senha;
        }

        public long AlunoRA { get; set; }
        public string Senha { get; set; }
    }
}
