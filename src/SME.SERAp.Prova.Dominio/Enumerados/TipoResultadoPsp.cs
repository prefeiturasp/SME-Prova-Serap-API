using System.ComponentModel;

namespace SME.SERAp.Prova.Dominio
{
    public enum TipoResultadoPsp
    {
        [Description("ResultadoAluno")]
        ResultadoAluno = 1,

        [Description("ResultadoTurma")]
        ResultadoTurma = 2,

        [Description("ResultadoEscola")]
        ResultadoEscola = 3,

        [Description("ResultadoDre")]
        ResultadoDre = 4,

        [Description("ResultadoSme")]
        ResultadoSme = 5,

        [Description("ResultadoParticipacaoTurma")]
        ResultadoParticipacaoTurma = 13,

        [Description("ParticipacaoTurmaAreaConhecimento")]
        ParticipacaoTurmaAreaConhecimento = 14,

        [Description("ResultadoParticipacaoUe")]
        ResultadoParticipacaoUe = 15,

        [Description("ParticipacaoUeAreaConhecimento")]
        ParticipacaoUeAreaConhecimento = 16,

        [Description("ParticipacaoDre")]
        ParticipacaoDre = 17,

        [Description("ParticipacaoDreAreaConhecimento")]
        ParticipacaoDreAreaConhecimento = 18,

        [Description("ParticipacaoSme")]
        ParticipacaoSme = 19,

        [Description("ParticipacaoSmeAreaConhecimento")]
        ParticipacaoSmeAreaConhecimento = 20,
        
        [Description("ResultadoCicloSme")]
        ResultadoCicloSme = 11,
        
        [Description("ResultadoCicloEscola")]
        ResultadoCicloEscola = 10        
    }
}
