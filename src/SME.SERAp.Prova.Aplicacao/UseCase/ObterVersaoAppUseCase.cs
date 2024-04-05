using MediatR;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterVersaoAppUseCase : IObterVersaoAppUseCase
    {
        private readonly IMediator mediator;

        public ObterVersaoAppUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<VersaoAppDto> Executar()
        {
            var versaoAppDominio = await mediator.Send(new ObterUltimaVersaoAppQuery());

            var versaoAppDto = new VersaoAppDto();

            versaoAppDto.versionCode = versaoAppDominio.Codigo;
            versaoAppDto.versionName = versaoAppDominio.Descricao;
            versaoAppDto.contentText = versaoAppDominio.Mensagem;
            versaoAppDto.minSupport = versaoAppDominio.SuporteMinimo;
            versaoAppDto.url = versaoAppDominio.Url;

            return versaoAppDto;
        }
    }
}
