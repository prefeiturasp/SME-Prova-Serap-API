using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Prova.Tai
{
    public class ProvaTaiResultadoDtoTest
    {
        [Fact]
        public void Deve_Criar_ProvaTaiResultadoDto_Com_Propriedades_Padrao()
        {
            var dto = new ProvaTaiResultadoDto();

            Assert.Null(dto.DescricaoQuestao);
            Assert.Equal(0, dto.OrdemQuestao);
            Assert.Null(dto.AlternativaAluno);
        }

        [Fact]
        public void Deve_Criar_ProvaTaiResultadoDto_Completo()
        {
            var dto = new ProvaTaiResultadoDto
            {
                DescricaoQuestao = "Qual é o resultado de 2 + 2?",
                OrdemQuestao = 1,
                AlternativaAluno = "A"
            };

            Assert.Equal("Qual é o resultado de 2 + 2?", dto.DescricaoQuestao);
            Assert.Equal(1, dto.OrdemQuestao);
            Assert.Equal("A", dto.AlternativaAluno);
        }

        [Fact]
        public void Deve_Atribuir_DescricaoQuestao_Corretamente()
        {
            var dto = new ProvaTaiResultadoDto { DescricaoQuestao = "Descrição da questão" };

            Assert.Equal("Descrição da questão", dto.DescricaoQuestao);
        }

        [Fact]
        public void Deve_Aceitar_DescricaoQuestao_Nula()
        {
            var dto = new ProvaTaiResultadoDto { DescricaoQuestao = null };

            Assert.Null(dto.DescricaoQuestao);
        }

        [Fact]
        public void Deve_Aceitar_DescricaoQuestao_Vazia()
        {
            var dto = new ProvaTaiResultadoDto { DescricaoQuestao = string.Empty };

            Assert.Equal(string.Empty, dto.DescricaoQuestao);
        }

        [Fact]
        public void Deve_Aceitar_DescricaoQuestao_Longa()
        {
            var descricao = new string('x', 5000);
            var dto = new ProvaTaiResultadoDto { DescricaoQuestao = descricao };

            Assert.Equal(descricao, dto.DescricaoQuestao);
            Assert.Equal(5000, dto.DescricaoQuestao.Length);
        }

        [Fact]
        public void Deve_Atribuir_OrdemQuestao_Corretamente()
        {
            var dto = new ProvaTaiResultadoDto { OrdemQuestao = 5 };

            Assert.Equal(5, dto.OrdemQuestao);
        }

        [Fact]
        public void Deve_Aceitar_OrdemQuestao_Zero()
        {
            var dto = new ProvaTaiResultadoDto { OrdemQuestao = 0 };

            Assert.Equal(0, dto.OrdemQuestao);
        }

        [Fact]
        public void Deve_Aceitar_OrdemQuestao_Negativa()
        {
            var dto = new ProvaTaiResultadoDto { OrdemQuestao = -1 };

            Assert.Equal(-1, dto.OrdemQuestao);
        }

        [Fact]
        public void Deve_Aceitar_OrdemQuestao_Valor_Maximo_Int()
        {
            var dto = new ProvaTaiResultadoDto { OrdemQuestao = int.MaxValue };

            Assert.Equal(int.MaxValue, dto.OrdemQuestao);
        }

        [Fact]
        public void Deve_Atribuir_AlternativaAluno_Corretamente()
        {
            var dto = new ProvaTaiResultadoDto { AlternativaAluno = "B" };

            Assert.Equal("B", dto.AlternativaAluno);
        }

        [Fact]
        public void Deve_Aceitar_AlternativaAluno_Nula()
        {
            var dto = new ProvaTaiResultadoDto { AlternativaAluno = null };

            Assert.Null(dto.AlternativaAluno);
        }

        [Fact]
        public void Deve_Aceitar_AlternativaAluno_Vazia()
        {
            var dto = new ProvaTaiResultadoDto { AlternativaAluno = string.Empty };

            Assert.Equal(string.Empty, dto.AlternativaAluno);
        }

        [Fact]
        public void Deve_Aceitar_Todas_Alternativas_Possiveis()
        {
            foreach (var alternativa in new[] { "A", "B", "C", "D", "E" })
            {
                var dto = new ProvaTaiResultadoDto { AlternativaAluno = alternativa };
                Assert.Equal(alternativa, dto.AlternativaAluno);
            }
        }

        [Fact]
        public void Deve_Permitir_Alterar_Propriedades_Apos_Atribuicao()
        {
            var dto = new ProvaTaiResultadoDto
            {
                DescricaoQuestao = "Questão original",
                OrdemQuestao = 1,
                AlternativaAluno = "A"
            };

            dto.DescricaoQuestao = "Questão alterada";
            dto.OrdemQuestao = 2;
            dto.AlternativaAluno = "C";

            Assert.Equal("Questão alterada", dto.DescricaoQuestao);
            Assert.Equal(2, dto.OrdemQuestao);
            Assert.Equal("C", dto.AlternativaAluno);
        }

        [Fact]
        public void Deve_Aceitar_DescricaoQuestao_Com_Html()
        {
            var html = "<p>Leia o texto e responda:</p><b>Qual a resposta?</b>";
            var dto = new ProvaTaiResultadoDto { DescricaoQuestao = html };

            Assert.Equal(html, dto.DescricaoQuestao);
        }

        [Fact]
        public void Deve_Aceitar_DescricaoQuestao_Com_Caracteres_Especiais()
        {
            var descricao = "Questão nº 1: \"Qual é o valor de π?\"";
            var dto = new ProvaTaiResultadoDto { DescricaoQuestao = descricao };

            Assert.Equal(descricao, dto.DescricaoQuestao);
        }
    }
}