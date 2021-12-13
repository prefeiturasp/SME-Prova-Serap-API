using MediatR;
using SME.SERAp.Prova.Dominio.Enumerados;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class IncluirDownloadProvaAlunoUseCase : AbstractUseCase, IIncluirDownloadProvaAlunoUseCase
    {
        private readonly IMediator mediator;
        public IncluirDownloadProvaAlunoUseCase(IMediator mediator) : base(mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(long provaId, DownloadProvaAlunoDto downloadProvaAlunoDto)
        {
            var alunoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());

            await mediator.Send(new IncluirDownloadProvaCommand(provaId, alunoRa, downloadProvaAlunoDto));

            return true;
        }
    }
}
