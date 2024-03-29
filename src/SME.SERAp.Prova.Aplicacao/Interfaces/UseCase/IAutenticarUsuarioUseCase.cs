﻿using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IAutenticarUsuarioUseCase
    {
        Task<UsuarioAutenticacaoDto> Executar(AutenticacaoDto autenticacaoDto);
    }
}
