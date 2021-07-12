using Microsoft.Extensions.DependencyInjection;
using SME.SERAp.Prova.Dados;

namespace SME.SERAp.Prova.IoC
{
    public static class RegistraDependencias
    {
        public static void Registrar(IServiceCollection services)
        {
            services.AdicionarMediatr();
            services.AdicionarValidadoresFluentValidation();

            RegistrarRepositorios(services);
            RegistrarContextos(services);
            RegistrarComandos(services);
            RegistrarConsultas(services);
            RegistrarServicos(services);
            RegistrarCasosDeUso(services);
            RegistrarMapeamentos.Registrar();
        }

        private static void RegistrarComandos(IServiceCollection services)
        {

        }

        private static void RegistrarConsultas(IServiceCollection services)
        {

        }

        private static void RegistrarContextos(IServiceCollection services)
        {
            //services.TryAddScoped<IContextoAplicacao, ContextoHttp>();
            //services.TryAddScoped<ISgpContext, SgpContext>();
            //services.TryAddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void RegistrarRepositorios(IServiceCollection services)
        {

        }

        private static void RegistrarServicos(IServiceCollection services)
        {

        }

        private static void RegistrarCasosDeUso(IServiceCollection services)
        {

        }
    }
}
