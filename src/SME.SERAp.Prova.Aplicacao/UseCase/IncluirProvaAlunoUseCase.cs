using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirProvaAlunoUseCase : IIncluirProvaAlunoUseCase
    {
        private readonly IMediator mediator;

        public IncluirProvaAlunoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<bool> Executar(long provaId, ProvaAlunoStatusDto provaAlunoStatusDto)
        {
            var alunoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());

            var provaStatus = await mediator.Send(new ObterProvaAlunoPorProvaIdRaQuery(provaId, alunoRa));

            if (provaStatus == null)
            {
                return await mediator.Send(new IncluirProvaAlunoCommand(provaId, alunoRa, (ProvaStatus)provaAlunoStatusDto.Status, 
                    provaAlunoStatusDto.DataInicio != null && provaAlunoStatusDto.DataInicio != 0 ? new DateTime(provaAlunoStatusDto.DataInicio.Value) : DateTime.Now, provaAlunoStatusDto.DataFim != null && provaAlunoStatusDto.DataFim != 0   ? new DateTime(provaAlunoStatusDto.DataFim.Value) : null));
            }
            else
            {
                if (provaStatus.Status == Dominio.ProvaStatus.Finalizado)
                    throw new NegocioException("Esta prova já foi finalizada", 411);

                provaStatus.TipoDispositivo = provaAlunoStatusDto.TipoDispositivo.HasValue ? (TipoDispositivo)provaAlunoStatusDto.TipoDispositivo : TipoDispositivo.NaoCadastrado;
                provaStatus.Status = (ProvaStatus)provaAlunoStatusDto.Status;
                if((ProvaStatus)provaAlunoStatusDto.Status == ProvaStatus.Finalizado)
                    provaStatus.FinalizadoEm = provaAlunoStatusDto.DataFim != null ? new DateTime(provaAlunoStatusDto.DataFim.Value) : DateTime.Now;

                return await mediator.Send(new AtualizarProvaAlunoCommand(provaStatus));
            }

        }
    }
}
