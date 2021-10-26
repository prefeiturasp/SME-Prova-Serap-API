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
            var usuario = await mediator.Send(new ObterUsuarioPorLoginQuery(alunoRa));
            if (usuario == null)
                throw new NegocioException("Usuário não encontrado");
            
            var preferenciasUsuario = await mediator.Send(new ObterPreferenciasUsuarioPorLoginQuery(alunoRa));

            if (preferenciasUsuario == null)
            {
                
                return await mediator.Send(new IncluirPreferenciasUsuarioCommand(dto.TamanhoFonte,
                    (FamiliaFonte) dto.FamiliaFonte, usuario.Id));
            }
            else
            {
                preferenciasUsuario.FamiliaFonte = (FamiliaFonte) dto.FamiliaFonte;
                preferenciasUsuario.TamanhoFonte = dto.TamanhoFonte;

                return await mediator.Send(new AtualizarPreferenciasUsuarioCommand(preferenciasUsuario));
            }
        }
    }
}