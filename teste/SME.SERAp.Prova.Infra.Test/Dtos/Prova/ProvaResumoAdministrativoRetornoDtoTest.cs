using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Prova
{
    public class ProvaResumoAdministrativoRetornoDtoTest
    {
        [Fact]
        public void Deve_Criar_ProvaResumoAdministrativoRetornoDto_Com_Construtor_Parametros()
        {
            var dto = new ProvaResumoAdministrativoRetornoDto(1, "Título", "Descrição", "A", 2);

            Assert.Equal(1, dto.Id);
            Assert.Equal("Título", dto.Titulo);
            Assert.Equal("Descrição", dto.Descricao);
            Assert.Equal("A", dto.Caderno);
            Assert.Equal(2, dto.Ordem);
        }

        [Fact]
        public void Deve_Atribuir_Id_Corretamente()
        {
            var dto = new ProvaResumoAdministrativoRetornoDto(99, "T", "D", "B", 1);
            Assert.Equal(99, dto.Id);
        }

        [Fact]
        public void Deve_Atribuir_Titulo_Corretamente()
        {
            var dto = new ProvaResumoAdministrativoRetornoDto(1, "Meu Título", "D", "C", 1);
            Assert.Equal("Meu Título", dto.Titulo);
        }

        [Fact]
        public void Deve_Atribuir_Descricao_Corretamente()
        {
            var dto = new ProvaResumoAdministrativoRetornoDto(1, "T", "Minha Descrição", "D", 1);
            Assert.Equal("Minha Descrição", dto.Descricao);
        }

        [Fact]
        public void Deve_Atribuir_Caderno_Corretamente()
        {
            var dto = new ProvaResumoAdministrativoRetornoDto(1, "T", "D", "E", 1);
            Assert.Equal("E", dto.Caderno);
        }

        [Fact]
        public void Deve_Atribuir_Ordem_Corretamente()
        {
            var dto = new ProvaResumoAdministrativoRetornoDto(1, "T", "D", "A", 10);
            Assert.Equal(10, dto.Ordem);
        }

        [Fact]
        public void Deve_Aceitar_Titulo_Nulo()
        {
            var dto = new ProvaResumoAdministrativoRetornoDto(1, null, "D", "A", 1);
            Assert.Null(dto.Titulo);
        }

        [Fact]
        public void Deve_Aceitar_Descricao_Nula()
        {
            var dto = new ProvaResumoAdministrativoRetornoDto(1, "T", null, "A", 1);
            Assert.Null(dto.Descricao);
        }

        [Fact]
        public void Deve_Aceitar_Caderno_Nulo()
        {
            var dto = new ProvaResumoAdministrativoRetornoDto(1, "T", "D", null, 1);
            Assert.Null(dto.Caderno);
        }

        [Fact]
        public void Deve_Aceitar_Ordem_Zero()
        {
            var dto = new ProvaResumoAdministrativoRetornoDto(1, "T", "D", "A", 0);
            Assert.Equal(0, dto.Ordem);
        }

        [Fact]
        public void Deve_Aceitar_Id_Valor_Maximo_Long()
        {
            var dto = new ProvaResumoAdministrativoRetornoDto(long.MaxValue, "T", "D", "A", 1);
            Assert.Equal(long.MaxValue, dto.Id);
        }

        [Fact]
        public void Deve_Permitir_Alterar_Propriedades_Apos_Construcao()
        {
            var dto = new ProvaResumoAdministrativoRetornoDto(1, "Original", "Desc", "A", 1);
            dto.Titulo = "Alterado";
            dto.Ordem = 99;

            Assert.Equal("Alterado", dto.Titulo);
            Assert.Equal(99, dto.Ordem);
        }
    }
}