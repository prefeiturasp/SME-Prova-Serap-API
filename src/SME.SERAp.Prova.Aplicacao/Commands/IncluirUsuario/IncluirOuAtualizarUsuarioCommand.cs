using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirOuAtualizarUsuarioCommand : IRequest<bool>
    {
        public IncluirOuAtualizarUsuarioCommand(long login, string nome)
        {
            Login = login;
            Nome = nome;
        }

        public long Login { get; set; }
        public string Nome { get; set; }
    }
}
