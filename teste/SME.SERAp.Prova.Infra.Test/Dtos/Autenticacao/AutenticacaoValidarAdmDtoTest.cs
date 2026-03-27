namespace SME.SERAp.Prova.Infra.Test.Dtos.Autenticacao
{
    public class AutenticacaoValidarAdmDtoTest
    {
        [Fact]
        public void Deve_Criar_AutenticacaoValidarAdmDto_Com_Construtor_Parametros()
        {
            var dto = new AutenticacaoValidarAdmDto("codigo-123");

            Assert.Equal("codigo-123", dto.Codigo);
        }

        [Fact]
        public void Deve_Criar_AutenticacaoValidarAdmDto_Com_Codigo_Nulo()
        {
            var dto = new AutenticacaoValidarAdmDto(null);

            Assert.Null(dto.Codigo);
        }

        [Fact]
        public void Deve_Criar_AutenticacaoValidarAdmDto_Com_Codigo_Vazio()
        {
            var dto = new AutenticacaoValidarAdmDto("");

            Assert.Equal("", dto.Codigo);
        }

        [Fact]
        public void Deve_Alterar_Codigo_Apos_Criacao()
        {
            var dto = new AutenticacaoValidarAdmDto("original");
            dto.Codigo = "alterado";

            Assert.Equal("alterado", dto.Codigo);
        }

        [Fact]
        public void Deve_Criar_AutenticacaoValidarAdmDto_Com_Codigo_Numerico()
        {
            var dto = new AutenticacaoValidarAdmDto("123456");

            Assert.Equal("123456", dto.Codigo);
        }

        [Fact]
        public void Dois_Dtos_Com_Mesmo_Codigo_Devem_Ser_Iguais_Em_Conteudo()
        {
            var dto1 = new AutenticacaoValidarAdmDto("abc");
            var dto2 = new AutenticacaoValidarAdmDto("abc");

            Assert.Equal(dto1.Codigo, dto2.Codigo);
        }
    }
}