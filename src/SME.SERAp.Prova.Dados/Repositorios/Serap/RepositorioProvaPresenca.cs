using Npgsql;
using SME.SERAp.Prova.Dados.Interfaces;
using SME.SERAp.Prova.Infra.Dtos.ProvaPresenca;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados.Repositorios.Serap
{
    public class RepositorioProvaPresenca : IRepositorioProvaPresenca
    {
        private readonly ConnectionStringOptions connectionStrings;

        public RepositorioProvaPresenca(ConnectionStringOptions connectionStrings)
        {
            this.connectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        protected virtual IDbConnection ObterConexaoLeitura()
        {
            var conexao = new NpgsqlConnection(connectionStrings.ApiSerapLeitura);
            conexao.Open();
            return conexao;
        }

        public async Task<bool> ExisteProvaPresencaPorNomeEAno(string nomeProva, int anoProva)
        {
            var query = @"
                            SELECT EXISTS (
                                SELECT 1
                                FROM public.prova_presenca
                                WHERE LOWER(TRIM(nome_prova)) = LOWER(TRIM(@NomeProva))
                                    AND ano_prova = @AnoProva
                            );";

            using var conexao = ObterConexaoLeitura();
            try
            {
                return await conexao.QueryFirstOrDefaultAsync<bool>(query, new { NomeProva = nomeProva, AnoProva = anoProva });
            }
            finally
            {
                conexao.Close();
                conexao.Dispose();
            }
        }

        public async Task<IEnumerable<ListarProvaPresencaDto>> ObterTodasAsync()
        {
            var query = @"
                            SELECT
                                pp.id,
                                pp.nome_prova AS NomeProva,
                                pp.ano_prova AS AnoProva,
                                pp.descricao_prova AS DescricaoProva,
                                pp.data_inicial_aplicacao AS DataInicialAplicacao,
                                pp.data_final_aplicacao AS DataFinalAplicacao,
                                pp.data_corte AS DataCorte,
                                pp.vincula_aluno_caderno_extra AS VinculaAlunoCadernoExtra,
                                pp.data_processamento AS DataProcessamento,
                                ppt.turma_id AS TurmaId
                            FROM public.prova_presenca pp
                            LEFT JOIN public.prova_presenca_turmas ppt ON pp.id = ppt.prova_presenca_id
                            ORDER BY pp.id, ppt.turma_id;";

            using var conexao = ObterConexaoLeitura();
            try
            {
                var dicionario = new Dictionary<long, ListarProvaPresencaDto>();

                await conexao.QueryAsync<ListarProvaPresencaDto, long?, ListarProvaPresencaDto>(
                    query,
                    (prova, turmaId) =>
                    {
                        if (!dicionario.TryGetValue(prova.Id, out var provaEntry))
                        {
                            provaEntry = prova;
                            provaEntry.TurmasIds = new List<long>();
                            dicionario.Add(provaEntry.Id, provaEntry);
                        }

                        if (turmaId.HasValue)
                        {
                            provaEntry.TurmasIds.Add(turmaId.Value);
                        }
                        return provaEntry;
                    },
                    splitOn: "TurmaId");

                return dicionario.Values;
            }
            finally
            {
                conexao.Close();
                conexao.Dispose();
            }
        }

        public async Task<ListarProvaPresencaDto> ObterPorIdAsync(long id)
        {
            var query = @"
                            SELECT
                                pp.id,
                                pp.nome_prova AS NomeProva,
                                pp.ano_prova AS AnoProva,
                                pp.descricao_prova AS DescricaoProva,
                                pp.data_inicial_aplicacao AS DataInicialAplicacao,
                                pp.data_final_aplicacao AS DataFinalAplicacao,
                                pp.data_corte AS DataCorte,
                                pp.vincula_aluno_caderno_extra AS VinculaAlunoCadernoExtra,
                                pp.data_processamento AS DataProcessamento,
                                ppt.turma_id AS TurmaId
                            FROM public.prova_presenca pp
                            LEFT JOIN public.prova_presenca_turmas ppt ON pp.id = ppt.prova_presenca_id
                            WHERE pp.id = @Id
                            ORDER BY ppt.turma_id;";

            using var conexao = ObterConexaoLeitura();
            try
            {
                ListarProvaPresencaDto resultado = null;

                await conexao.QueryAsync<ListarProvaPresencaDto, long?, ListarProvaPresencaDto>(
                    query,
                    (prova, turmaId) =>
                    {
                        if (resultado == null)
                        {
                            resultado = prova;
                            resultado.TurmasIds = new List<long>();
                        }

                        if (turmaId.HasValue)
                        {
                            resultado.TurmasIds.Add(turmaId.Value);
                        }
                        return resultado;
                    },
                    new { Id = id },
                    splitOn: "TurmaId");

                return resultado;
            }
            finally
            {
                conexao.Close();
                conexao.Dispose();
            }
        }
    }
}