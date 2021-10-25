using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirUsuarioCommand : IRequest<bool>
    {
        public IncluirUsuarioCommand(long login, string nome)
        {
            Login = login;
            Nome = nome;
        }

        public long Login { get; set; }
        public string Nome { get; set; }
    }
}
