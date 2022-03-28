using MediatR;
using SME.SERAp.Prova.Infra.Dtos;
using System;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasAdministrativoPaginadaQuery : IRequest<PaginacaoResultadoDto<ProvaAreaAdministrativoRetornoDto>>
    {
        public ObterProvasAdministrativoPaginadaQuery(ProvaAdmFiltroDto filtro, bool inicioFuturo, Guid? perfil = null, string login = null)
        {
            Filtro = filtro;
            InicioFuturo = inicioFuturo;
            Perfil = perfil;
            Login = login;
        }

        public ProvaAdmFiltroDto Filtro { get; set; }

        public bool InicioFuturo { get; set; }

        public Guid? Perfil { get; set; }

        public string Login { get; set; }
    }
}
