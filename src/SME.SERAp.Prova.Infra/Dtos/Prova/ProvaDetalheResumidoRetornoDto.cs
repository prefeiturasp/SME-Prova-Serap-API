namespace SME.SERAp.Prova.Infra
{
    public class ProvaDetalheResumidoRetornoDto : DtoBase
    {
        public ProvaDetalheResumidoRetornoDto(
            long provaId, 
            long[] questoesIds,
            long[] contextosProvaIds)
        {
            ProvaId = provaId;
            QuestoesIds = questoesIds;
            ContextosProvaIds = contextosProvaIds;
        }

        public long ProvaId { get; set; }
        public long[] QuestoesIds { get; set; }
        public long[] ContextosProvaIds {get;set;}
    }
}
