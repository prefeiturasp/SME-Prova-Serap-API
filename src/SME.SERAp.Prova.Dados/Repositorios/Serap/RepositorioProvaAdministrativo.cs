using SME.SERAp.Prova.Infra.Dtos;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioProvaAdministrativo : RepositorioBase<Dominio.Prova>, IRepositorioProvaAdministrativo
    {
        public RepositorioProvaAdministrativo(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {
        }

        public async Task<PaginacaoResultadoDto<Dominio.Prova>> ObterProvasPaginada(ProvaAdmFiltroDto provaAdmFiltroDto, bool inicioFuturo)
        {
            using var conn = ObterConexaoLeitura();
            var retorno = new PaginacaoResultadoDto<Dominio.Prova>();
            try
            {
                var where = new StringBuilder(" where 1 = 1");
                if (!inicioFuturo)
                    where.Append(" and p.inicio <= now()");

                if (provaAdmFiltroDto.ProvaLegadoId.HasValue)
                    where.Append(" and p.prova_legado_id = @provaLegadoId");

                if (provaAdmFiltroDto.Modalidade.HasValue)
                    where.Append(" and p.modalidade = @modalidade");

                if (!string.IsNullOrWhiteSpace(provaAdmFiltroDto.Ano))
                    where.Append(" and exists(select 1 from prova_ano pa where pa.prova_id = p.id and pa.ano = @ano limit 1)");

                if (!string.IsNullOrWhiteSpace(provaAdmFiltroDto.Descricao))
                {
                    provaAdmFiltroDto.Descricao = $"%{provaAdmFiltroDto.Descricao.ToUpper()}%";
                    where.Append(" and upper(p.descricao) like @descricao");
                }

                var query = new StringBuilder();
                query.AppendFormat("select * from prova p {0} ", where.ToString());
                query.Append("order by p.inclusao desc, p.descricao asc ");
                query.Append("limit @quantidadeRegistros offset(@numeroPagina - 1) * @quantidadeRegistros; ");

                query.AppendFormat("select count(*) from prova p {0}; ", where.ToString());

                using (var multi = await conn.QueryMultipleAsync(query.ToString(), provaAdmFiltroDto))
                {
                    retorno.Items = multi.Read<Dominio.Prova>().ToList();
                    retorno.TotalRegistros = multi.ReadFirst<int>();
                }

                retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / provaAdmFiltroDto.QuantidadeRegistros);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return retorno;
        }
    }
}
