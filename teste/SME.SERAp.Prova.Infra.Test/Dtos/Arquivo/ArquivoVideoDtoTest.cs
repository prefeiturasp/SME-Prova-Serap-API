using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Arquivo
{
    public class ArquivoVideoDtoTest
    {
        [Fact]
        public void Deve_Criar_ArquivoVideoDto_Com_Propriedades_Padrao()
        {
            var dto = new ArquivoVideoDto();

            Assert.Equal(0, dto.QuestaoId);
            Assert.Equal(0, dto.Id);
            Assert.Null(dto.Caminho);
            Assert.Equal(0, dto.TamanhoBytes);
            Assert.Null(dto.CaminhoVideoConvertido);
            Assert.Equal(0, dto.VideoConvertidoTamanhoBytes);
            Assert.Null(dto.CaminhoVideoThumbinail);
            Assert.Equal(0, dto.VideoThumbinailTamanhoBytes);
        }

        [Fact]
        public void Deve_Atribuir_QuestaoId_Corretamente()
        {
            var dto = new ArquivoVideoDto { QuestaoId = 42 };
            Assert.Equal(42, dto.QuestaoId);
        }

        [Fact]
        public void Deve_Atribuir_Id_Corretamente()
        {
            var dto = new ArquivoVideoDto { Id = 99 };
            Assert.Equal(99, dto.Id);
        }

        [Fact]
        public void Deve_Atribuir_Caminho_Corretamente()
        {
            var dto = new ArquivoVideoDto { Caminho = "/videos/arquivo.mp4" };
            Assert.Equal("/videos/arquivo.mp4", dto.Caminho);
        }

        [Fact]
        public void Deve_Atribuir_TamanhoBytes_Corretamente()
        {
            var dto = new ArquivoVideoDto { TamanhoBytes = 1048576 };
            Assert.Equal(1048576, dto.TamanhoBytes);
        }

        [Fact]
        public void Deve_Atribuir_CaminhoVideoConvertido_Corretamente()
        {
            var dto = new ArquivoVideoDto { CaminhoVideoConvertido = "/videos/convertido.mp4" };
            Assert.Equal("/videos/convertido.mp4", dto.CaminhoVideoConvertido);
        }

        [Fact]
        public void Deve_Atribuir_VideoConvertidoTamanhoBytes_Corretamente()
        {
            var dto = new ArquivoVideoDto { VideoConvertidoTamanhoBytes = 2097152 };
            Assert.Equal(2097152, dto.VideoConvertidoTamanhoBytes);
        }

        [Fact]
        public void Deve_Atribuir_CaminhoVideoThumbinail_Corretamente()
        {
            var dto = new ArquivoVideoDto { CaminhoVideoThumbinail = "/thumbs/thumb.jpg" };
            Assert.Equal("/thumbs/thumb.jpg", dto.CaminhoVideoThumbinail);
        }

        [Fact]
        public void Deve_Atribuir_VideoThumbinailTamanhoBytes_Corretamente()
        {
            var dto = new ArquivoVideoDto { VideoThumbinailTamanhoBytes = 512000 };
            Assert.Equal(512000, dto.VideoThumbinailTamanhoBytes);
        }

        [Fact]
        public void Deve_Criar_ArquivoVideoDto_Completo()
        {
            var dto = new ArquivoVideoDto
            {
                QuestaoId = 10,
                Id = 20,
                Caminho = "/videos/original.mp4",
                TamanhoBytes = 1000000,
                CaminhoVideoConvertido = "/videos/convertido.mp4",
                VideoConvertidoTamanhoBytes = 800000,
                CaminhoVideoThumbinail = "/thumbs/thumb.jpg",
                VideoThumbinailTamanhoBytes = 50000
            };

            Assert.Equal(10, dto.QuestaoId);
            Assert.Equal(20, dto.Id);
            Assert.Equal("/videos/original.mp4", dto.Caminho);
            Assert.Equal(1000000, dto.TamanhoBytes);
            Assert.Equal("/videos/convertido.mp4", dto.CaminhoVideoConvertido);
            Assert.Equal(800000, dto.VideoConvertidoTamanhoBytes);
            Assert.Equal("/thumbs/thumb.jpg", dto.CaminhoVideoThumbinail);
            Assert.Equal(50000, dto.VideoThumbinailTamanhoBytes);
        }

        [Fact]
        public void Deve_Aceitar_Valores_Negativos_Em_TamanhoBytes()
        {
            var dto = new ArquivoVideoDto { TamanhoBytes = -1 };
            Assert.Equal(-1, dto.TamanhoBytes);
        }

        [Fact]
        public void Deve_Aceitar_Valor_Maximo_Long_Em_TamanhoBytes()
        {
            var dto = new ArquivoVideoDto { TamanhoBytes = long.MaxValue };
            Assert.Equal(long.MaxValue, dto.TamanhoBytes);
        }

        [Fact]
        public void Deve_Aceitar_Caminho_Nulo()
        {
            var dto = new ArquivoVideoDto { Caminho = null };
            Assert.Null(dto.Caminho);
        }

        [Fact]
        public void Deve_Aceitar_Caminho_Vazio()
        {
            var dto = new ArquivoVideoDto { Caminho = string.Empty };
            Assert.Equal(string.Empty, dto.Caminho);
        }
    }
}