using MediatR;
using SME.SERAp.Prova.Infra.Dtos;
using System;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasAdministrativoPaginadaQuery : IRequest<PaginacaoResultadoDto<ProvaAreaAdministrativoRetornoDto>>
    {
        public ObterProvasAdministrativoPaginadaQuery(ProvaAdmFiltroDto filtro, Guid? perfil = null, string login = null)
        {
            Filtro = filtro;
            Perfil = perfil;
            Login = login;
        }

        public ProvaAdmFiltroDto Filtro { get; set; }

        public Guid? Perfil { get; set; }

        public string Login { get; set; }
    }
}
