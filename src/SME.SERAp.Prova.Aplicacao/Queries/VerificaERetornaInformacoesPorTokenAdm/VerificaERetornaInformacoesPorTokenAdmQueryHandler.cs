using MediatR;
using Microsoft.IdentityModel.Tokens;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class VerificaERetornaInformacoesPorTokenAdmQueryHandler : IRequestHandler<VerificaERetornaInformacoesPorTokenAdmQuery, InformacoesTokenAdmDto>
    {
        private readonly JwtOptions jwtOptions;

        public VerificaERetornaInformacoesPorTokenAdmQueryHandler(JwtOptions jwtOptions)
        {
            this.jwtOptions = jwtOptions ?? throw new System.ArgumentNullException(nameof(jwtOptions));
        }
        public async Task<InformacoesTokenAdmDto> Handle(VerificaERetornaInformacoesPorTokenAdmQuery request, CancellationToken cancellationToken)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.IssuerSigningKey));
            var validator = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = key,
                ValidIssuer = jwtOptions.Issuer,
                ValidAudience = jwtOptions.Audience,
                ValidateIssuerSigningKey = true,
                ValidateAudience = true,
                ValidateLifetime = false
            };

            try
            {
                if (!validator.CanReadToken(request.Token))
                    throw new NaoAutorizadoException("Token inválido");

                ClaimsPrincipal principal;
                principal = validator.ValidateToken(request.Token, validationParameters, out SecurityToken validatedToken);

                if (!principal.HasClaim(c => c.Type == "LOGIN") ||
                    !principal.HasClaim(c => c.Type == "NOME") ||
                    !principal.HasClaim(c => c.Type == "PERFIL") )
                    throw new NaoAutorizadoException("Token inválido");

                var login = principal.Claims.FirstOrDefault(c => c.Type == "LOGIN").Value;
                var nome = principal.Claims.FirstOrDefault(c => c.Type == "NOME").Value;
                var perfil = Guid.Parse(principal.Claims.FirstOrDefault(c => c.Type == "PERFIL").Value);
                return new InformacoesTokenAdmDto(login, nome, perfil);
            }
            catch (Exception)
            {
                throw new NaoAutorizadoException("Token inválido");
            }
        }
    }
}
