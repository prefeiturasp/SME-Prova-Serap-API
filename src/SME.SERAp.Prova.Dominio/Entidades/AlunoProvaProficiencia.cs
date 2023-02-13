using System;

namespace SME.SERAp.Prova.Dominio
{
    public class AlunoProvaProficiencia : EntidadeBase
    {
        public long AlunoId { get; set; }
        public long Ra { get; set; }
        public long ProvaId { get; set; }
        public long? DisciplinaId { get; set; }
        public decimal Proficiencia { get; set; }
        public int Origem { get; set; }
        public AlunoProvaProficienciaTipo Tipo { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
    }
}
