namespace SME.SERAp.Prova.Infra
{
    public static class CacheChave
    {
        /// <summary>
        /// Questões resumidas da prova
        /// 0 - provaId
        /// </summary>
        public const string QuestaoProvaResumo = "p-q-r-{0}";
        /// <summary>
        /// Contextos resumidos da prova
        /// 0 - provaId
        /// </summary>
        public const string ContextoProvaResumo = "p-c-r-{0}";
        /// <summary>
        /// Caderno do aluno na prova
        /// 0 - provaId
        /// 1 - RA do aluno
        /// </summary>
        public const string AlunoCadernoProva = "al-c-p-{0}-{1}";
        /// <summary>
        /// Aluno
        /// 0 - RA do aluno
        /// </summary>
        public const string Aluno = "al-{0}";
    }
}
