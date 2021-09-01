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
                config.AddMap(new ProvaMap());
                config.AddMap(new QuestaoMap());
                config.AddMap(new AlternativasMap());
                config.AddMap(new ArquivoMap());                
                config.ForDommel();
            });
        }
    }
}
