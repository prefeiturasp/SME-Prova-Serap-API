using System;

namespace SME.SERAp.Prova.Infra.Dtos
{
    public class ProvaAreaAdministrativoRetornoDto
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime? InicioDownload { get; set; }
        public int TempoExecucao { get; set; }
        public bool PossuiBIB { get; set; }
        public int TotalCadernos { get; set; }
        public int TotalItens { get; set; }
        public bool PossuiContexto { get; set; }
        public string Senha { get; set; }
    }
}
