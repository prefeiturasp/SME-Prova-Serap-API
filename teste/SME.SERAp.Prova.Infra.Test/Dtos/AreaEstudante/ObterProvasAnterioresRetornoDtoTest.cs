using System;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.AreaEstudante
{
    public class ObterProvasAnterioresRetornoDtoTest
    {
        [Fact]
        public void Deve_Criar_ObterProvasAnterioresRetornoDto_Com_Propriedades_Padrao()
        {
            var dto = new ObterProvasAnterioresRetornoDto();

            Assert.Equal(0, dto.Id);
            Assert.Null(dto.Descricao);
            Assert.Equal(0, dto.ItensQuantidade);
            Assert.Equal(0, dto.TempoTotal);
            Assert.Equal(0, dto.Status);
            Assert.Equal(default(DateTime), dto.DataInicio);
            Assert.Null(dto.DataFim);
            Assert.Null(dto.DataInicioProvaAluno);
            Assert.Null(dto.DataFimProvaAluno);
        }

        [Fact]
        public void Deve_Atribuir_Id_Corretamente()
        {
            var dto = new ObterProvasAnterioresRetornoDto { Id = 123 };
            Assert.Equal(123, dto.Id);
        }

        [Fact]
        public void Deve_Atribuir_Descricao_Corretamente()
        {
            var dto = new ObterProvasAnterioresRetornoDto { Descricao = "Prova de Português 2023" };
            Assert.Equal("Prova de Português 2023", dto.Descricao);
        }

        [Fact]
        public void Deve_Atribuir_ItensQuantidade_Corretamente()
        {
            var dto = new ObterProvasAnterioresRetornoDto { ItensQuantidade = 25 };
            Assert.Equal(25, dto.ItensQuantidade);
        }

        [Fact]
        public void Deve_Atribuir_TempoTotal_Corretamente()
        {
            var dto = new ObterProvasAnterioresRetornoDto { TempoTotal = 90 };
            Assert.Equal(90, dto.TempoTotal);
        }

        [Fact]
        public void Deve_Atribuir_Status_Corretamente()
        {
            var dto = new ObterProvasAnterioresRetornoDto { Status = 2 };
            Assert.Equal(2, dto.Status);
        }

        [Fact]
        public void Deve_Atribuir_DataInicio_Corretamente()
        {
            var data = new DateTime(2023, 3, 10);
            var dto = new ObterProvasAnterioresRetornoDto { DataInicio = data };
            Assert.Equal(data, dto.DataInicio);
        }

        [Fact]
        public void Deve_Atribuir_DataFim_Corretamente()
        {
            var data = new DateTime(2023, 3, 20);
            var dto = new ObterProvasAnterioresRetornoDto { DataFim = data };
            Assert.Equal(data, dto.DataFim);
        }

        [Fact]
        public void Deve_Aceitar_DataFim_Nula()
        {
            var dto = new ObterProvasAnterioresRetornoDto { DataFim = null };
            Assert.Null(dto.DataFim);
        }

        [Fact]
        public void Deve_Atribuir_DataInicioProvaAluno_Corretamente()
        {
            var data = new DateTime(2023, 3, 10, 8, 30, 0);
            var dto = new ObterProvasAnterioresRetornoDto { DataInicioProvaAluno = data };
            Assert.Equal(data, dto.DataInicioProvaAluno);
        }

        [Fact]
        public void Deve_Aceitar_DataInicioProvaAluno_Nula()
        {
            var dto = new ObterProvasAnterioresRetornoDto { DataInicioProvaAluno = null };
            Assert.Null(dto.DataInicioProvaAluno);
        }

        [Fact]
        public void Deve_Atribuir_DataFimProvaAluno_Corretamente()
        {
            var data = new DateTime(2023, 3, 10, 10, 0, 0);
            var dto = new ObterProvasAnterioresRetornoDto { DataFimProvaAluno = data };
            Assert.Equal(data, dto.DataFimProvaAluno);
        }

        [Fact]
        public void Deve_Aceitar_DataFimProvaAluno_Nula()
        {
            var dto = new ObterProvasAnterioresRetornoDto { DataFimProvaAluno = null };
            Assert.Null(dto.DataFimProvaAluno);
        }

        [Fact]
        public void Deve_Criar_ObterProvasAnterioresRetornoDto_Completo()
        {
            var dto = new ObterProvasAnterioresRetornoDto
            {
                Id = 10,
                Descricao = "Prova Anterior de Ciências",
                ItensQuantidade = 15,
                TempoTotal = 45,
                Status = 3,
                DataInicio = new DateTime(2023, 5, 1),
                DataFim = new DateTime(2023, 5, 10),
                DataInicioProvaAluno = new DateTime(2023, 5, 1, 9, 0, 0),
                DataFimProvaAluno = new DateTime(2023, 5, 1, 9, 45, 0)
            };

            Assert.Equal(10, dto.Id);
            Assert.Equal("Prova Anterior de Ciências", dto.Descricao);
            Assert.Equal(15, dto.ItensQuantidade);
            Assert.Equal(45, dto.TempoTotal);
            Assert.Equal(3, dto.Status);
            Assert.Equal(new DateTime(2023, 5, 1), dto.DataInicio);
            Assert.Equal(new DateTime(2023, 5, 10), dto.DataFim);
            Assert.Equal(new DateTime(2023, 5, 1, 9, 0, 0), dto.DataInicioProvaAluno);
            Assert.Equal(new DateTime(2023, 5, 1, 9, 45, 0), dto.DataFimProvaAluno);
        }

        [Fact]
        public void Deve_Aceitar_Status_Zero()
        {
            var dto = new ObterProvasAnterioresRetornoDto { Status = 0 };
            Assert.Equal(0, dto.Status);
        }

        [Fact]
        public void Deve_Aceitar_ItensQuantidade_Zero()
        {
            var dto = new ObterProvasAnterioresRetornoDto { ItensQuantidade = 0 };
            Assert.Equal(0, dto.ItensQuantidade);
        }
    }
}