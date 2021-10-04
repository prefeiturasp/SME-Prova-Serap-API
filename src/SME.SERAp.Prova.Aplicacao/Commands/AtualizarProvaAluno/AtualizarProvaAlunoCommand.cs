﻿using MediatR;
using SME.SERAp.Prova.Dominio;
using System;

namespace SME.SERAp.Prova.Aplicacao
{
    public class AtualizarProvaAlunoCommand : IRequest<bool>
    {
        public AtualizarProvaAlunoCommand(ProvaAluno provaAluno)
        {
            ProvaAluno = provaAluno;
        }

        public ProvaAluno ProvaAluno { get; set; }
    }
}
