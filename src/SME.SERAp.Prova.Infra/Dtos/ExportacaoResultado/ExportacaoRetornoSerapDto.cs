namespace SME.SERAp.Prova.Infra
{
    public class ExportacaoRetornoSerapDto : DtoBase
	{
		public long Test_Id { get; set; }
		public string TestDescription { get; set; }
		public string TestTypeDescription { get; set; }
		public int StateExecution { get; set; }

		public string CreateDate { get; set; }
		public string UpdateDate { get; set; }

		public long FileId { get; set; }
	}
}
