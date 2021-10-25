using MediatR;
using SME.SERAp.Prova.Dominio;
using System;

namespace SME.SERAp.Prova.Aplicacao
{
    public class AtualizarAlunoCommand : IRequest<bool>
    {
        public AtualizarAlunoCommand(Aluno aluno)
        {
            Aluno = aluno;
        }

        public Aluno Aluno { get; set; }
    }
}
