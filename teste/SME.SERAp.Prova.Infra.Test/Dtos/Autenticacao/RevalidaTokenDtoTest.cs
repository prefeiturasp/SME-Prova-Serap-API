using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Autenticacao
{
    public class RevalidaTokenDtoTest
    {
        [Fact]
        public void Deve_Criar_RevalidaTokenDto_Com_Token_Valido()
        {
            var dto = new RevalidaTokenDto { Token = "token-valido-123" };

            Assert.Equal("token-valido-123", dto.Token);
        }

        [Fact]
        public void Deve_Criar_RevalidaTokenDto_Com_Token_Nulo()
        {
            var dto = new RevalidaTokenDto { Token = null };

            Assert.Null(dto.Token);
        }

        [Fact]
        public void Deve_Criar_RevalidaTokenDto_Com_Token_Vazio()
        {
            var dto = new RevalidaTokenDto { Token = "" };

            Assert.Equal("", dto.Token);
        }

        [Fact]
        public void Deve_Falhar_Validacao_Quando_Token_Nulo()
        {
            var dto = new RevalidaTokenDto { Token = null };
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(dto);

            var valido = Validator.TryValidateObject(dto, contexto, resultados, true);

            Assert.False(valido);
            Assert.Contains(resultados, r => r.ErrorMessage == "É necessário informar o token.");
        }

        [Fact]
        public void Deve_Passar_Validacao_Quando_Token_Preenchido()
        {
            var dto = new RevalidaTokenDto { Token = "token-ok" };
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(dto);

            var valido = Validator.TryValidateObject(dto, contexto, resultados, true);

            Assert.True(valido);
            Assert.Empty(resultados);
        }

        [Fact]
        public void Deve_Alterar_Token_Apos_Criacao()
        {
            var dto = new RevalidaTokenDto { Token = "original" };
            dto.Token = "alterado";

            Assert.Equal("alterado", dto.Token);
        }
    }
}