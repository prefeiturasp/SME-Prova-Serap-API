using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IIncluirQuestaoAlunoRespostaUseCase
    {
        Task<bool> Executar(long questaoId, long? alternativaId, string resposta, DateTime horaResposta, int tempoRespostaAluno);
    }
}
