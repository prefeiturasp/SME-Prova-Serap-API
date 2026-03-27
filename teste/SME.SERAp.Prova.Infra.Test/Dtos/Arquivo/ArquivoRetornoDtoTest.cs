using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Arquivo
{
    public class ArquivoRetornoDtoTest
    {
        [Fact]
        public void Deve_Criar_ArquivoRetornoDto_Com_Construtor_Padrao()
        {
            var dto = new ArquivoRetornoDto();

            Assert.Equal(0, dto.Id);
            Assert.Equal(0, dto.LegadoId);
            Assert.Null(dto.Caminho);
            Assert.Equal(0, dto.QuestaoId);
        }

        [Fact]
        public void Deve_Criar_ArquivoRetornoDto_Com_Id_E_Caminho()
        {
            var dto = new ArquivoRetornoDto(1, "/arquivos/imagem.png");

            Assert.Equal(1, dto.Id);
            Assert.Equal(1, dto.LegadoId);
            Assert.Equal("/arquivos/imagem.png", dto.Caminho);
            Assert.Equal(0, dto.QuestaoId);
        }

        [Fact]
        public void Deve_Criar_ArquivoRetornoDto_Com_Id_Caminho_E_QuestaoId()
        {
            var dto = new ArquivoRetornoDto(5, "/arquivos/audio.mp3", 99);

            Assert.Equal(5, dto.Id);
            Assert.Equal(5, dto.LegadoId);
            Assert.Equal("/arquivos/audio.mp3", dto.Caminho);
            Assert.Equal(99, dto.QuestaoId);
        }

        [Fact]
        public void Deve_Garantir_Id_E_LegadoId_Iguais_No_Construtor_Dois_Params()
        {
            var dto = new ArquivoRetornoDto(77, "/path");

            Assert.Equal(dto.Id, dto.LegadoId);
        }

        [Fact]
        public void Deve_Garantir_Id_E_LegadoId_Iguais_No_Construtor_Tres_Params()
        {
            var dto = new ArquivoRetornoDto(88, "/path", 10);

            Assert.Equal(dto.Id, dto.LegadoId);
        }

        [Fact]
        public void Deve_Atribuir_Propriedades_Via_Inicializador()
        {
            var dto = new ArquivoRetornoDto
            {
                Id = 3,
                LegadoId = 4,
                Caminho = "/outro/caminho",
                QuestaoId = 7
            };

            Assert.Equal(3, dto.Id);
            Assert.Equal(4, dto.LegadoId);
            Assert.Equal("/outro/caminho", dto.Caminho);
            Assert.Equal(7, dto.QuestaoId);
        }

        [Fact]
        public void Deve_Aceitar_Id_Zero()
        {
            var dto = new ArquivoRetornoDto(0, "/vazio");

            Assert.Equal(0, dto.Id);
            Assert.Equal(0, dto.LegadoId);
        }

        [Fact]
        public void Deve_Aceitar_Caminho_Nulo_No_Construtor()
        {
            var dto = new ArquivoRetornoDto(1, null);

            Assert.Null(dto.Caminho);
        }

        [Fact]
        public void Deve_Aceitar_Caminho_Vazio_No_Construtor()
        {
            var dto = new ArquivoRetornoDto(1, string.Empty);

            Assert.Equal(string.Empty, dto.Caminho);
        }

        [Fact]
        public void Deve_Aceitar_Valor_Maximo_Long_No_Id()
        {
            var dto = new ArquivoRetornoDto(long.MaxValue, "/max");

            Assert.Equal(long.MaxValue, dto.Id);
            Assert.Equal(long.MaxValue, dto.LegadoId);
        }

        [Fact]
        public void Deve_Aceitar_QuestaoId_Zero_No_Construtor_Tres_Params()
        {
            var dto = new ArquivoRetornoDto(1, "/path", 0);

            Assert.Equal(0, dto.QuestaoId);
        }
    }
}