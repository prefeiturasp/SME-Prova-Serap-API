using System;
using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Prova
{
    public class ProvaAlunoStatusDtoTest
    {
        [Fact]
        public void Deve_Criar_ProvaAlunoStatusDto_Com_Construtor_Parametros()
        {
            var dto = new ProvaAlunoStatusDto(1, 1000L, 2000L, 2);

            Assert.Equal(1, dto.Status);
            Assert.Equal(1000L, dto.DataInicio);
            Assert.Equal(2000L, dto.DataFim);
            Assert.Equal(2, dto.TipoDispositivo);
        }

        [Fact]
        public void Deve_Aceitar_DataInicio_Nula()
        {
            var dto = new ProvaAlunoStatusDto(1, null, 2000L, 1);
            Assert.Null(dto.DataInicio);
        }

        [Fact]
        public void Deve_Aceitar_DataFim_Nula()
        {
            var dto = new ProvaAlunoStatusDto(1, 1000L, null, 1);
            Assert.Null(dto.DataFim);
        }

        [Fact]
        public void Deve_Aceitar_TipoDispositivo_Nulo()
        {
            var dto = new ProvaAlunoStatusDto(1, 1000L, 2000L, null);
            Assert.Null(dto.TipoDispositivo);
        }

        [Fact]
        public void Deve_Aceitar_Todos_Os_Parametros_Nulos_Exceto_Status()
        {
            var dto = new ProvaAlunoStatusDto(0, null, null, null);

            Assert.Equal(0, dto.Status);
            Assert.Null(dto.DataInicio);
            Assert.Null(dto.DataFim);
            Assert.Null(dto.TipoDispositivo);
        }

        [Fact]
        public void DataMenos3Horas_Deve_Retornar_Data_Subtraindo_3_Horas_Quando_Valor_Informado()
        {
            var dataOriginal = new DateTime(2024, 6, 15, 12, 0, 0);
            var ticks = dataOriginal.Ticks;
            var dto = new ProvaAlunoStatusDto(1, ticks, null, null);

            var resultado = dto.DataMenos3Horas(ticks);

            Assert.NotNull(resultado);
            Assert.Equal(dataOriginal.AddHours(-3), resultado);
        }

        [Fact]
        public void DataMenos3Horas_Deve_Retornar_Agora_Menos_3_Horas_Quando_Nulo()
        {
            var dto = new ProvaAlunoStatusDto(1, null, null, null);
            var antes = DateTime.Now.AddHours(-3).AddSeconds(-1);

            var resultado = dto.DataMenos3Horas(null);

            var depois = DateTime.Now.AddHours(-3).AddSeconds(1);

            Assert.NotNull(resultado);
            Assert.True(resultado >= antes && resultado <= depois);
        }

        [Fact]
        public void Deve_Aceitar_Status_Zero()
        {
            var dto = new ProvaAlunoStatusDto(0, null, null, null);
            Assert.Equal(0, dto.Status);
        }

        [Fact]
        public void Deve_Aceitar_Status_Negativo()
        {
            var dto = new ProvaAlunoStatusDto(-1, null, null, null);
            Assert.Equal(-1, dto.Status);
        }

        [Fact]
        public void Deve_Permitir_Alterar_Propriedades_Apos_Construcao()
        {
            var dto = new ProvaAlunoStatusDto(1, 100L, 200L, 1);
            dto.Status = 3;
            dto.DataInicio = 999L;
            dto.DataFim = 1999L;
            dto.TipoDispositivo = 5;

            Assert.Equal(3, dto.Status);
            Assert.Equal(999L, dto.DataInicio);
            Assert.Equal(1999L, dto.DataFim);
            Assert.Equal(5, dto.TipoDispositivo);
        }
    }
}