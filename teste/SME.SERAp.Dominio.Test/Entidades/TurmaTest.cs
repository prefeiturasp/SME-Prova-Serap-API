using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class TurmaTest
    {
        [Fact]
        public void Deve_Criar_Turma_Com_Construtor_Padrao()
        {
            var turma = new Turma
            {
                Ano = "5",
                AnoLetivo = 2024,
                TipoTurma = 1,
                Modalidade = 3,
                TipoTurno = 2,
                Semestre = 1,
                EtapaEja = 0,
                SerieEnsino = "EF"
            };

            Assert.Equal("5", turma.Ano);
            Assert.Equal(2024, turma.AnoLetivo);
            Assert.Equal(1, turma.TipoTurma);
            Assert.Equal(3, turma.Modalidade);
            Assert.Equal(2, turma.TipoTurno);
            Assert.Equal(1, turma.Semestre);
            Assert.Equal(0, turma.EtapaEja);
            Assert.Equal("EF", turma.SerieEnsino);
        }

        [Fact]
        public void Deve_Criar_Turma_Com_Valores_Default()
        {
            var turma = new Turma();

            Assert.Null(turma.Ano);
            Assert.Equal(0, turma.AnoLetivo);
            Assert.Equal(0, turma.TipoTurma);
            Assert.Equal(0, turma.Modalidade);
            Assert.Equal(0, turma.TipoTurno);
            Assert.Equal(0, turma.Semestre);
            Assert.Equal(0, turma.EtapaEja);
            Assert.Null(turma.SerieEnsino);
        }

        [Fact]
        public void Deve_Criar_Turma_Com_Ano_Nulo()
        {
            var turma = new Turma { Ano = null };

            Assert.Null(turma.Ano);
        }

        [Fact]
        public void Deve_Criar_Turma_Com_SerieEnsino_Nula()
        {
            var turma = new Turma { SerieEnsino = null };

            Assert.Null(turma.SerieEnsino);
        }

        [Fact]
        public void Deve_Criar_Turma_Com_TipoTurno_Maximo()
        {
            var turma = new Turma { TipoTurno = long.MaxValue };

            Assert.Equal(long.MaxValue, turma.TipoTurno);
        }

        [Fact]
        public void Deve_Criar_Turma_Com_Semestre_Dois()
        {
            var turma = new Turma { Semestre = 2 };

            Assert.Equal(2, turma.Semestre);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var turma = new Turma { Ano = "3", AnoLetivo = 2023 };
            turma.Ano = "4";
            turma.AnoLetivo = 2024;
            turma.TipoTurma = 2;

            Assert.Equal("4", turma.Ano);
            Assert.Equal(2024, turma.AnoLetivo);
            Assert.Equal(2, turma.TipoTurma);
        }

        [Fact]
        public void Deve_Criar_Turma_Com_EtapaEja_Preenchida()
        {
            var turma = new Turma { EtapaEja = 3 };

            Assert.Equal(3, turma.EtapaEja);
        }

        [Fact]
        public void Deve_Criar_Turma_Herdando_EntidadeBase()
        {
            var turma = new Turma();
            turma.Id = 50;

            Assert.Equal(50, turma.Id);
        }
    }
}