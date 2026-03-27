namespace SME.SERAp.Prova.Infra.Test.Dtos.Acompanhamento
{
    public class ProvaAlunoAcompDtoTest
    {
        [Fact]
        public void Deve_Criar_ProvaAlunoAcompDto_Com_Construtor_Parametros()
        {
            var criadoEm = new DateTime(2024, 5, 1, 8, 0, 0);
            var finalizadoEm = new DateTime(2024, 5, 1, 10, 0, 0);

            var dto = new ProvaAlunoAcompDto(10, 99, 1, criadoEm, finalizadoEm);

            Assert.Equal(10, dto.ProvaId);
            Assert.Equal(99, dto.AlunoRa);
            Assert.Equal(1, dto.Status);
            Assert.Equal(criadoEm, dto.CriadoEm);
            Assert.Equal(finalizadoEm, dto.FinalizadoEm);
        }

        [Fact]
        public void Deve_Criar_ProvaAlunoAcompDto_Com_Construtor_Padrao()
        {
            var dto = new ProvaAlunoAcompDto
            {
                ProvaId = 5,
                AlunoRa = 111,
                Status = 2,
                CriadoEm = DateTime.Today,
                FinalizadoEm = DateTime.Today
            };

            Assert.Equal(5, dto.ProvaId);
            Assert.Equal(111, dto.AlunoRa);
            Assert.Equal(2, dto.Status);
            Assert.Equal(DateTime.Today, dto.CriadoEm);
            Assert.Equal(DateTime.Today, dto.FinalizadoEm);
        }

        [Fact]
        public void Deve_Criar_ProvaAlunoAcompDto_Com_Valores_Default()
        {
            var dto = new ProvaAlunoAcompDto();

            Assert.Equal(0, dto.ProvaId);
            Assert.Equal(0, dto.AlunoRa);
            Assert.Equal(0, dto.Status);
            Assert.Null(dto.CriadoEm);
            Assert.Null(dto.FinalizadoEm);
        }

        [Fact]
        public void Deve_Criar_ProvaAlunoAcompDto_Com_CriadoEm_Nulo()
        {
            var dto = new ProvaAlunoAcompDto(1, 2, 0, null, null);

            Assert.Null(dto.CriadoEm);
        }

        [Fact]
        public void Deve_Criar_ProvaAlunoAcompDto_Com_FinalizadoEm_Nulo()
        {
            var dto = new ProvaAlunoAcompDto(1, 2, 1, DateTime.Today, null);

            Assert.Null(dto.FinalizadoEm);
        }

        [Fact]
        public void Deve_Criar_ProvaAlunoAcompDto_Com_AlunoRa_Maximo()
        {
            var dto = new ProvaAlunoAcompDto(1, long.MaxValue, 1, null, null);

            Assert.Equal(long.MaxValue, dto.AlunoRa);
        }

        [Fact]
        public void Deve_Criar_ProvaAlunoAcompDto_Com_ProvaId_Maximo()
        {
            var dto = new ProvaAlunoAcompDto(long.MaxValue, 1, 1, null, null);

            Assert.Equal(long.MaxValue, dto.ProvaId);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var dto = new ProvaAlunoAcompDto(1, 2, 1, null, null);
            dto.Status = 3;
            dto.FinalizadoEm = DateTime.Today;

            Assert.Equal(3, dto.Status);
            Assert.Equal(DateTime.Today, dto.FinalizadoEm);
        }
    }
}