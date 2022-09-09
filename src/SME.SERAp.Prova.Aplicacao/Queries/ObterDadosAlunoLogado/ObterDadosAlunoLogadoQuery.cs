using MediatR;
using SME.SERAp.Prova.Infra.Dtos.Aluno;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterDadosAlunoLogadoQuery : IRequest<DadosAlunoLogadoDto>
    {
        public ObterDadosAlunoLogadoQuery(){}
    }
}
