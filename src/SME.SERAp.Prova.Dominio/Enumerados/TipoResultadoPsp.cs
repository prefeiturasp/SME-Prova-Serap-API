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
    }
}
