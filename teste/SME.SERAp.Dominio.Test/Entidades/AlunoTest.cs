using System;
using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class AlunoTest
    {
        [Fact]
        public void Deve_Criar_Aluno_Com_Construtor_Padrao()
        {
            var aluno = new Aluno
            {
                Nome = "Maria",
                RA = 123456,
                Situacao = 1,
                TurmaId = 789,
                Sexo = "F",
                DataNascimento = new DateTime(2010, 5, 1),
                NomeSocial = "Mariazinha",
                DataAtualizacao = DateTime.Today
            };

            Assert.Equal("Maria", aluno.Nome);
            Assert.Equal(123456, aluno.RA);
            Assert.Equal(1, aluno.Situacao);
            Assert.Equal(789, aluno.TurmaId);
            Assert.Equal("F", aluno.Sexo);
            Assert.Equal(new DateTime(2010, 5, 1), aluno.DataNascimento);
            Assert.Equal("Mariazinha", aluno.NomeSocial);
            Assert.Equal(DateTime.Today, aluno.DataAtualizacao);
        }

        [Fact]
        public void Deve_Criar_Aluno_Com_Construtor_Parametros()
        {
            var aluno = new Aluno("João", 654321);

            Assert.Equal("João", aluno.Nome);
            Assert.Equal(654321, aluno.RA);
        }

        [Fact]
        public void Deve_Criar_Aluno_Com_Nome_Nulo_Via_Construtor_Padrao()
        {
            var aluno = new Aluno { Nome = null, RA = 1 };

            Assert.Null(aluno.Nome);
        }

        [Fact]
        public void Deve_Criar_Aluno_Com_NomeSocial_Nulo()
        {
            var aluno = new Aluno { Nome = "Carlos", RA = 111, NomeSocial = null };

            Assert.Null(aluno.NomeSocial);
        }

        [Fact]
        public void Deve_Criar_Aluno_Com_RA_Maximo()
        {
            var aluno = new Aluno("Teste", long.MaxValue);

            Assert.Equal(long.MaxValue, aluno.RA);
        }

        [Fact]
        public void Deve_Criar_Aluno_Com_Sexo_Masculino()
        {
            var aluno = new Aluno { Nome = "Pedro", RA = 999, Sexo = "M" };

            Assert.Equal("M", aluno.Sexo);
        }

        [Fact]
        public void Deve_Criar_Aluno_Com_Sexo_Feminino()
        {
            var aluno = new Aluno { Nome = "Ana", RA = 888, Sexo = "F" };

            Assert.Equal("F", aluno.Sexo);
        }

        [Fact]
        public void Deve_Criar_Aluno_Com_Situacao_Ativo()
        {
            var aluno = new Aluno { Nome = "Lucas", RA = 777, Situacao = 1 };

            Assert.Equal(1, aluno.Situacao);
        }

        [Fact]
        public void Deve_Criar_Aluno_Com_Situacao_Inativo()
        {
            var aluno = new Aluno { Nome = "Lucas", RA = 777, Situacao = 0 };

            Assert.Equal(0, aluno.Situacao);
        }

        [Fact]
        public void Deve_Criar_Aluno_Com_DataNascimento_Especifica()
        {
            var dataNascimento = new DateTime(2005, 8, 15);
            var aluno = new Aluno { Nome = "Rafael", RA = 555, DataNascimento = dataNascimento };

            Assert.Equal(dataNascimento, aluno.DataNascimento);
        }

        [Fact]
        public void Deve_Criar_Aluno_Com_DataAtualizacao_Hoje()
        {
            var hoje = DateTime.Today;
            var aluno = new Aluno { Nome = "Felipe", RA = 444, DataAtualizacao = hoje };

            Assert.Equal(hoje, aluno.DataAtualizacao);
        }

        [Fact]
        public void Deve_Alterar_Nome_Apos_Criacao()
        {
            var aluno = new Aluno("Carlos", 100);
            aluno.Nome = "Carlos Atualizado";

            Assert.Equal("Carlos Atualizado", aluno.Nome);
        }

        [Fact]
        public void Deve_Alterar_RA_Apos_Criacao()
        {
            var aluno = new Aluno("Marina", 200);
            aluno.RA = 300;

            Assert.Equal(300, aluno.RA);
        }

        [Fact]
        public void Deve_Criar_Aluno_Via_Construtor_Parametros_Com_Nome_Vazio()
        {
            var aluno = new Aluno("", 123);

            Assert.Equal("", aluno.Nome);
            Assert.Equal(123, aluno.RA);
        }

        [Fact]
        public void Deve_Criar_Aluno_Com_TurmaId_Valido()
        {
            var aluno = new Aluno { Nome = "Teste", RA = 1, TurmaId = 42 };

            Assert.Equal(42, aluno.TurmaId);
        }

        [Fact]
        public void Deve_Criar_Aluno_Via_Construtor_Padrao_Com_Valores_Default()
        {
            var aluno = new Aluno();

            Assert.Null(aluno.Nome);
            Assert.Equal(0, aluno.RA);
            Assert.Equal(0, aluno.Situacao);
            Assert.Equal(0, aluno.TurmaId);
            Assert.Null(aluno.Sexo);
            Assert.Equal(default(DateTime), aluno.DataNascimento);
            Assert.Null(aluno.NomeSocial);
        }
    }
}