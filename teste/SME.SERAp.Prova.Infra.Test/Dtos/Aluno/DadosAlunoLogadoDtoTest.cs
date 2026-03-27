using SME.SERAp.Prova.Infra.Dtos.Aluno;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Aluno
{
    public class DadosAlunoLogadoDtoTest
    {
        [Fact]
        public void Deve_Criar_DadosAlunoLogadoDto_Com_Construtor_Parametros()
        {
            var dto = new DadosAlunoLogadoDto(123456, "device-001");

            Assert.Equal(123456, dto.Ra);
            Assert.Equal("device-001", dto.DispositivoId);
        }

        [Fact]
        public void Deve_Criar_DadosAlunoLogadoDto_Com_Ra_Maximo()
        {
            var dto = new DadosAlunoLogadoDto(long.MaxValue, "device-max");

            Assert.Equal(long.MaxValue, dto.Ra);
        }

        [Fact]
        public void Deve_Criar_DadosAlunoLogadoDto_Com_DispositivoId_Nulo()
        {
            var dto = new DadosAlunoLogadoDto(1, null);

            Assert.Null(dto.DispositivoId);
        }

        [Fact]
        public void Deve_Criar_DadosAlunoLogadoDto_Com_DispositivoId_Vazio()
        {
            var dto = new DadosAlunoLogadoDto(1, "");

            Assert.Equal("", dto.DispositivoId);
        }

        [Fact]
        public void Deve_Alterar_Ra_Apos_Criacao()
        {
            var dto = new DadosAlunoLogadoDto(100, "dev");
            dto.Ra = 200;

            Assert.Equal(200, dto.Ra);
        }

        [Fact]
        public void Deve_Alterar_DispositivoId_Apos_Criacao()
        {
            var dto = new DadosAlunoLogadoDto(100, "device-original");
            dto.DispositivoId = "device-novo";

            Assert.Equal("device-novo", dto.DispositivoId);
        }

        [Fact]
        public void Dois_Dtos_Com_Mesmo_Ra_Devem_Ter_DispositivoId_Independentes()
        {
            var dto1 = new DadosAlunoLogadoDto(999, "device-A");
            var dto2 = new DadosAlunoLogadoDto(999, "device-B");

            Assert.Equal(dto1.Ra, dto2.Ra);
            Assert.NotEqual(dto1.DispositivoId, dto2.DispositivoId);
        }
    }
}