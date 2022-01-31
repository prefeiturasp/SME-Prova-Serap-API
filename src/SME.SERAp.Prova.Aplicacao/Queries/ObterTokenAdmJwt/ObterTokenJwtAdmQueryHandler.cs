using MediatR;
using Microsoft.IdentityModel.Tokens;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterTokenJwtAdmQueryHandler : IRequestHandler<ObterTokenJwtAdmQuery, (string, DateTime)>
    {
        private readonly JwtOptions jwtOptions;
        public ObterTokenJwtAdmQueryHandler(JwtOptions jwtOptions)
        {
            this.jwtOptions = jwtOptions ?? throw new ArgumentNullException(nameof(jwtOptions));
        }

        public async Task<(string, DateTime)> Handle(ObterTokenJwtAdmQuery request, CancellationToken cancellationToken)
        {
            var now = DateTime.Now;
            IList<Claim> claims = new List<Claim>();

            claims.Add(new Claim("Login", request.Login.ToString()));
            claims.Add(new Claim("Perfil", request.Perfil.ToString()));
          
            var dataHoraExpiracao = now.AddMinutes(double.Parse(jwtOptions.ExpiresInMinutes));

            var token = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                notBefore: now,
                claims: claims,
                expires: dataHoraExpiracao,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        System.Text.Encoding.UTF8.GetBytes(jwtOptions.IssuerSigningKey)),
                        SecurityAlgorithms.HmacSha256)
                );

            var tokenGerado = new JwtSecurityTokenHandler()
                      .WriteToken(token);


            return await Task.FromResult((tokenGerado, dataHoraExpiracao));
        }
    }
}
