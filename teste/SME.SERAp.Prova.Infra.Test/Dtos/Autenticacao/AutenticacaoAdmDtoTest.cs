using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Autenticacao
{
    public class AutenticacaoAdmDtoTest
    {
        [Fact]
        public void Deve_Criar_AutenticacaoAdmDto_Com_Todos_Os_Campos()
        {
            var dto = new AutenticacaoAdmDto
            {
                Login = "joao.admin",
                Perfil = "ADM",
                ChaveApi = "chave-secreta"
            };

            Assert.Equal("joao.admin", dto.Login);
            Assert.Equal("ADM", dto.Perfil);
            Assert.Equal("chave-secreta", dto.ChaveApi);
        }

        [Fact]
        public void Deve_Criar_AutenticacaoAdmDto_Com_Valores_Default()
        {
            var dto = new AutenticacaoAdmDto();

            Assert.Null(dto.Login);
            Assert.Null(dto.Perfil);
            Assert.Null(dto.ChaveApi);
        }

        [Fact]
        public void Deve_Falhar_Validacao_Quando_Login_Nulo()
        {
            var dto = new AutenticacaoAdmDto { Login = null, Perfil = "ADM", ChaveApi = "chave" };
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(dto);

            var valido = Validator.TryValidateObject(dto, contexto, resultados, true);

            Assert.False(valido);
            Assert.Contains(resultados, r => r.ErrorMessage == "É necessário informar login ou código Rf.");
        }

        [Fact]
        public void Deve_Falhar_Validacao_Quando_Perfil_Nulo()
        {
            var dto = new AutenticacaoAdmDto { Login = "login", Perfil = null, ChaveApi = "chave" };
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(dto);

            var valido = Validator.TryValidateObject(dto, contexto, resultados, true);

            Assert.False(valido);
            Assert.Contains(resultados, r => r.ErrorMessage == "É necessário informar o perfil.");
        }

        [Fact]
        public void Deve_Falhar_Validacao_Quando_ChaveApi_Nula()
        {
            var dto = new AutenticacaoAdmDto { Login = "login", Perfil = "ADM", ChaveApi = null };
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(dto);

            var valido = Validator.TryValidateObject(dto, contexto, resultados, true);

            Assert.False(valido);
            Assert.Contains(resultados, r => r.ErrorMessage == "É necessário informar a chave api .");
        }

        [Fact]
        public void Deve_Passar_Validacao_Quando_Todos_Os_Campos_Preenchidos()
        {
            var dto = new AutenticacaoAdmDto { Login = "login", Perfil = "ADM", ChaveApi = "chave" };
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(dto);

            var valido = Validator.TryValidateObject(dto, contexto, resultados, true);

            Assert.True(valido);
            Assert.Empty(resultados);
        }
    }
}