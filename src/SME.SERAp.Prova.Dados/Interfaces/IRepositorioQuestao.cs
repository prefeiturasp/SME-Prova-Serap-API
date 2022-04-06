﻿using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public interface IRepositorioQuestao : IRepositorioBase<Questao>
    {
        Task<Questao> ObterPorIdLegadoAsync(long id);
        Task<bool> RemoverPorProvaIdAsync(long provaId);
        Task<Questao> ObterPorArquivoAudioIdAsync(long arquivoAudioId);
        Task<IEnumerable<Questao>> ObterQuestoesPorProvaIdAsync(long provaId);
        Task<IEnumerable<Questao>> ObterQuestoesPorProvaIdCadernoAsync(long provaId, string caderno);
        Task<IEnumerable<QuestaoDetalheResumoDadosDto>> ObterDetalhesResumoPorIdAsync(long provaId, long id);
        Task<IEnumerable<ProvaCadernoDadoDto>> ObterCadernosPorProvaId(long provaId);
    }
}
