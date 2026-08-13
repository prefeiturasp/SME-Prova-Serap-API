using System;
using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Infra.Dtos.ProvaPresenca
{
    public class DeletarProvaPresencaDto
    {
        [Required(ErrorMessage = "O ID da prova de presença é obrigatório para a exclusão.")]
        [Range(1, long.MaxValue, ErrorMessage = "O ID da prova de presença deve ser um valor positivo.")]
        public long Id { get; set; }
    }
}