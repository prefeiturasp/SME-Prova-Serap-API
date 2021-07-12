using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

namespace SME.SERAp.Prova.Dados
{
    public static class RegistrarMapeamentos
    {
        public static void Registrar()
        {
            FluentMapper.Initialize(config =>
            {
                config.ForDommel();
            });
        }
    }
}
