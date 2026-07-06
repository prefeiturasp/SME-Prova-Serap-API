using System;
using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class ProvaTest
    {
        private readonly DateTime _inicio = new DateTime(2024, 3, 1, 8, 0, 0);
        private readonly DateTime _fim = new DateTime(2024, 3, 1, 12, 0, 0);
        private readonly DateTime? _inicioDownload = new DateTime(2024, 2, 28);

        [Fact]
        public void Deve_Criar_Prova_Com_Construtor_Parametros()
        {
            var prova = new SME.SERAp.Prova.Dominio.Prova(1, "Prova de Matemática", _inicioDownload, _inicio, _fim, 20, 100, "senha123", true);

            Assert.Equal(1, prova.Id);
            Assert.Equal("Prova de Matemática", prova.Descricao);
            Assert.Equal(_inicio, prova.Inicio);
            Assert.Equal(_inicioDownload, prova.InicioDownload);
            Assert.Equal(_fim, prova.Fim);
            Assert.Equal(20, prova.TotalItens);
            Assert.Equal(100, prova.LegadoId);
            Assert.Equal("senha123", prova.Senha);
            Assert.True(prova.PossuiBIB);
        }

        [Fact]
        public void Deve_Criar_Prova_Com_Construtor_Padrao()
        {
            var antes = DateTime.Now;
            var prova = new SME.SERAp.Prova.Dominio.Prova
            {
                Descricao = "Prova de Português",
                Inicio = _inicio,
                Fim = _fim,
                TotalItens = 10
            };
            var depois = DateTime.Now;

            Assert.Equal("Prova de Português", prova.Descricao);
            Assert.Equal(_inicio, prova.Inicio);
            Assert.Equal(_fim, prova.Fim);
            Assert.Equal(10, prova.TotalItens);
            Assert.InRange(prova.Inclusao, antes, depois);
        }

        [Fact]
        public void Deve_Definir_Inclusao_Automaticamente_No_Construtor_Padrao()
        {
            var antes = DateTime.Now;
            var prova = new SME.SERAp.Prova.Dominio.Prova();
            var depois = DateTime.Now;

            Assert.InRange(prova.Inclusao, antes, depois);
        }

        [Fact]
        public void Deve_Definir_Inclusao_Automaticamente_No_Construtor_Parametros()
        {
            var antes = DateTime.Now;
            var prova = new SME.SERAp.Prova.Dominio.Prova(1, "Desc", _inicioDownload, _inicio, _fim, 10, 99, "senha", false);
            var depois = DateTime.Now;

            Assert.InRange(prova.Inclusao, antes, depois);
        }

        [Fact]
        public void Deve_Criar_Prova_Com_InicioDownload_Nulo()
        {
            var prova = new SME.SERAp.Prova.Dominio.Prova(1, "Desc", null, _inicio, _fim, 10, 99, "senha", false);

            Assert.Null(prova.InicioDownload);
        }

        [Fact]
        public void Deve_Criar_Prova_Com_PossuiBIB_True()
        {
            var prova = new SME.SERAp.Prova.Dominio.Prova(1, "Desc", null, _inicio, _fim, 10, 99, "senha", true);

            Assert.True(prova.PossuiBIB);
        }

        [Fact]
        public void Deve_Criar_Prova_Com_PossuiBIB_False()
        {
            var prova = new SME.SERAp.Prova.Dominio.Prova(1, "Desc", null, _inicio, _fim, 10, 99, "senha", false);

            Assert.False(prova.PossuiBIB);
        }

        [Fact]
        public void Deve_Criar_Prova_Com_FormatoTai_False_Por_Padrao()
        {
            var prova = new SME.SERAp.Prova.Dominio.Prova();

            Assert.False(prova.FormatoTai);
        }

        [Fact]
        public void Deve_Criar_Prova_Com_DisciplinaId_Nulo_Por_Padrao()
        {
            var prova = new SME.SERAp.Prova.Dominio.Prova();

            Assert.Null(prova.DisciplinaId);
        }

        [Fact]
        public void Deve_Criar_Prova_Com_ProvaFormatoTaiItem_Nulo_Por_Padrao()
        {
            var prova = new SME.SERAp.Prova.Dominio.Prova();

            Assert.Null(prova.ProvaFormatoTaiItem);
        }

        [Fact]
        public void Deve_Criar_Prova_Com_Senha_Nula()
        {
            var prova = new SME.SERAp.Prova.Dominio.Prova(1, "Desc", null, _inicio, _fim, 10, 99, null, false);

            Assert.Null(prova.Senha);
        }

        [Fact]
        public void Deve_Criar_Prova_Com_Descricao_Nula()
        {
            var prova = new SME.SERAp.Prova.Dominio.Prova(1, null, null, _inicio, _fim, 10, 99, "senha", false);

            Assert.Null(prova.Descricao);
        }

        [Fact]
        public void Deve_Criar_Prova_Com_Modalidade_Padrao()
        {
            var prova = new SME.SERAp.Prova.Dominio.Prova();

            Assert.Equal(default(Modalidade), prova.Modalidade);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var prova = new SME.SERAp.Prova.Dominio.Prova();
            prova.Descricao = "Nova Descrição";
            prova.TotalItens = 30;
            prova.TotalCadernos = 5;
            prova.Disciplina = "Ciências";
            prova.FormatoTai = true;
            prova.DisciplinaId = 7;

            Assert.Equal("Nova Descrição", prova.Descricao);
            Assert.Equal(30, prova.TotalItens);
            Assert.Equal(5, prova.TotalCadernos);
            Assert.Equal("Ciências", prova.Disciplina);
            Assert.True(prova.FormatoTai);
            Assert.Equal(7, prova.DisciplinaId);
        }

        [Fact]
        public void Deve_Criar_Prova_Com_TempoExecucao()
        {
            var prova = new SME.SERAp.Prova.Dominio.Prova { TempoExecucao = 90 };

            Assert.Equal(90, prova.TempoExecucao);
        }

        [Fact]
        public void Deve_Criar_Prova_Com_LegadoId_Maximo()
        {
            var prova = new SME.SERAp.Prova.Dominio.Prova(1, "Desc", null, _inicio, _fim, 10, long.MaxValue, "senha", false);

            Assert.Equal(long.MaxValue, prova.LegadoId);
        }

        [Fact]
        public void Deve_Criar_Prova_Herdando_EntidadeBase()
        {
            var prova = new SME.SERAp.Prova.Dominio.Prova();
            prova.Id = 55;

            Assert.Equal(55, prova.Id);
        }
    }
}