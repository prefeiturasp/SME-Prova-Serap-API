﻿using MediatR;
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
    public class ObterTokenJwtQueryHandler : IRequestHandler<ObterTokenJwtQuery, (string, DateTime)>
    {
        private readonly JwtOptions jwtOptions;

        public ObterTokenJwtQueryHandler(JwtOptions jwtOptions)
        {
            this.jwtOptions = jwtOptions ?? throw new ArgumentNullException(nameof(jwtOptions));
        }
        public async Task<(string, DateTime)> Handle(ObterTokenJwtQuery request, CancellationToken cancellationToken)
        {
            var now = DateTime.Now;
            IList<Claim> claims = new List<Claim>();

            claims.Add(new Claim("RA", request.AlunoRA.ToString()));
            claims.Add(new Claim("ANO", request.AlunoAno.ToString()));
            claims.Add(new Claim("TIPOTURNO", request.AlunoTurno.ToString()));
            claims.Add(new Claim("MODALIDADE", request.AlunoModalidade.ToString()));
            if (!string.IsNullOrEmpty(request.AlunoDispositivoId))
                claims.Add(new Claim("DISPOSITIVO_ID", request.AlunoDispositivoId.ToString()));

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
