using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Dominio.Entidades;
using System;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class LogMensagemTest
    {
        [Fact]
        public void Deve_Criar_LogMensagem_Com_Parametros_Obrigatorios()
        {
            var antes = DateTime.Now;
            var log = new LogMensagem("Mensagem de teste", LogNivel.Informacao, "Observação teste");
            var depois = DateTime.Now;

            Assert.Equal("Mensagem de teste", log.Mensagem);
            Assert.Equal(LogNivel.Informacao, log.Nivel);
            Assert.Equal("Observação teste", log.Observacao);
            Assert.Equal("Serap-Estudantes-API", log.Projeto);
            Assert.Null(log.Rastreamento);
            Assert.Null(log.ExcecaoInterna);
            Assert.InRange(log.DataHora, antes, depois);
        }

        [Fact]
        public void Deve_Criar_LogMensagem_Com_Todos_Os_Parametros()
        {
            var log = new LogMensagem(
                "Erro crítico",
                LogNivel.Critico,
                "Observação detalhada",
                "stack trace aqui",
                "inner exception aqui",
                "Serap-Estudantes-Worker");

            Assert.Equal("Erro crítico", log.Mensagem);
            Assert.Equal(LogNivel.Critico, log.Nivel);
            Assert.Equal("Observação detalhada", log.Observacao);
            Assert.Equal("stack trace aqui", log.Rastreamento);
            Assert.Equal("inner exception aqui", log.ExcecaoInterna);
            Assert.Equal("Serap-Estudantes-Worker", log.Projeto);
        }

        [Fact]
        public void Deve_Criar_LogMensagem_Com_Projeto_Padrao()
        {
            var log = new LogMensagem("Msg", LogNivel.Informacao, "Obs");

            Assert.Equal("Serap-Estudantes-API", log.Projeto);
        }

        [Fact]
        public void Deve_Criar_LogMensagem_Com_Projeto_Customizado()
        {
            var log = new LogMensagem("Msg", LogNivel.Critico, "Obs", projeto: "Meu-Projeto");

            Assert.Equal("Meu-Projeto", log.Projeto);
        }

        [Fact]
        public void Deve_Criar_LogMensagem_Com_Rastreamento_Nulo_Por_Padrao()
        {
            var log = new LogMensagem("Msg", LogNivel.Informacao, "Obs");

            Assert.Null(log.Rastreamento);
        }

        [Fact]
        public void Deve_Criar_LogMensagem_Com_ExcecaoInterna_Nula_Por_Padrao()
        {
            var log = new LogMensagem("Msg", LogNivel.Informacao, "Obs");

            Assert.Null(log.ExcecaoInterna);
        }

        [Fact]
        public void Deve_Criar_LogMensagem_Com_Nivel_Erro()
        {
            var log = new LogMensagem("Erro", LogNivel.Critico, "Obs");

            Assert.Equal(LogNivel.Critico, log.Nivel);
        }

        [Fact]
        public void Deve_Criar_LogMensagem_Com_Nivel_Aviso()
        {
            var log = new LogMensagem("Aviso", LogNivel.Informacao, "Obs");

            Assert.Equal(LogNivel.Informacao, log.Nivel);
        }

        [Fact]
        public void Deve_Criar_LogMensagem_Com_Nivel_Depuracao()
        {
            var log = new LogMensagem("Debug", LogNivel.Informacao, "Obs");

            Assert.Equal(LogNivel.Informacao, log.Nivel);
        }

        [Fact]
        public void Deve_Criar_LogMensagem_Com_Nivel_Critico()
        {
            var log = new LogMensagem("Crítico", LogNivel.Critico, "Obs");

            Assert.Equal(LogNivel.Critico, log.Nivel);
        }

        [Fact]
        public void Deve_Criar_LogMensagem_Com_Nivel_Informacao()
        {
            var log = new LogMensagem("Info", LogNivel.Informacao, "Obs");

            Assert.Equal(LogNivel.Informacao, log.Nivel);
        }

        [Fact]
        public void Deve_Criar_LogMensagem_Com_DataHora_Proxima_De_Agora()
        {
            var antes = DateTime.Now;
            var log = new LogMensagem("Msg", LogNivel.Informacao, "Obs");
            var depois = DateTime.Now;

            Assert.InRange(log.DataHora, antes, depois);
        }

        [Fact]
        public void Deve_Criar_LogMensagem_Com_Mensagem_Nula()
        {
            var log = new LogMensagem(null, LogNivel.Informacao, "Obs");

            Assert.Null(log.Mensagem);
        }

        [Fact]
        public void Deve_Criar_LogMensagem_Com_Observacao_Nula()
        {
            var log = new LogMensagem("Msg", LogNivel.Informacao, null);

            Assert.Null(log.Observacao);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var log = new LogMensagem("Original", LogNivel.Informacao, "Obs");
            log.Mensagem = "Alterada";
            log.Observacao = "Nova observação";
            log.Rastreamento = "trace";
            log.ExcecaoInterna = "inner";

            Assert.Equal("Alterada", log.Mensagem);
            Assert.Equal("Nova observação", log.Observacao);
            Assert.Equal("trace", log.Rastreamento);
            Assert.Equal("inner", log.ExcecaoInterna);
        }

        [Fact]
        public void Dois_LogMensagem_Criados_Em_Sequencia_Devem_Ter_DataHora_Crescente()
        {
            var log1 = new LogMensagem("Msg1", LogNivel.Informacao, "Obs1");
            var log2 = new LogMensagem("Msg2", LogNivel.Informacao, "Obs2");

            Assert.True(log2.DataHora >= log1.DataHora);
        }
    }
}