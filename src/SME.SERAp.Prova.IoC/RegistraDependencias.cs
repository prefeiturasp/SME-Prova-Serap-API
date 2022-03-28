using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Aplicacao.UseCase;
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
            RegistraMapeamentos.Registrar();
        }


        private static void RegistrarRepositorios(IServiceCollection services)
        {
            services.TryAddScoped<IRepositorioCache, RepositorioCache>();
            services.TryAddScoped<IRepositorioAlunoEol, RepositorioAlunoEol>();
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
            services.TryAddScoped<IObterProvaDetalhesResumidoUseCase, ObterProvaDetalhesResumidoUseCase>();
            services.TryAddScoped<IObterQuestaoPorIdUseCase, ObterQuestaoPorIdUseCase>();
            services.TryAddScoped<IObterTelasBoasVindasUseCase, ObterTelasBoasVindasUseCase>();
            services.TryAddScoped<IObterAlternativaPorIdUseCase, ObterAlternativaPorIdUseCase>();
            services.TryAddScoped<IObterArquivoPorIdUseCase, ObterArquivoPorIdUseCase>();
            services.TryAddScoped<IObterArquivoPorIdLegadoUseCase, ObterArquivoPorIdLegadoUseCase>();
            services.TryAddScoped<IIncluirQuestaoAlunoRespostaUseCase, IncluirQuestaoAlunoRespostaUseCase>();
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
            services.TryAddScoped<IObterArquivoAudioPorIdUseCase, ObterArquivoAudioPorIdUseCase>();
            services.TryAddScoped<IPotenciacaoRUseCase, PotenciacaoRUseCase>();
            services.TryAddScoped<IObterArquivoVideoPorIdUseCase, ObterArquivoVideoPorIdUseCase>();
        }
    }
}
