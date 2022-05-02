using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Infra
{
    public class QuestaoAlunoRespostaSincronizarDto : DtoBase
    {
        [Required(ErrorMessage = "É necessário informar o RA do aluno")]
        public long AlunoRa { get; set; }
        [Required(ErrorMessage = "É necessário informar o identificador da questão")]
        public long QuestaoId { get; set; }
        public long? AlternativaId { get; set; }
        public string Resposta { get; set; }
        [Required(ErrorMessage = "É necessário informar a data da resposta em ticks")]
        [Range(1, long.MaxValue, ErrorMessage = "A data em ticks deve ser maior do que {1}")]
        public long DataHoraRespostaTicks { get; set; }
        public int? TempoRespostaAluno { get; set; }
    }
}
