using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Infra
{
    public class ExportacaoRetornoSerapDto
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
