using Dapper;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioProva : RepositorioBase<Dominio.Prova>, IRepositorioProva
    {
        public RepositorioProva(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {

        }

        public async Task<IEnumerable<Dominio.Prova>> ObterPorAnoData(int ano, System.DateTime dataReferenia)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select distinct p.* from prova p 
                                inner join prova_ano pa 
                                on pa.prova_id = p.id 
                                where @dataReferenia between p.inicio_download and p.fim 
                                and pa.ano = @ano";

                return await conn.QueryAsync<Dominio.Prova>(query, new { ano = ano.ToString(), dataReferenia });
            }            
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<Dominio.Prova> ObterPorIdLegadoAsync(long id)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select * from prova where prova_legado_id = @id";

                return await conn.QueryFirstOrDefaultAsync<Dominio.Prova>(query, new { id });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public async Task<IEnumerable<ProvaDetalheResumidoBaseDadosDto>> ObterDetalhesResumoPorIdAsync(long id)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select
	                            questaoId,
	                            alternativaId,
	                            questaoArquivoId,
                                questaoArquivoTamanho,
                                alternativaArquivoId,
                                alternativaArquivoTamanho	
                            from
	                            v_prova_detalhes p
                            where
	                            p.provaId = @id";

                return await conn.QueryAsync<ProvaDetalheResumidoBaseDadosDto>(query, new { id });
            }
            catch(Exception ex )
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<ProvaDetalheResumidoBaseDadosDto>> ObterDetalhesResumoBIBPorIdERaAsync(long provaId, long alunoRA)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select
	                            questaoId,
	                            alternativaId,
	                            questaoArquivoId,
                                questaoArquivoTamanho,
                                alternativaArquivoId,
                                alternativaArquivoTamanho
                            from
	                            v_prova_bib_detalhes p
                            where
	                            p.provaId = @provaId and p.alunoRa = @alunoRA;";

                return await conn.QueryAsync<ProvaDetalheResumidoBaseDadosDto>(query, new { provaId, alunoRA });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<Dominio.Prova>> ObterPorAnoDataEModalidade(string ano, System.DateTime dataReferenia, int modalidade)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select distinct p.* from prova p 
                                inner join prova_ano pa 
                                on pa.prova_id = p.id 
                                where @dataReferenia between p.inicio_download and p.fim 
                                and pa.ano = @ano and p.modalidade = @modalidade";

                return await conn.QueryAsync<Dominio.Prova>(query, new { ano, dataReferenia, modalidade });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public async Task<IEnumerable<ProvaAnoDto>> ObterAnosDatasEModalidadesAsync()
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select
	                            p.descricao,
	                            p.Id,
	                            p.total_Itens totalItens,
	                            p.inicio_download as InicioDownload,
	                            p.inicio,
	                            p.fim,
	                            p.Tempo_Execucao TempoExecucao,
	                            p.Modalidade,
	                            p.Senha,
	                            p.possui_bib PossuiBIB,
	                            pa.ano
                            from
	                            prova p
                            inner join prova_ano pa 
                                on pa.prova_id = p.id
                             where (p.ocultar_prova = false or ocultar_prova is null)";

                return await conn.QueryAsync<ProvaAnoDto>(query);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public async Task<string> ObterCadernoAlunoPorProvaIdRa(long provaId, long alunoRA)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select
	                            distinct ca.caderno		
                            from
	                            prova p
                            inner join caderno_aluno ca on 
                                p.id = ca.prova_id
                            inner join aluno a on 
                                ca.aluno_id = a.id
                            inner join questao q on
	                            q.prova_id = p.id and ca.caderno = q.caderno
                            left join alternativa alt on
	                            alt.questao_id = q.id
                            left join questao_arquivo qa on
	                            qa.questao_id = q.id
                            left join arquivo arq on
	                            qa.arquivo_id = arq.id
                            where
	                            p.id = @provaId and a.ra = @alunoRA ";

                return await conn.QueryFirstOrDefaultAsync<string>(query, new { provaId, alunoRA });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<Dominio.Prova>> ObterTodasParaCacheAsync()
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select * from prova";

                return await conn.QueryAsync<Dominio.Prova>(query);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
