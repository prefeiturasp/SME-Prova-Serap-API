﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dados.Cache;
using SME.SERAp.Prova.Dados.Interfaces;
using SME.SERAp.Prova.Dados.Repositorios.Eol;
using SME.SERAp.Prova.Infra.Interfaces;
using SME.SERAp.Prova.Infra.Services;

namespace SME.SERAp.Prova.IoC
{
    public static class RegistraDependencias
    {
        public static void Registrar(IServiceCollection services)
        {
            services.AdicionarMediatr();
            services.AdicionarValidadoresFluentValidation();

            RegistrarRepositorios(services);
            RegistrarServicos(services);
            RegistrarCasosDeUso(services);
            RegistrarMapeamentos.Registrar();
        }


        private static void RegistrarRepositorios(IServiceCollection services)
        {
            services.TryAddScoped<IRepositorioCache, RepositorioCache>();
            services.TryAddScoped<IRepositorioAluno, RepositorioAluno>();
        }

        private static void RegistrarServicos(IServiceCollection services)
        {
            services.TryAddScoped<IServicoLog, ServicoLog>();
        }

        private static void RegistrarCasosDeUso(IServiceCollection services)
        {
            services.TryAddScoped<IObterVersaoApiUseCase, ObterVersaoApiUseCase>();
            services.TryAddScoped<IObterVersaoFrontUseCase, ObterVersaoFrontUseCase>();
            services.TryAddScoped<IAutenticarUsuarioUseCase, AutenticarUsuarioUseCase>();
            services.TryAddScoped<IRevalidaTokenJwtUseCase, RevalidaTokenJwtUseCase>();
            services.TryAddScoped<IObterMeusDadosUseCase, ObterMeusDadosUseCase>();
            services.TryAddScoped<IObterProvasAreaEstudanteUseCase, ObterProvasAreaEstudanteUseCase>();            
        }
    }
}
