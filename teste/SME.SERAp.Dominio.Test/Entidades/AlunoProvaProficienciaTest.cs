using System;
using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class AlunoProvaProficienciaTest
    {
        [Fact]
        public void Deve_Criar_AlunoProvaProficiencia_Com_Construtor_Padrao()
        {
            var proficiencia = new AlunoProvaProficiencia
            {
                AlunoId = 1,
                Ra = 123456,
                ProvaId = 10,
                DisciplinaId = 5,
                Proficiencia = 250.75m,
                Origem = 1,
                Tipo = AlunoProvaProficienciaTipo.Final,
                UltimaAtualizacao = DateTime.Today
            };

            Assert.Equal(1, proficiencia.AlunoId);
            Assert.Equal(123456, proficiencia.Ra);
            Assert.Equal(10, proficiencia.ProvaId);
            Assert.Equal(5, proficiencia.DisciplinaId);
            Assert.Equal(250.75m, proficiencia.Proficiencia);
            Assert.Equal(1, proficiencia.Origem);
            Assert.Equal(AlunoProvaProficienciaTipo.Final, proficiencia.Tipo);
            Assert.Equal(DateTime.Today, proficiencia.UltimaAtualizacao);
        }

        [Fact]
        public void Deve_Criar_AlunoProvaProficiencia_Com_DisciplinaId_Nulo()
        {
            var proficiencia = new AlunoProvaProficiencia
            {
                AlunoId = 1,
                Ra = 111,
                ProvaId = 2,
                DisciplinaId = null
            };

            Assert.Null(proficiencia.DisciplinaId);
        }

        [Fact]
        public void Deve_Criar_AlunoProvaProficiencia_Com_Tipo_Inicial()
        {
            var proficiencia = new AlunoProvaProficiencia
            {
                Tipo = AlunoProvaProficienciaTipo.Inicial
            };

            Assert.Equal(AlunoProvaProficienciaTipo.Inicial, proficiencia.Tipo);
        }

        [Fact]
        public void Deve_Criar_AlunoProvaProficiencia_Com_Tipo_Parcial()
        {
            var proficiencia = new AlunoProvaProficiencia
            {
                Tipo = AlunoProvaProficienciaTipo.Parcial
            };

            Assert.Equal(AlunoProvaProficienciaTipo.Parcial, proficiencia.Tipo);
        }

        [Fact]
        public void Deve_Criar_AlunoProvaProficiencia_Com_Tipo_Final()
        {
            var proficiencia = new AlunoProvaProficiencia
            {
                Tipo = AlunoProvaProficienciaTipo.Final
            };

            Assert.Equal(AlunoProvaProficienciaTipo.Final, proficiencia.Tipo);
        }

        [Fact]
        public void Deve_Criar_AlunoProvaProficiencia_Com_Proficiencia_Zero()
        {
            var proficiencia = new AlunoProvaProficiencia { Proficiencia = 0m };

            Assert.Equal(0m, proficiencia.Proficiencia);
        }

        [Fact]
        public void Deve_Criar_AlunoProvaProficiencia_Com_Proficiencia_Negativa()
        {
            var proficiencia = new AlunoProvaProficiencia { Proficiencia = -10.5m };

            Assert.Equal(-10.5m, proficiencia.Proficiencia);
        }

        [Fact]
        public void Deve_Criar_AlunoProvaProficiencia_Com_Proficiencia_Alta()
        {
            var proficiencia = new AlunoProvaProficiencia { Proficiencia = 999.99m };

            Assert.Equal(999.99m, proficiencia.Proficiencia);
        }

        [Fact]
        public void Deve_Criar_AlunoProvaProficiencia_Com_Valores_Default()
        {
            var proficiencia = new AlunoProvaProficiencia();

            Assert.Equal(0, proficiencia.AlunoId);
            Assert.Equal(0, proficiencia.Ra);
            Assert.Equal(0, proficiencia.ProvaId);
            Assert.Null(proficiencia.DisciplinaId);
            Assert.Equal(0m, proficiencia.Proficiencia);
            Assert.Equal(0, proficiencia.Origem);
            Assert.Equal(AlunoProvaProficienciaTipo.Inicial, proficiencia.Tipo);
        }

        [Fact]
        public void Deve_Verificar_Todos_Os_Valores_Do_Enum_AlunoProvaProficienciaTipo()
        {
            var valores = Enum.GetValues(typeof(AlunoProvaProficienciaTipo));

            Assert.Contains(AlunoProvaProficienciaTipo.Inicial, (AlunoProvaProficienciaTipo[])valores);
            Assert.Contains(AlunoProvaProficienciaTipo.Parcial, (AlunoProvaProficienciaTipo[])valores);
            Assert.Contains(AlunoProvaProficienciaTipo.Final, (AlunoProvaProficienciaTipo[])valores);
            Assert.Equal(3, valores.Length);
        }

        [Fact]
        public void Deve_Verificar_Valores_Numericos_Do_Enum_AlunoProvaProficienciaTipo()
        {
            Assert.Equal(0, (int)AlunoProvaProficienciaTipo.Inicial);
            Assert.Equal(1, (int)AlunoProvaProficienciaTipo.Parcial);
            Assert.Equal(2, (int)AlunoProvaProficienciaTipo.Final);
        }

        [Fact]
        public void Deve_Alterar_Tipo_De_Inicial_Para_Final()
        {
            var proficiencia = new AlunoProvaProficiencia { Tipo = AlunoProvaProficienciaTipo.Inicial };
            proficiencia.Tipo = AlunoProvaProficienciaTipo.Final;

            Assert.Equal(AlunoProvaProficienciaTipo.Final, proficiencia.Tipo);
        }

        [Fact]
        public void Deve_Criar_AlunoProvaProficiencia_Com_UltimaAtualizacao_Especifica()
        {
            var data = new DateTime(2024, 1, 15, 10, 30, 0);
            var proficiencia = new AlunoProvaProficiencia { UltimaAtualizacao = data };

            Assert.Equal(data, proficiencia.UltimaAtualizacao);
        }

        [Fact]
        public void Deve_Criar_AlunoProvaProficiencia_Com_DisciplinaId_Preenchido()
        {
            var proficiencia = new AlunoProvaProficiencia { DisciplinaId = 42 };

            Assert.NotNull(proficiencia.DisciplinaId);
            Assert.Equal(42, proficiencia.DisciplinaId);
        }

        [Fact]
        public void Deve_Criar_AlunoProvaProficiencia_Com_Ra_Maximo()
        {
            var proficiencia = new AlunoProvaProficiencia { Ra = long.MaxValue };

            Assert.Equal(long.MaxValue, proficiencia.Ra);
        }
    }
}