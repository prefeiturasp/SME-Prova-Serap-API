namespace SME.SERAp.Prova.Infra.Test.Dtos.Autenticacao
{
    public class InformacoesTokenDtoTest
    {
        [Fact]
        public void Deve_Criar_InformacoesTokenDto_Com_Construtor_Parametros()
        {
            var dto = new InformacoesTokenDto(123456, "5", 1, 5, "device-001");

            Assert.Equal(123456, dto.Ra);
            Assert.Equal("5", dto.Ano);
            Assert.Equal(1, dto.TipoTurno);
            Assert.Equal(5, dto.Modalidade);
            Assert.Equal("device-001", dto.Dispositivo);
        }

        [Fact]
        public void Deve_Criar_InformacoesTokenDto_Com_Ra_Maximo()
        {
            var dto = new InformacoesTokenDto(long.MaxValue, "9", 3, 5, "dev");

            Assert.Equal(long.MaxValue, dto.Ra);
        }

        [Fact]
        public void Deve_Criar_InformacoesTokenDto_Com_Ano_Nulo()
        {
            var dto = new InformacoesTokenDto(1, null, 1, 5, "dev");

            Assert.Null(dto.Ano);
        }

        [Fact]
        public void Deve_Criar_InformacoesTokenDto_Com_Dispositivo_Nulo()
        {
            var dto = new InformacoesTokenDto(1, "5", 1, 5, null);

            Assert.Null(dto.Dispositivo);
        }

        [Fact]
        public void Deve_Criar_InformacoesTokenDto_Com_TipoTurno_E_Modalidade_Zero()
        {
            var dto = new InformacoesTokenDto(1, "5", 0, 0, "dev");

            Assert.Equal(0, dto.TipoTurno);
            Assert.Equal(0, dto.Modalidade);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var dto = new InformacoesTokenDto(1, "3", 1, 5, "dev-a");
            dto.Ra = 999;
            dto.Ano = "7";
            dto.Dispositivo = "dev-b";

            Assert.Equal(999, dto.Ra);
            Assert.Equal("7", dto.Ano);
            Assert.Equal("dev-b", dto.Dispositivo);
        }
    }
}