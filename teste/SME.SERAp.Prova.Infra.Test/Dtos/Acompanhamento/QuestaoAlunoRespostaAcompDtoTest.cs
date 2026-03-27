namespace SME.SERAp.Prova.Infra.Test.Dtos.Acompanhamento
{
    public class QuestaoAlunoRespostaAcompDtoTest
    {
        [Fact]
        public void Deve_Criar_QuestaoAlunoRespostaAcompDto_Com_Construtor_Parametros()
        {
            var dto = new QuestaoAlunoRespostaAcompDto(10, 99, 50, 3, 120);

            Assert.Equal(10, dto.ProvaId);
            Assert.Equal(99, dto.AlunoRa);
            Assert.Equal(50, dto.QuestaoId);
            Assert.Equal(3, dto.AlternativaId);
            Assert.Equal(120, dto.Tempo);
            Assert.True(dto.Consolidar);
        }

        [Fact]
        public void Deve_Criar_QuestaoAlunoRespostaAcompDto_Com_Construtor_Padrao()
        {
            var dto = new QuestaoAlunoRespostaAcompDto
            {
                ProvaId = 5,
                AlunoRa = 111,
                QuestaoId = 20,
                AlternativaId = 7,
                Tempo = 60
            };

            Assert.Equal(5, dto.ProvaId);
            Assert.Equal(111, dto.AlunoRa);
            Assert.Equal(20, dto.QuestaoId);
            Assert.Equal(7, dto.AlternativaId);
            Assert.Equal(60, dto.Tempo);
        }

        [Fact]
        public void Deve_Criar_QuestaoAlunoRespostaAcompDto_Com_Valores_Default()
        {
            var dto = new QuestaoAlunoRespostaAcompDto();

            Assert.Equal(0, dto.ProvaId);
            Assert.Equal(0, dto.AlunoRa);
            Assert.Equal(0, dto.QuestaoId);
            Assert.Null(dto.AlternativaId);
            Assert.Null(dto.Tempo);
            Assert.True(dto.Consolidar);
        }

        [Fact]
        public void Deve_Definir_Consolidar_True_No_Construtor_Parametros()
        {
            var dto = new QuestaoAlunoRespostaAcompDto(1, 2, 3, null, null);

            Assert.True(dto.Consolidar);
        }

        [Fact]
        public void Deve_Criar_QuestaoAlunoRespostaAcompDto_Com_AlternativaId_Nulo()
        {
            var dto = new QuestaoAlunoRespostaAcompDto(1, 2, 3, null, 30);

            Assert.Null(dto.AlternativaId);
        }

        [Fact]
        public void Deve_Criar_QuestaoAlunoRespostaAcompDto_Com_Tempo_Nulo()
        {
            var dto = new QuestaoAlunoRespostaAcompDto(1, 2, 3, 5, null);

            Assert.Null(dto.Tempo);
        }

        [Fact]
        public void Deve_Criar_QuestaoAlunoRespostaAcompDto_Com_Ambos_Nulos()
        {
            var dto = new QuestaoAlunoRespostaAcompDto(1, 2, 3, null, null);

            Assert.Null(dto.AlternativaId);
            Assert.Null(dto.Tempo);
        }

        [Fact]
        public void Deve_Alterar_Consolidar_Apos_Criacao()
        {
            var dto = new QuestaoAlunoRespostaAcompDto(1, 2, 3, null, null);
            dto.Consolidar = false;

            Assert.False(dto.Consolidar);
        }

        [Fact]
        public void Deve_Criar_QuestaoAlunoRespostaAcompDto_Com_Ids_Maximos()
        {
            var dto = new QuestaoAlunoRespostaAcompDto(long.MaxValue, long.MaxValue, long.MaxValue, long.MaxValue, null);

            Assert.Equal(long.MaxValue, dto.ProvaId);
            Assert.Equal(long.MaxValue, dto.AlunoRa);
            Assert.Equal(long.MaxValue, dto.QuestaoId);
            Assert.Equal(long.MaxValue, dto.AlternativaId);
        }

        [Fact]
        public void Deve_Criar_QuestaoAlunoRespostaAcompDto_Com_Tempo_Zero()
        {
            var dto = new QuestaoAlunoRespostaAcompDto(1, 2, 3, null, 0);

            Assert.Equal(0, dto.Tempo);
        }
    }
}