using System;

namespace SME.SERAp.Prova.Dominio
{
    public class ExecucaoControle : EntidadeBase
    {
        public DateTime UltimaExecucao { get; set; }
        public ExecucaoControleTipo Tipo { get; set; }
    }
}
