using SME.SERAp.Prova.Dominio.Entidades;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados.Interfaces
{
    public interface IRepositorioArquivoResultadoPsp
    {
        public Task<ArquivoResultadoPspDto> ObterArquivoResultadoPspPorId(long id);
    }
}
