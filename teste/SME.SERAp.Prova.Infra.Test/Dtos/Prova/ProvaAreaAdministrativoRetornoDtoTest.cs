using System;
using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Prova
{
    public class ProvaAreaAdministrativoRetornoDtoTest
    {
        [Fact]
        public void Deve_Criar_ProvaAreaAdministrativoRetornoDto_Com_Propriedades_Padrao()
        {
            var dto = new ProvaAreaAdministrativoRetornoDto();

            Assert.Equal(0, dto.Id);
            Assert.Null(dto.Descricao);
            Assert.Equal(default(DateTime), dto.DataInicio);
            Assert.Equal(default(DateTime), dto.DataFim);
            Assert.Null(dto.InicioDownload);
            Assert.Equal(0, dto.TempoExecucao);
            Assert.False(dto.PossuiBIB);
            Assert.Equal(0, dto.TotalCadernos);
            Assert.Equal(0, dto.TotalItens);
            Assert.False(dto.PossuiContexto);
            Assert.Null(dto.Senha);
        }

        [Fact]
        public void Deve_Criar_ProvaAreaAdministrativoRetornoDto_Completo()
        {
            var dto = new ProvaAreaAdministrativoRetornoDto
            {
                Id = 5,
                Descricao = "Avaliação Diagnóstica",
                DataInicio = new DateTime(2024, 4, 1),
                DataFim = new DateTime(2024, 4, 30),
                InicioDownload = new DateTime(2024, 3, 25),
                TempoExecucao = 45,
                PossuiBIB = true,
                TotalCadernos = 3,
                TotalItens = 25,
                PossuiContexto = true,
                Senha = "abc"
            };

            Assert.Equal(5, dto.Id);
            Assert.Equal("Avaliação Diagnóstica", dto.Descricao);
            Assert.Equal(new DateTime(2024, 4, 1), dto.DataInicio);
            Assert.Equal(new DateTime(2024, 4, 30), dto.DataFim);
            Assert.Equal(new DateTime(2024, 3, 25), dto.InicioDownload);
            Assert.Equal(45, dto.TempoExecucao);
            Assert.True(dto.PossuiBIB);
            Assert.Equal(3, dto.TotalCadernos);
            Assert.Equal(25, dto.TotalItens);
            Assert.True(dto.PossuiContexto);
            Assert.Equal("abc", dto.Senha);
        }

        [Fact]
        public void Deve_Aceitar_InicioDownload_Nulo()
        {
            var dto = new ProvaAreaAdministrativoRetornoDto { InicioDownload = null };
            Assert.Null(dto.InicioDownload);
        }

        [Fact]
        public void Deve_Aceitar_Senha_Nula()
        {
            var dto = new ProvaAreaAdministrativoRetornoDto { Senha = null };
            Assert.Null(dto.Senha);
        }

        [Fact]
        public void DataInicio_Deve_Ser_Anterior_Ou_Igual_A_DataFim()
        {
            var dto = new ProvaAreaAdministrativoRetornoDto
            {
                DataInicio = new DateTime(2024, 1, 1),
                DataFim = new DateTime(2024, 12, 31)
            };

            Assert.True(dto.DataInicio <= dto.DataFim);
        }
    }
}