﻿using Dapper;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
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
            using var conn = ObterConexao();
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
            using var conn = ObterConexao();
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
            using var conn = ObterConexao();
            try
            {
                var query = @"select
	                            q.id  as questaoId,
	                            alt.id as alternativaId,
	                            arq.legado_id as arquivoId,
	                            arq.tamanho_bytes as arquivoTamanho		
                            from
	                            prova p
                            inner join questao q on
	                            q.prova_id = p.id
                            left join alternativa alt on
	                            alt.questao_id = q.id
                            left join questao_arquivo qa on
	                            qa.questao_id = q.id
                            left join arquivo arq on
	                            qa.arquivo_id = arq.id
                            where
	                            p.id = @id";

                return await conn.QueryAsync<ProvaDetalheResumidoBaseDadosDto>(query, new { id });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<ProvaDetalheResumidoBaseDadosDto>> ObterDetalhesResumoBIBPorIdERaAsync(long provaId, long alunoRA)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"select
	                            q.id  as questaoId,
	                            alt.id as alternativaId,
	                            arq.legado_id as arquivoId,
	                            arq.tamanho_bytes as arquivoTamanho		
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

                return await conn.QueryAsync<ProvaDetalheResumidoBaseDadosDto>(query, new { provaId, alunoRA });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
