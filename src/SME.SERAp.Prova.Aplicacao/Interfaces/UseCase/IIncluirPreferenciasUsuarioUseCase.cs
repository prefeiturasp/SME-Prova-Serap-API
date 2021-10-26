using SME.SERAp.Prova.Infra;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IIncluirPreferenciasUsuarioUseCase
    {
        Task<bool> Executar(PreferenciaUsuarioDto dto);
    }
}
