using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Infra.Test.Dtos.Autenticacao
{
    public class MeusDadosRetornoDtoTest
    {
        private MeusDadosRetornoDto CriarDtoPadrao()
        {
            return new MeusDadosRetornoDto(1, "DRE-01", "Escola A", "5A", "João", "5", "Manhã", 14, Modalidade.Fundamental, 1, 480, 720, new[] { 5, 11 });
        }

        [Fact]
        public void Deve_Criar_MeusDadosRetornoDto_Com_Construtor_Parametros()
        {
            var deficiencias = new[] { 5, 11 };

            var dto = new MeusDadosRetornoDto(1, "DRE-01", "Escola A", "5A", "João", "5", "Manhã", 14, Modalidade.Fundamental, 1, 480, 720, deficiencias);

            Assert.Equal(1, dto.AlunoId);
            Assert.Equal("DRE-01", dto.DreAbreviacao);
            Assert.Equal("Escola A", dto.Escola);
            Assert.Equal("5A", dto.Turma);
            Assert.Equal("João", dto.Nome);
            Assert.Equal("5", dto.Ano);
            Assert.Equal("Manhã", dto.TipoTurno);
            Assert.Equal(14, dto.TamanhoFonte);
            Assert.Equal(Modalidade.Fundamental, dto.Modalidade);
            Assert.Equal(1, dto.FamiliaFonte);
            Assert.Equal(480, dto.InicioTurno);
            Assert.Equal(720, dto.FimTurno);
            Assert.Equal(deficiencias, dto.Deficiencias);
        }

        [Fact]
        public void Deve_Criar_MeusDadosRetornoDto_Com_Deficiencias_Nulas()
        {
            var dto = new MeusDadosRetornoDto(1, "DRE", "Escola", "5A", "Nome", "5", "Manhã", 14, Modalidade.Fundamental, 1, 480, 720, null);

            Assert.Null(dto.Deficiencias);
        }

        [Fact]
        public void Deve_Criar_MeusDadosRetornoDto_Com_Deficiencias_Vazias()
        {
            var dto = new MeusDadosRetornoDto(1, "DRE", "Escola", "5A", "Nome", "5", "Manhã", 14, Modalidade.Fundamental, 1, 480, 720, Array.Empty<int>());

            Assert.Empty(dto.Deficiencias);
        }

        [Fact]
        public void Deve_Criar_MeusDadosRetornoDto_Com_Modalidade_EJA()
        {
            var dto = new MeusDadosRetornoDto(1, "DRE", "Escola", "5A", "Nome", "5", "Noite", 14, Modalidade.EJA, 1, 480, 720, null);

            Assert.Equal(Modalidade.EJA, dto.Modalidade);
        }

        [Fact]
        public void Deve_Criar_MeusDadosRetornoDto_Com_Nome_Nulo()
        {
            var dto = new MeusDadosRetornoDto(1, "DRE", "Escola", "5A", null, "5", "Manhã", 14, Modalidade.Fundamental, 1, 480, 720, null);

            Assert.Null(dto.Nome);
        }

        [Fact]
        public void Deve_Criar_MeusDadosRetornoDto_Com_AlunoId_Maximo()
        {
            var dto = new MeusDadosRetornoDto(long.MaxValue, "DRE", "Escola", "5A", "Nome", "5", "Manhã", 14, Modalidade.Fundamental, 1, 480, 720, null);

            Assert.Equal(long.MaxValue, dto.AlunoId);
        }

        [Fact]
        public void Deve_Criar_MeusDadosRetornoDto_Com_InicioTurno_Menor_Que_FimTurno()
        {
            var dto = CriarDtoPadrao();

            Assert.True(dto.InicioTurno < dto.FimTurno);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var dto = CriarDtoPadrao();
            dto.Nome = "Alterado";
            dto.TamanhoFonte = 16;

            Assert.Equal("Alterado", dto.Nome);
            Assert.Equal(16, dto.TamanhoFonte);
        }

        [Fact]
        public void Deve_Criar_MeusDadosRetornoDto_Com_Uma_Deficiencia()
        {
            var dto = new MeusDadosRetornoDto(1, "DRE", "Escola", "5A", "Nome", "5", "Manhã", 14, Modalidade.Fundamental, 1, 480, 720, new[] { 11 });

            Assert.Single(dto.Deficiencias);
            Assert.Equal(11, dto.Deficiencias[0]);
        }
    }
}