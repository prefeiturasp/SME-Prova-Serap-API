using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvaStatusAlunoQueryHandler : IRequestHandler<ObterProvaStatusAlunoQuery, ProvaAlunoDto>
    {
        private readonly IRepositorioProvaAluno repositorioProvaAluno;
        private readonly IRepositorioCache repositorioCache;

        public ObterProvaStatusAlunoQueryHandler(IRepositorioProvaAluno repositorioProvaAluno, IRepositorioCache repositorioCache)
        {
            this.repositorioProvaAluno = repositorioProvaAluno ?? throw new System.ArgumentNullException(nameof(repositorioProvaAluno));
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));
        }
        public async Task<ProvaAlunoDto> Handle(ObterProvaStatusAlunoQuery request, CancellationToken cancellationToken)
        {
            string chaveProvaAluno = request.ProvaId.ToString() + request.AlunoRa.ToString();
            return await repositorioCache.ObterRedisAsync(chaveProvaAluno, async () => await repositorioProvaAluno.ObterProvaStatusPorProvaIdRaAsync(request.ProvaId, request.AlunoRa));
        }
    }
}