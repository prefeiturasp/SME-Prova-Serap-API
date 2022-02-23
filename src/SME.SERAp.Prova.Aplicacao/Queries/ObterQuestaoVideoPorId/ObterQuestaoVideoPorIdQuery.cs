using MediatR;
using SME.SERAp.Prova.Dominio;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoVideoPorIdQuery : IRequest<QuestaoVideo>
    {
        public ObterQuestaoVideoPorIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
