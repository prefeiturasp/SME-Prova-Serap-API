using System.Text.Json;
using SME.SERAp.Prova.Infra.Dtos.ApiR;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.ApiR
{
    public class ObterProximaQuestaoTaiDtoTest
    {
        [Fact]
        public void Deve_Criar_ObterProximaQuestaoTaiDto_Com_Propriedades_Padrao()
        {
            var dto = new ObterProximaQuestaoTaiDto();

            Assert.Null(dto.Estudante);
            Assert.Null(dto.AnoEscolarEstudante);
            Assert.Null(dto.Proficiencia);
            Assert.Null(dto.ProficienciaInicial);
            Assert.Null(dto.IdItem);
            Assert.Null(dto.ParA);
            Assert.Null(dto.ParB);
            Assert.Null(dto.ParC);
            Assert.Null(dto.Administrado);
            Assert.Null(dto.Respostas);
            Assert.Null(dto.Gabarito);
            Assert.Null(dto.ErroPadrao);
            Assert.Equal(0, dto.NIj);
            Assert.Null(dto.Componente);
            Assert.Null(dto.idEixo);
            Assert.Null(dto.idHabilidade);
        }

        [Fact]
        public void Deve_Atribuir_Estudante_Corretamente()
        {
            var dto = new ObterProximaQuestaoTaiDto { Estudante = "12345" };
            Assert.Equal("12345", dto.Estudante);
        }

        [Fact]
        public void Deve_Atribuir_AnoEscolarEstudante_Corretamente()
        {
            var dto = new ObterProximaQuestaoTaiDto { AnoEscolarEstudante = "5" };
            Assert.Equal("5", dto.AnoEscolarEstudante);
        }

        [Fact]
        public void Deve_Atribuir_Proficiencia_Corretamente()
        {
            var dto = new ObterProximaQuestaoTaiDto { Proficiencia = "275.5" };
            Assert.Equal("275.5", dto.Proficiencia);
        }

        [Fact]
        public void Deve_Atribuir_ProficienciaInicial_Corretamente()
        {
            var dto = new ObterProximaQuestaoTaiDto { ProficienciaInicial = "250.0" };
            Assert.Equal("250.0", dto.ProficienciaInicial);
        }

        [Fact]
        public void Deve_Atribuir_IdItem_Corretamente()
        {
            var dto = new ObterProximaQuestaoTaiDto { IdItem = "987" };
            Assert.Equal("987", dto.IdItem);
        }

        [Fact]
        public void Deve_Atribuir_ParA_Corretamente()
        {
            var dto = new ObterProximaQuestaoTaiDto { ParA = "1.2" };
            Assert.Equal("1.2", dto.ParA);
        }

        [Fact]
        public void Deve_Atribuir_ParB_Corretamente()
        {
            var dto = new ObterProximaQuestaoTaiDto { ParB = "-0.5" };
            Assert.Equal("-0.5", dto.ParB);
        }

        [Fact]
        public void Deve_Atribuir_ParC_Corretamente()
        {
            var dto = new ObterProximaQuestaoTaiDto { ParC = "0.25" };
            Assert.Equal("0.25", dto.ParC);
        }

        [Fact]
        public void Deve_Atribuir_Administrado_Corretamente()
        {
            var dto = new ObterProximaQuestaoTaiDto { Administrado = "1,2,3" };
            Assert.Equal("1,2,3", dto.Administrado);
        }

        [Fact]
        public void Deve_Atribuir_Respostas_Corretamente()
        {
            var dto = new ObterProximaQuestaoTaiDto { Respostas = "A,B,C" };
            Assert.Equal("A,B,C", dto.Respostas);
        }

        [Fact]
        public void Deve_Atribuir_Gabarito_Corretamente()
        {
            var dto = new ObterProximaQuestaoTaiDto { Gabarito = "A,A,B" };
            Assert.Equal("A,A,B", dto.Gabarito);
        }

        [Fact]
        public void Deve_Atribuir_ErroPadrao_Corretamente()
        {
            var dto = new ObterProximaQuestaoTaiDto { ErroPadrao = "0.03" };
            Assert.Equal("0.03", dto.ErroPadrao);
        }

        [Fact]
        public void Deve_Atribuir_NIj_Corretamente()
        {
            var dto = new ObterProximaQuestaoTaiDto { NIj = 10 };
            Assert.Equal(10, dto.NIj);
        }

        [Fact]
        public void Deve_Atribuir_Componente_Corretamente()
        {
            var dto = new ObterProximaQuestaoTaiDto { Componente = "MAT" };
            Assert.Equal("MAT", dto.Componente);
        }

        [Fact]
        public void Deve_Atribuir_IdEixo_Corretamente()
        {
            var dto = new ObterProximaQuestaoTaiDto { idEixo = "E01" };
            Assert.Equal("E01", dto.idEixo);
        }

        [Fact]
        public void Deve_Atribuir_IdHabilidade_Corretamente()
        {
            var dto = new ObterProximaQuestaoTaiDto { idHabilidade = "H05" };
            Assert.Equal("H05", dto.idHabilidade);
        }

        [Fact]
        public void Deve_Criar_ObterProximaQuestaoTaiDto_Completo()
        {
            var dto = new ObterProximaQuestaoTaiDto
            {
                Estudante = "99999",
                AnoEscolarEstudante = "9",
                Proficiencia = "310.0",
                ProficienciaInicial = "260.0",
                IdItem = "456",
                ParA = "0.9",
                ParB = "-1.2",
                ParC = "0.15",
                Administrado = "100,200",
                Respostas = "B,C",
                Gabarito = "B,B",
                ErroPadrao = "0.07",
                NIj = 5,
                Componente = "PORT",
                idEixo = "E02",
                idHabilidade = "H10"
            };

            Assert.Equal("99999", dto.Estudante);
            Assert.Equal("9", dto.AnoEscolarEstudante);
            Assert.Equal("310.0", dto.Proficiencia);
            Assert.Equal("260.0", dto.ProficienciaInicial);
            Assert.Equal("456", dto.IdItem);
            Assert.Equal("0.9", dto.ParA);
            Assert.Equal("-1.2", dto.ParB);
            Assert.Equal("0.15", dto.ParC);
            Assert.Equal("100,200", dto.Administrado);
            Assert.Equal("B,C", dto.Respostas);
            Assert.Equal("B,B", dto.Gabarito);
            Assert.Equal("0.07", dto.ErroPadrao);
            Assert.Equal(5, dto.NIj);
            Assert.Equal("PORT", dto.Componente);
            Assert.Equal("E02", dto.idEixo);
            Assert.Equal("H10", dto.idHabilidade);
        }

        [Fact]
        public void Deve_Serializar_Com_JsonPropertyName_Estudante()
        {
            var dto = new ObterProximaQuestaoTaiDto { Estudante = "ABC" };
            var json = JsonSerializer.Serialize(dto);
            Assert.Contains("\"ESTUDANTE\"", json);
        }

        [Fact]
        public void Deve_Serializar_Com_JsonPropertyName_Proficiencia()
        {
            var dto = new ObterProximaQuestaoTaiDto { Proficiencia = "300" };
            var json = JsonSerializer.Serialize(dto);
            Assert.Contains("\"proficiencia\"", json);
        }

        [Fact]
        public void Deve_Serializar_Com_JsonPropertyName_IdItem()
        {
            var dto = new ObterProximaQuestaoTaiDto { IdItem = "123" };
            var json = JsonSerializer.Serialize(dto);
            Assert.Contains("\"idItem\"", json);
        }

        [Fact]
        public void Deve_Serializar_Com_JsonPropertyName_Administrado()
        {
            var dto = new ObterProximaQuestaoTaiDto { Administrado = "1" };
            var json = JsonSerializer.Serialize(dto);
            Assert.Contains("\"administrado\"", json);
        }

        [Fact]
        public void Deve_Serializar_Com_JsonPropertyName_ErroPadrao()
        {
            var dto = new ObterProximaQuestaoTaiDto { ErroPadrao = "0.01" };
            var json = JsonSerializer.Serialize(dto);
            Assert.Contains("\"erropadrao\"", json);
        }

        [Fact]
        public void Deve_Desserializar_Com_JsonPropertyName_Corretamente()
        {
            var json = "{\"ESTUDANTE\":\"42\",\"AnoEscolarEstudante\":\"7\",\"proficiencia\":\"290\",\"n.Ij\":3}";
            var dto = JsonSerializer.Deserialize<ObterProximaQuestaoTaiDto>(json);

            Assert.Equal("42", dto!.Estudante);
            Assert.Equal("7", dto.AnoEscolarEstudante);
            Assert.Equal("290", dto.Proficiencia);
            Assert.Equal(3, dto.NIj);
        }

        [Fact]
        public void Deve_Aceitar_NIj_Zero()
        {
            var dto = new ObterProximaQuestaoTaiDto { NIj = 0 };
            Assert.Equal(0, dto.NIj);
        }

        [Fact]
        public void Deve_Aceitar_Campos_String_Vazios()
        {
            var dto = new ObterProximaQuestaoTaiDto
            {
                Estudante = string.Empty,
                Proficiencia = string.Empty,
                ErroPadrao = string.Empty
            };

            Assert.Equal(string.Empty, dto.Estudante);
            Assert.Equal(string.Empty, dto.Proficiencia);
            Assert.Equal(string.Empty, dto.ErroPadrao);
        }
    }
}