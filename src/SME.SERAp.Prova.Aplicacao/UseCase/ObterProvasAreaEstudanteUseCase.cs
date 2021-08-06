using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasAreaEstudanteUseCase : IObterProvasAreaEstudanteUseCase
    {
        public async Task<IEnumerable<ObterProvasRetornoDto>> Executar()
        {
            var provas = new List<ObterProvasRetornoDto>() { 
                new ObterProvasRetornoDto("Prova São Paulo 2021 - 1", 20, new System.DateTime(2021, 5, 26), null),
                new ObterProvasRetornoDto("Prova São Paulo 2021 - 2", 20, new System.DateTime(2021, 5, 26), new System.DateTime(2021, 6, 1)),
                new ObterProvasRetornoDto("Prova São Paulo 2021 - 3", 20, new System.DateTime(2021, 5, 26), null),
                new ObterProvasRetornoDto("Prova São Paulo 2021 - 4", 20, new System.DateTime(2021, 5, 26), new System.DateTime(2021, 6, 1)),
                new ObterProvasRetornoDto("Prova São Paulo 2021 - 5", 20, new System.DateTime(2021, 5, 26), null),
                new ObterProvasRetornoDto("Prova São Paulo 2021 - 6", 20, new System.DateTime(2021, 5, 26), new System.DateTime(2021, 6, 1)),
                new ObterProvasRetornoDto("Prova São Paulo 2021 - 7", 20, new System.DateTime(2021, 5, 26), null),
                new ObterProvasRetornoDto("Prova São Paulo 2021 - 8", 20, new System.DateTime(2021, 5, 26), new System.DateTime(2021, 6, 1)),
            };

            return await Task.FromResult(provas);

        }
    }
}
