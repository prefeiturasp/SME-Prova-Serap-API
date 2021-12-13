using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
   public class ExcluirDownloadProvaAlunoUseCase : AbstractUseCase, IExcluirDownloadProvaAlunoUseCase
    {
        private readonly IMediator mediator;
        public ExcluirDownloadProvaAlunoUseCase(IMediator mediator) : base(mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(int[] ids)
        {
            return await mediator.Send(new ExcluirDownloadsProvaAlunoCommand(ids));
        }
    }
  
}
