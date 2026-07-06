using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Autenticacao
{
    public class AutenticacaoDtoTest
    {
        [Fact]
        public void Deve_Criar_AutenticacaoDto_Com_Todos_Os_Campos()
        {
            var dto = new AutenticacaoDto
            {
                Login = 123456,
                Senha = "senha123",
                Dispositivo = "device-001"
            };

            Assert.Equal(123456, dto.Login);
            Assert.Equal("senha123", dto.Senha);
            Assert.Equal("device-001", dto.Dispositivo);
        }

        [Fact]
        public void Deve_Criar_AutenticacaoDto_Com_Valores_Default()
        {
            var dto = new AutenticacaoDto();

            Assert.Equal(0, dto.Login);
            Assert.Null(dto.Senha);
            Assert.Null(dto.Dispositivo);
        }

        [Fact]
        public void Deve_Criar_AutenticacaoDto_Com_Dispositivo_Nulo()
        {
            var dto = new AutenticacaoDto { Login = 999, Senha = "abc", Dispositivo = null };

            Assert.Null(dto.Dispositivo);
        }

        [Fact]
        public void Deve_Falhar_Validacao_Quando_Senha_Nula()
        {
            var dto = new AutenticacaoDto { Login = 123456, Senha = null };
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(dto);

            var valido = Validator.TryValidateObject(dto, contexto, resultados, true);

            Assert.False(valido);
            Assert.Contains(resultados, r => r.ErrorMessage == "É necessário informar a senha.");
        }

        [Fact]
        public void Deve_Falhar_Validacao_Quando_Senha_Menor_Que_3_Caracteres()
        {
            var dto = new AutenticacaoDto { Login = 123456, Senha = "ab" };
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(dto);

            var valido = Validator.TryValidateObject(dto, contexto, resultados, true);

            Assert.False(valido);
            Assert.Contains(resultados, r => r.ErrorMessage == "A senha deve conter no mínimo 3 caracteres.");
        }

        [Fact]
        public void Deve_Falhar_Validacao_Quando_Login_Menor_Que_Range()
        {
            var dto = new AutenticacaoDto { Login = 10, Senha = "senha123" };
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(dto);

            var valido = Validator.TryValidateObject(dto, contexto, resultados, true);

            Assert.False(valido);
            Assert.Contains(resultados, r => r.ErrorMessage == "O código RA deve conter no mínimo 3 caracteres.");
        }

        [Fact]
        public void Deve_Passar_Validacao_Com_Dados_Validos()
        {
            var dto = new AutenticacaoDto { Login = 123456, Senha = "abc" };
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(dto);

            var valido = Validator.TryValidateObject(dto, contexto, resultados, true);

            Assert.True(valido);
            Assert.Empty(resultados);
        }

        [Fact]
        public void Deve_Criar_AutenticacaoDto_Com_Login_Maximo()
        {
            var dto = new AutenticacaoDto { Login = long.MaxValue, Senha = "abc" };

            Assert.Equal(long.MaxValue, dto.Login);
        }
    }
}