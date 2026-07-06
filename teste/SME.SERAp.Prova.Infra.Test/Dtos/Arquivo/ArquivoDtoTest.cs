using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Arquivo
{
    public class ArquivoDtoTest
    {
        [Fact]
        public void Deve_Criar_ArquivoDto_Com_Propriedades_Padrao()
        {
            var dto = new ArquivoDto();

            Assert.Equal(0, dto.Id);
            Assert.Equal(0, dto.LegadoId);
            Assert.Equal(0, dto.QuestaoId);
            Assert.Null(dto.Caminho);
            Assert.Equal(0, dto.TamanhoBytes);
        }

        [Fact]
        public void Deve_Atribuir_Id_Corretamente()
        {
            var dto = new ArquivoDto { Id = 15 };
            Assert.Equal(15, dto.Id);
        }

        [Fact]
        public void Deve_Atribuir_LegadoId_Corretamente()
        {
            var dto = new ArquivoDto { LegadoId = 30 };
            Assert.Equal(30, dto.LegadoId);
        }

        [Fact]
        public void Deve_Atribuir_QuestaoId_Corretamente()
        {
            var dto = new ArquivoDto { QuestaoId = 55 };
            Assert.Equal(55, dto.QuestaoId);
        }

        [Fact]
        public void Deve_Atribuir_Caminho_Corretamente()
        {
            var dto = new ArquivoDto { Caminho = "/arquivos/documento.pdf" };
            Assert.Equal("/arquivos/documento.pdf", dto.Caminho);
        }

        [Fact]
        public void Deve_Atribuir_TamanhoBytes_Corretamente()
        {
            var dto = new ArquivoDto { TamanhoBytes = 204800 };
            Assert.Equal(204800, dto.TamanhoBytes);
        }

        [Fact]
        public void Deve_Criar_ArquivoDto_Completo()
        {
            var dto = new ArquivoDto
            {
                Id = 1,
                LegadoId = 2,
                QuestaoId = 3,
                Caminho = "/arquivos/imagem.jpg",
                TamanhoBytes = 102400
            };

            Assert.Equal(1, dto.Id);
            Assert.Equal(2, dto.LegadoId);
            Assert.Equal(3, dto.QuestaoId);
            Assert.Equal("/arquivos/imagem.jpg", dto.Caminho);
            Assert.Equal(102400, dto.TamanhoBytes);
        }

        [Fact]
        public void Deve_Aceitar_Caminho_Nulo()
        {
            var dto = new ArquivoDto { Caminho = null };
            Assert.Null(dto.Caminho);
        }

        [Fact]
        public void Deve_Aceitar_Caminho_Vazio()
        {
            var dto = new ArquivoDto { Caminho = string.Empty };
            Assert.Equal(string.Empty, dto.Caminho);
        }

        [Fact]
        public void Deve_Aceitar_Valor_Maximo_Long_Em_TamanhoBytes()
        {
            var dto = new ArquivoDto { TamanhoBytes = long.MaxValue };
            Assert.Equal(long.MaxValue, dto.TamanhoBytes);
        }

        [Fact]
        public void Deve_Aceitar_Id_E_LegadoId_Diferentes()
        {
            var dto = new ArquivoDto { Id = 10, LegadoId = 99 };

            Assert.NotEqual(dto.Id, dto.LegadoId);
        }

        [Fact]
        public void Deve_Aceitar_Id_E_LegadoId_Iguais()
        {
            var dto = new ArquivoDto { Id = 7, LegadoId = 7 };

            Assert.Equal(dto.Id, dto.LegadoId);
        }
    }
}