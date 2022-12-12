using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Aplicacao.UseCase;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dados.Cache;
using SME.SERAp.Prova.Dados.Interfaces;
using SME.SERAp.Prova.Dados.Repositorios.Serap;
using SME.SERAp.Prova.Infra;
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
            RegistraMapeamentos.Registrar();
        }

        private static void RegistrarRepositorios(IServiceCollection services)
        {
            services.TryAddScoped<IRepositorioCache, RepositorioCache>();
            services.TryAddScoped<IRepositorioAluno, RepositorioAluno>();
            services.TryAddScoped<IRepositorioProva, RepositorioProva>();
            services.TryAddScoped<IRepositorioQuestao, RepositorioQuestao>();
            services.TryAddScoped<IRepositorioAlternativa, RepositorioAlternativa>();
            services.TryAddScoped<IRepositorioArquivo, RepositorioArquivo>();
            services.TryAddScoped<IRepositorioUsuarioDispositivo, RepositorioUsuarioDispositivo>();
            services.TryAddScoped<IRepositorioQuestaoAlunoResposta, RepositorioQuestaoAlunoResposta>();
            services.TryAddScoped<IRepositorioProvaAluno, RepositorioProvaAluno>();
            services.TryAddScoped<IRepositorioParametroSistema, RepositorioParametroSistema>();
            services.TryAddScoped<IRepositorioTelaBoasVindas, RepositorioTelaBoasVindas>();
            services.TryAddScoped<IRepositorioUsuario, RepositorioUsuario>();
            services.TryAddScoped<IRepositorioPreferenciasUsuario, RepositorioPreferenciasUsuario>();
            services.TryAddScoped<IRepositorioCadernoAluno, RepositorioCadernoAluno>();
            services.TryAddScoped<IRepositorioQuestaoArquivo, RepositorioQuestaoArquivo>();
            services.TryAddScoped<IRepositorioContextoProva, RepositorioContextoProva>();
            services.TryAddScoped<IRepositorioDownloadProvaAluno, RepositorioDownloadProvaAluno>();
            services.TryAddScoped<IRepositorioExportacaoResultado, RepositorioExportacaoResultado>();
            services.TryAddScoped<IRepositorioTurma, RepositorioTurma>();
            services.TryAddScoped<IRepositorioTipoDeficiencia, RepositorioTipoDeficiencia>();
            services.TryAddScoped<IRepositorioQuestaoVideo, RepositorioQuestaoVideo>();
            services.TryAddScoped<IRepositorioUsuarioSerapCoreSSO, RepositorioUsuarioSerapCoreSSO>();
            services.TryAddScoped<IRepositorioVersaoApp, RepositorioVersaoApp>();
            services.TryAddScoped<IRepositorioPropagacaoCache, RepositorioPropagacaoCache>();
            services.TryAddScoped<IRepositorioVersaoAppDispositivo, RepositorioVersaoAppDispositivo>();
            services.TryAddScoped<IRepositorioAlunoProvaProficiencia, RepositorioAlunoProvaProficiencia>();


            services.TryAddScoped<IObterAlternativaPorIdUseCase, ObterAlternativaPorIdUseCase>();
            services.TryAddScoped<IObterArquivoAudioPorIdUseCase, ObterArquivoAudioPorIdUseCase>();
            services.TryAddScoped<IObterArquivoPorIdLegadoUseCase, ObterArquivoPorIdLegadoUseCase>();
            services.TryAddScoped<IObterArquivoPorIdUseCase, ObterArquivoPorIdUseCase>();
            services.TryAddScoped<IObterArquivoVideoPorIdUseCase, ObterArquivoVideoPorIdUseCase>();
            services.TryAddScoped<IObterQuestaoPorIdUseCase, ObterQuestaoPorIdUseCase>();
        }

        private static void RegistrarServicos(IServiceCollection services)
        {
            services.TryAddScoped<IServicoTelemetria, ServicoTelemetria>();
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
            services.TryAddScoped<IObterProvaDetalhesResumidoUseCase, ObterProvaDetalhesResumidoUseCase>();
            services.TryAddScoped<IObterTelasBoasVindasUseCase, ObterTelasBoasVindasUseCase>();
            services.TryAddScoped<IIncluirProvaAlunoUseCase, IncluirProvaAlunoUseCase>();
            services.TryAddScoped<IObterQuestaoAlunoRespostaPorQuestaoIdUseCase, ObterQuestaoAlunoRespostaPorQuestaoIdUseCase>();
            services.TryAddScoped<IObterRespostasAlunoPorProvaIdUseCase, ObterRespostasAlunoPorProvaIdUseCase>();
            services.TryAddScoped<IObterProvaAlunoUseCase, ObterProvaAlunoUseCase>();
            services.TryAddScoped<IIncluirPreferenciasUsuarioUseCase, IncluirPreferenciasUsuarioUseCase>();
            services.TryAddScoped<IObterContextoProvaPorIdUseCase, ObterContextoProvaPorIdUseCase>();
            services.TryAddScoped<IObterContextosProvasPorProvaIdUseCase, ObterContextosProvasPorProvaIdUseCase>();
            services.TryAddScoped<ISincronizarQuestaoAlunoRespostaUseCase, SincronizarQuestaoAlunoRespostaUseCase>();
            services.TryAddScoped<IPropagacaoCacheUseCase, PropagacaoCacheUseCase>();
            services.TryAddScoped<IIncluirDownloadProvaAlunoUseCase, IncluirDownloadProvaAlunoUseCase>();
            services.TryAddScoped<IExcluirDownloadProvaAlunoUseCase, ExcluirDownloadProvaAlunoUseCase>();
            services.TryAddScoped<IObterProvasAnterioresAreaEstudanteUseCase, ObterProvasAnterioresAreaEstudanteUseCase>();
            services.TryAddScoped<IObterExportacaoResultadoStatusUseCase, ObterExportacaoResultadoStatusUseCase>();
            services.TryAddScoped<ISolicitarExportacaoResultadoUseCase, SolicitarExportacaoResultadoUseCase>();
            services.TryAddScoped<IObterExportacaoResultadoProvasPorDataUseCase, ObterExportacaoResultadoProvasPorDataUseCase>();
            services.TryAddScoped<IDownloadArquivoResultadoProvaUseCase, DownloadArquivoResultadoProvaUseCase>();
            services.TryAddScoped<IAutenticarUsuarioAdmUseCase, AutenticarUsuarioAdmUseCase>();
            services.TryAddScoped<IPotenciacaoRUseCase, PotenciacaoRUseCase>();
            services.TryAddScoped<IObterProvaAreaAdministrativoUseCase, ObterProvaAreaAdministrativoUseCase>();
            services.TryAddScoped<IObterProvaResumoAreaAdministrativoUseCase, ObterProvaResumoAreaAdministrativoUseCase>();
            services.TryAddScoped<IObterProvaCadernosAreaAdministrativoUseCase, ObterProvaCadernosAreaAdministrativoUseCase>();
            services.TryAddScoped<IObterQuestaoDetalhesResumidoAreaAdministrativoUseCase, ObterQuestaoDetalhesResumidoAreaAdministrativoUseCase>();
            services.TryAddScoped<IObterVersaoAppUseCase, ObterVersaoAppUseCase>();
            services.TryAddScoped<IAutenticarUsuarioValidarAdmUseCase, AutenticarUsuarioValidarAdmUseCase>();
            services.TryAddScoped<IRevalidaTokenJwtAdmUseCase, RevalidaTokenJwtAdmUseCase>();
            services.TryAddScoped<IIncluirVersaoAppDispositivoUseCase, IncluirVersaoAppDispositivoUseCase>();
            services.TryAddScoped<IObterQuestoesCompletaPorIdsUseCase, ObterQuestoesCompletaPorIdsUseCase>();
            services.TryAddScoped<IObterQuestoesCompletaPorLegadoIdsUseCase, ObterQuestoesCompletaPorLegadoIdsUseCase>();
            services.TryAddScoped<IObterProvaDetalhesResumidoCadernoUseCase, ObterProvaDetalhesResumidoCadernoUseCase>();
            services.TryAddScoped<IReabrirProvaAlunoUseCase, ReabrirProvaAlunoUseCase>();
            services.TryAddScoped<IImagemLogUseCase, ImagemLogUseCase>();
            services.TryAddScoped<IObterDataHoraServidorUseCase, ObterDataHoraServidorUseCase>();
            services.TryAddScoped<IObterProvaResultadoResumoUseCase, ObterProvaResultadoResumoUseCase>();
            services.TryAddScoped<IObterQuestaoCompletaResultadoUseCase, ObterQuestaoCompletaResultadoUseCase>();
            services.TryAddScoped<IIniciarProvaTaiUseCase, IniciarProvaTaiUseCase>();
            services.TryAddScoped<IObterQuestaoProvaTaiUseCase, ObterQuestaoProvaTaiUseCase>();
            services.TryAddScoped<IFinalizarProvaTaiUseCase, FinalizarProvaTaiUseCase>();
        }
    }
}
