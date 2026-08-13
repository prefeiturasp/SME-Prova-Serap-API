using MediatR;
using SME.SERAp.Prova.Aplicacao.Interfaces.UseCase;
using SME.SERAp.Prova.Aplicacao.Queries.ObterProvaPresencaPorId;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.Dtos.ProvaPresenca;
using SME.SERAp.Prova.Infra.Interfaces;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class ObterProvaPresencaPorIdUseCase : AbstractUseCase, IObterProvaPresencaPorIdUseCase
    {
        private readonly IServicoLog servicoLog;

        public ObterProvaPresencaPorIdUseCase(IMediator mediator, IServicoLog servicoLog) : base(mediator)
        {
            this.servicoLog = servicoLog ?? throw new ArgumentNullException(nameof(servicoLog));
        }

        public async Task<ListarProvaPresencaDto> Executar(long id)
        {
            try
            {
                var provaPresenca = await mediator.Send(new ObterProvaPresencaPorIdQuery(id));

                if (provaPresenca == null)
                {
                    servicoLog.Registrar(LogNivel.Informacao, $"Prova de Presença com ID {id} não encontrada.", string.Empty, string.Empty);
                }
                else
                {
                    servicoLog.Registrar(LogNivel.Informacao, $"Prova de Presença com ID {id} obtida com sucesso.", string.Empty, string.Empty);
                }
                return provaPresenca;
            }
            catch (Exception ex)
            {
                servicoLog.Registrar(LogNivel.Critico, $"Erro ao obter Prova de Presença com ID {id}: {ex.Message}", string.Empty, ex.StackTrace);
                throw;
            }
        }
    }
}