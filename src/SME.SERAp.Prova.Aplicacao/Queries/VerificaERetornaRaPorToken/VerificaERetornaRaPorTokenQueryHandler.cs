using MediatR;
using Microsoft.IdentityModel.Tokens;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using SME.SERAp.Prova.Infra.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class VerificaERetornaRaPorTokenQueryHandler : IRequestHandler<VerificaERetornaRaPorTokenQuery, long>
    {
        private readonly JwtOptions jwtOptions;

        public VerificaERetornaRaPorTokenQueryHandler(JwtOptions jwtOptions)
        {
            this.jwtOptions = jwtOptions ?? throw new System.ArgumentNullException(nameof(jwtOptions));
        }
        public async Task<long> Handle(VerificaERetornaRaPorTokenQuery request, CancellationToken cancellationToken)
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
                if (validator.CanReadToken(request.Token))
                {
                    ClaimsPrincipal principal;
                    principal = validator.ValidateToken(request.Token, validationParameters, out SecurityToken validatedToken);

                    if (principal.HasClaim(c => c.Type == "RA"))
                    {
                        return await Task.FromResult(long.Parse(principal.Claims.FirstOrDefault(c => c.Type == "RA").Value));
                    }
                    else throw new NaoAutorizadoException("Token inválido");
                }
                else throw new NaoAutorizadoException("Token inválido");
            }
            catch (System.Exception)
            {

                throw new NaoAutorizadoException("Token inválido");
            }
        }
    }
}
