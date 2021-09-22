using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ExcluirProvaAlunoPorIdCommand : IRequest<bool>
    {
        public ExcluirProvaAlunoPorIdCommand(ProvaAluno provaAluno)
        {
            ProvaAluno = provaAluno;
        }

        public ProvaAluno ProvaAluno { get; set; }
    }
}
