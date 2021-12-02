using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirPreferenciasUsuarioUseCase : AbstractUseCase, IIncluirPreferenciasUsuarioUseCase
    {
        public IncluirPreferenciasUsuarioUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar(PreferenciaUsuarioDto dto)
        {
            var alunoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());

            var mensagem = new PreferenciaUsuarioRabbitDto(alunoRa, dto.TamanhoFonte, dto.FamiliaFonte);

            var detalhes = await mediator.Send(new ObterDetalhesAlunoCacheQuery(alunoRa));

            if (detalhes != null)
            {
                detalhes.FamiliaFonte = dto.FamiliaFonte;
                detalhes.TamanhoFonte = dto.TamanhoFonte;
                await mediator.Send(new AtualizarPreferenciasAlunoCacheCommand(detalhes, alunoRa));
            }
                
            return await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.IncluirPreferenciasAluno, mensagem));
        }
    }
}