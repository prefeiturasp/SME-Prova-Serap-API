using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioCadernoAluno : IRepositorioBase<Dominio.CadernoAluno>
    {
        Task<bool> ExisteCadernoAlunoPorProvaIdAlunoId(long provaId, long alunoId);
    }
}
