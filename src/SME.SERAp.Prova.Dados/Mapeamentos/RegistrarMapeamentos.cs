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
                config.AddMap(new UsuarioDispositivoMap());
                config.AddMap(new QuestaoMap());
                config.AddMap(new AlternativasMap());
                config.AddMap(new ArquivoMap());
                config.AddMap(new QuestaoAlunoRespostaMap());
                config.AddMap(new ProvaAlunoMap());
                config.AddMap(new ParametroSistemaMap());
                config.AddMap(new TelaBoasVindasMap());
                config.ForDommel();
            });
        }
    }
}
