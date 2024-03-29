﻿using MediatR;
using Microsoft.IdentityModel.Tokens;
using SME.SERAp.Prova.Infra;
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
    public class VerificaERetornaInformacoesPorTokenQueryHandler : IRequestHandler<VerificaERetornaInformacoesPorTokenQuery, InformacoesTokenDto>
    {
        private readonly JwtOptions jwtOptions;

        public VerificaERetornaInformacoesPorTokenQueryHandler(JwtOptions jwtOptions)
        {
            this.jwtOptions = jwtOptions ?? throw new System.ArgumentNullException(nameof(jwtOptions));
        }
        public async Task<InformacoesTokenDto> Handle(VerificaERetornaInformacoesPorTokenQuery request, CancellationToken cancellationToken)
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

                    if (principal.HasClaim(c => c.Type == "RA") && principal.HasClaim(c => c.Type == "ANO") && principal.HasClaim(c => c.Type == "TIPOTURNO") && principal.HasClaim(c => c.Type == "MODALIDADE"))
                    {
                        var ra = long.Parse(principal.Claims.FirstOrDefault(c => c.Type == "RA").Value);
                        var ano = principal.Claims.FirstOrDefault(c => c.Type == "ANO").Value;
                        var tipoTurno = int.Parse(principal.Claims.FirstOrDefault(c => c.Type == "TIPOTURNO").Value);
                        var modalidade = int.Parse(principal.Claims.FirstOrDefault(c => c.Type == "MODALIDADE").Value);
                        var dispositivo = principal.HasClaim(c => c.Type == "DISPOSITIVO_ID") ? principal.Claims.FirstOrDefault(c => c.Type == "DISPOSITIVO_ID").Value : string.Empty;
                        return await Task.FromResult(new InformacoesTokenDto(ra, ano, tipoTurno, modalidade, dispositivo));
                    }
                    else throw new NaoAutorizadoException("Token inválido");
                }
                else throw new NaoAutorizadoException("Token inválido");
            }
            catch (SecurityTokenException)
            {
                throw new NaoAutorizadoException("Token inválido");
            }
        }
    }
}
