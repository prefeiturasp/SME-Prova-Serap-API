using System;
using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Infra.Dtos.ProvaPresenca
{
    public class AtualizarProvaPresencaDto
    {
        [Required(ErrorMessage = "O ID da prova de presença é obrigatório para a atualização.")]
        [Range(1, long.MaxValue, ErrorMessage = "O ID da prova de presença deve ser um valor positivo.")]
        public long Id { get; set; }

        [StringLength(255, ErrorMessage = "O nome da prova não pode exceder 255 caracteres.")]
        public string NomeProva { get; set; }

        [Range(1900, 2100, ErrorMessage = "O ano da prova deve ser um valor válido entre 1900 e 2100.")]
        public int? AnoProva { get; set; }

        public string DescricaoProva { get; set; }

        public DateTime? DataInicialAplicacao { get; set; }
        public DateTime? DataFinalAplicacao { get; set; }
        public DateTime? DataCorte { get; set; }

        public bool? VinculaAlunoCadernoExtra { get; set; } = false;
        public long[] TurmasIds { get; set; }
    }
}