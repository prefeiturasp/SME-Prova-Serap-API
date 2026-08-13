using System;
using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Infra.Dtos.ProvaPresenca
{
    public class CriarProvaPresencaDto
    {
        [Required(ErrorMessage = "O nome da prova é obrigatório.")]
        [StringLength(255, ErrorMessage = "O nome da prova não pode exceder 255 caracteres.")]
        public string NomeProva { get; set; }

        [Required(ErrorMessage = "O ano da prova é obrigatório.")]
        [Range(1900, 2100, ErrorMessage = "O ano da prova deve ser um valor válido entre 1900 e 2100.")]
        public int AnoProva { get; set; }

        public string DescricaoProva { get; set; }

        [Required(ErrorMessage = "A data inicial de aplicação é obrigatória.")]
        public DateTime DataInicialAplicacao { get; set; }

        [Required(ErrorMessage = "A data final de aplicação é obrigatória.")]
        public DateTime DataFinalAplicacao { get; set; }

        public DateTime? DataCorte { get; set; }

        public bool VinculaAlunoCadernoExtra { get; set; } = false;

        [Required(ErrorMessage = "É necessário informar as turmas para a prova de presença.")]
        [MinLength(1, ErrorMessage = "Pelo menos uma turma deve ser selecionada.")]
        public long[] TurmasIds { get; set; }
    }
}