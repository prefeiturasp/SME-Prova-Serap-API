using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Prova
{
    public class ProvaAdmFiltroDtoTest
    {
        [Fact]
        public void Deve_Criar_ProvaAdmFiltroDto_Com_Propriedades_Padrao()
        {
            var dto = new ProvaAdmFiltroDto();

            Assert.Equal(0, dto.QuantidadeRegistros);
            Assert.Equal(0, dto.NumeroPagina);
            Assert.Null(dto.ProvaLegadoId);
            Assert.Null(dto.Modalidade);
            Assert.Null(dto.Descricao);
            Assert.Null(dto.Ano);
        }

        [Fact]
        public void Deve_Criar_ProvaAdmFiltroDto_Completo()
        {
            var dto = new ProvaAdmFiltroDto
            {
                QuantidadeRegistros = 20,
                NumeroPagina = 2,
                ProvaLegadoId = 100,
                Modalidade = 5,
                Descricao = "Prova de Matemática",
                Ano = "2024"
            };

            Assert.Equal(20, dto.QuantidadeRegistros);
            Assert.Equal(2, dto.NumeroPagina);
            Assert.Equal(100, dto.ProvaLegadoId);
            Assert.Equal(5, dto.Modalidade);
            Assert.Equal("Prova de Matemática", dto.Descricao);
            Assert.Equal("2024", dto.Ano);
        }

        [Fact]
        public void Deve_Aceitar_ProvaLegadoId_Nulo()
        {
            var dto = new ProvaAdmFiltroDto { ProvaLegadoId = null };
            Assert.Null(dto.ProvaLegadoId);
        }

        [Fact]
        public void Deve_Aceitar_Modalidade_Nula()
        {
            var dto = new ProvaAdmFiltroDto { Modalidade = null };
            Assert.Null(dto.Modalidade);
        }

        [Fact]
        public void Deve_Aceitar_Descricao_Nula()
        {
            var dto = new ProvaAdmFiltroDto { Descricao = null };
            Assert.Null(dto.Descricao);
        }

        [Fact]
        public void Deve_Aceitar_Ano_Nulo()
        {
            var dto = new ProvaAdmFiltroDto { Ano = null };
            Assert.Null(dto.Ano);
        }

        [Fact]
        public void Deve_Aceitar_QuantidadeRegistros_Zero()
        {
            var dto = new ProvaAdmFiltroDto { QuantidadeRegistros = 0 };
            Assert.Equal(0, dto.QuantidadeRegistros);
        }

        [Fact]
        public void Deve_Aceitar_NumeroPagina_Zero()
        {
            var dto = new ProvaAdmFiltroDto { NumeroPagina = 0 };
            Assert.Equal(0, dto.NumeroPagina);
        }

        [Fact]
        public void Deve_Aceitar_Descricao_Vazia()
        {
            var dto = new ProvaAdmFiltroDto { Descricao = string.Empty };
            Assert.Equal(string.Empty, dto.Descricao);
        }

        [Fact]
        public void Deve_Aceitar_Ano_Vazio()
        {
            var dto = new ProvaAdmFiltroDto { Ano = string.Empty };
            Assert.Equal(string.Empty, dto.Ano);
        }
    }
}