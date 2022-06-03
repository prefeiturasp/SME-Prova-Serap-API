using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum SituacaoAluno
    {
        //ATIVO
        [Display(Name = "Ativo")]
        Ativo = 1,

        [Display(Name = "Pendente de Rematrícula")]
        PendenteRematricula = 6,

        [Display(Name = "Rematriculado")]
        Rematriculado = 10,

        [Display(Name = "Sem continuidade")]
        SemContinuidade = 13,

        [Display(Name = "Concluído")]
        Concluido = 5,


        //INATIVO
        [Display(Name = "Desistente")]
        Desistente = 2,

        [Display(Name = "Transferido")]
        Transferido = 3,

        [Display(Name = "Vínculo Indevido")]
        VinculoIndevido = 4,

        [Display(Name = "Falecido")]
        Falecido = 7,

        [Display(Name = "Não Compareceu")]
        NaoCompareceu = 8,

        [Display(Name = "Deslocamento")]
        Deslocamento = 11,

        [Display(Name = "Cessado")]
        Cessado = 12,

        [Display(Name = "Remanejado Saída")]
        RemanejadoSaida = 14,

        [Display(Name = "Reclassificado Saída")]
        ReclassificadoSaida = 15,

        [Display(Name = "Transferido SED")]
        TransferidoSED = 16,

        [Display(Name = "Dispensado Ed. Física")]
        DispensadoEdFisica = 17,

    }
}
