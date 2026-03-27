using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Autenticacao
{
    public class ObterAlunoAtivoRetornoDtoTest
    {
        [Fact]
        public void Deve_Criar_ObterAlunoAtivoRetornoDto_Com_Construtor_Padrao()
        {
            var nascimento = new DateTime(2010, 5, 1);

            var dto = new ObterAlunoAtivoRetornoDto
            {
                Ra = 123456,
                Ano = "5",
                TipoTurno = 1,
                Modalidade = Modalidade.Fundamental,
                TurmaId = 99,
                DataNascimento = nascimento
            };

            Assert.Equal(123456, dto.Ra);
            Assert.Equal("5", dto.Ano);
            Assert.Equal(1, dto.TipoTurno);
            Assert.Equal(Modalidade.Fundamental, dto.Modalidade);
            Assert.Equal(99, dto.TurmaId);
            Assert.Equal(nascimento, dto.DataNascimento);
        }

        [Fact]
        public void Deve_Criar_ObterAlunoAtivoRetornoDto_Com_Valores_Default()
        {
            var dto = new ObterAlunoAtivoRetornoDto();

            Assert.Equal(0, dto.Ra);
            Assert.Null(dto.Ano);
            Assert.Equal(0, dto.TipoTurno);
            Assert.Equal(default(Modalidade), dto.Modalidade);
            Assert.Null(dto.TurmaId);
            Assert.Equal(default(DateTime), dto.DataNascimento);
        }

        [Fact]
        public void Deve_Criar_ObterAlunoAtivoRetornoDto_Com_TurmaId_Nulo()
        {
            var dto = new ObterAlunoAtivoRetornoDto { TurmaId = null };

            Assert.Null(dto.TurmaId);
        }

        [Fact]
        public void Deve_Criar_ObterAlunoAtivoRetornoDto_Com_TurmaId_Preenchido()
        {
            var dto = new ObterAlunoAtivoRetornoDto { TurmaId = 42 };

            Assert.NotNull(dto.TurmaId);
            Assert.Equal(42, dto.TurmaId);
        }

        [Fact]
        public void Deve_Criar_ObterAlunoAtivoRetornoDto_Com_Ra_Maximo()
        {
            var dto = new ObterAlunoAtivoRetornoDto { Ra = long.MaxValue };

            Assert.Equal(long.MaxValue, dto.Ra);
        }

        [Fact]
        public void Deve_Criar_ObterAlunoAtivoRetornoDto_Com_Ano_Nulo()
        {
            var dto = new ObterAlunoAtivoRetornoDto { Ano = null };

            Assert.Null(dto.Ano);
        }

        [Fact]
        public void Deve_Criar_ObterAlunoAtivoRetornoDto_Com_Modalidade_EJA()
        {
            var dto = new ObterAlunoAtivoRetornoDto { Modalidade = Modalidade.EJA };

            Assert.Equal(Modalidade.EJA, dto.Modalidade);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var dto = new ObterAlunoAtivoRetornoDto { Ra = 1, Ano = "3" };
            dto.Ra = 999;
            dto.Ano = "9";
            dto.TurmaId = 77;

            Assert.Equal(999, dto.Ra);
            Assert.Equal("9", dto.Ano);
            Assert.Equal(77, dto.TurmaId);
        }
    }
}