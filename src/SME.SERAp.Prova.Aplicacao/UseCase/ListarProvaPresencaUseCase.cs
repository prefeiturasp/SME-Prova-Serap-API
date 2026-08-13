using MediatR;
using SME.SERAp.Prova.Aplicacao.Interfaces.UseCase;
using SME.SERAp.Prova.Aplicacao.Queries.ObterListaProvaPresenca;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.Dtos.ProvaPresenca;
using SME.SERAp.Prova.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class ListarProvaPresencaUseCase : AbstractUseCase, IListarProvaPresencaUseCase
    {
        private readonly IServicoLog servicoLog;

        public ListarProvaPresencaUseCase(IMediator mediator, IServicoLog servicoLog) : base(mediator)
        {
            this.servicoLog = servicoLog ?? throw new ArgumentNullException(nameof(servicoLog));
        }

        public async Task<IEnumerable<ListarProvaPresencaDto>> Executar()
        {
            try
            {
                var provasPresenca = await mediator.Send(new ObterListaProvaPresencaQuery());

                servicoLog.Registrar(LogNivel.Informacao, $"Lista de Provas de Presença obtida com sucesso. Total: {provasPresenca?.Count() ?? 0} provas.", string.Empty, string.Empty);
                return provasPresenca;
            }
            catch (Exception ex)
            {
                servicoLog.Registrar(LogNivel.Critico, $"Erro ao listar Provas de Presença: {ex.Message}", string.Empty, ex.StackTrace);
                throw;
            }
        }
    }
}