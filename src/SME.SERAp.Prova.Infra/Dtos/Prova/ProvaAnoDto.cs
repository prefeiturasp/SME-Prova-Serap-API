using MessagePack;
using SME.SERAp.Prova.Dominio;
using System;

namespace SME.SERAp.Prova.Infra
{
    [MessagePackObject(keyAsPropertyName: true)]
    public class ProvaAnoDto
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public DateTime? InicioDownload { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int TempoExecucao { get; set; }
        public DateTime Inclusao { get; set; }
        public int TotalItens { get; set; }
        public int TotalCadernos { get; set; }
        public long LegadoId { get; set; }
        public string Senha { get; set; }
        public bool PossuiBIB { get; set; }
        public Modalidade Modalidade { get; set; }
        public string Ano { get; set; }
        public int EtapaEja { get; set; }

        public DateTime ObterDataInicioMais3Horas()
        {
            return Inicio.AddHours(3);
        }

        public DateTime ObterDataFimMais3Horas()
        {
            return Fim.AddHours(3);
        }

        public DateTime? ObterDataInicioDownloadMais3Horas()
        {
            return InicioDownload.HasValue ? InicioDownload?.AddHours(3) : null;
        }        
    }
}
