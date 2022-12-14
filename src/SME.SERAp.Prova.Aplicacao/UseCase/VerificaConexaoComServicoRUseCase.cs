using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.Aluno;
using SME.SERAp.Prova.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class VerificaConexaoComServicoRUseCase : AbstractUseCase , IVerificaConexaoComServicoRUseCase
    {
        private readonly IServicoLog servicoLog;
        public VerificaConexaoComServicoRUseCase(IMediator mediator, IServicoLog servicoLog) : base(mediator)
        {
            this.servicoLog = servicoLog ?? throw new ArgumentNullException(nameof(servicoLog));
        }

        public async Task<bool> Executar()
        {
            return await mediator.Send(new TesteConexaoApiRQuery());
        }
    }
}
