using MediatR;
using SME.SERAp.Prova.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProficienciaFinalPorProvaQueryHandler : IRequestHandler<ObterProficienciaFinalPorProvaQuery, decimal>
    {
        private readonly IRepositorioAlunoProvaProficiencia repositorioAlunoProvaProficiencia;

        public ObterProficienciaFinalPorProvaQueryHandler(IRepositorioAlunoProvaProficiencia repositorioAlunoProvaProficiencia)
        {
            this.repositorioAlunoProvaProficiencia = repositorioAlunoProvaProficiencia ?? throw new ArgumentNullException(nameof(repositorioAlunoProvaProficiencia));
        }

        public async Task<decimal> Handle(ObterProficienciaFinalPorProvaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioAlunoProvaProficiencia.ObterProficienciaFinalAlunoPorProvaIdAsync(request.ProvaId, request.AlunoRa);
        }
    }
}
