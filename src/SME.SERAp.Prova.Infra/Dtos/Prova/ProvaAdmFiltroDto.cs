namespace SME.SERAp.Prova.Infra.Dtos
{
    public class ProvaAdmFiltroDto : DtoBase
    {
        public int QuantidadeRegistros { get; set; }
        public int NumeroPagina { get; set; }
        public int? ProvaLegadoId { get; set; }
        public int? Modalidade { get; set; }
        public string Descricao { get; set; }
        public string Ano { get; set; }
    }
}
