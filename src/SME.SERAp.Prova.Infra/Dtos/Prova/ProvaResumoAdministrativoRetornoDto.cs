namespace SME.SERAp.Prova.Infra
{
    public class ProvaResumoAdministrativoRetornoDto : DtoBase
    {
        public ProvaResumoAdministrativoRetornoDto(long id, string titulo, string descricao, string caderno, int ordem)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Caderno = caderno;
            Ordem = ordem;
        }

        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Caderno { get; set; }
        public int Ordem { get; set; }
    }
}
