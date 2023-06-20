using SME.SERAp.Prova.Infra;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IObterDataUltimaSincronizacaoProvasUseCase
    {
        public Task<long> Executar();
    }
}
