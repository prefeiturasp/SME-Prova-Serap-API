using System;
using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class ExecucaoControleTest
    {
        [Fact]
        public void Deve_Criar_ExecucaoControle_Com_Construtor_Padrao()
        {
            var execucao = new ExecucaoControle
            {
                UltimaExecucao = new DateTime(2024, 1, 10, 8, 0, 0),
                Tipo = ExecucaoControleTipo.ProvaLegadoSincronizacao
            };

            Assert.Equal(new DateTime(2024, 1, 10, 8, 0, 0), execucao.UltimaExecucao);
            Assert.Equal(ExecucaoControleTipo.ProvaLegadoSincronizacao, execucao.Tipo);
        }

        [Fact]
        public void Deve_Criar_ExecucaoControle_Com_Valores_Default()
        {
            var execucao = new ExecucaoControle();

            Assert.Equal(default(DateTime), execucao.UltimaExecucao);
            Assert.Equal(0, execucao.Id);
        }

        [Fact]
        public void Deve_Alterar_UltimaExecucao_Apos_Criacao()
        {
            var execucao = new ExecucaoControle();
            var novaData = DateTime.Today;
            execucao.UltimaExecucao = novaData;

            Assert.Equal(novaData, execucao.UltimaExecucao);
        }

        [Fact]
        public void Deve_Alterar_Tipo_Apos_Criacao()
        {
            var execucao = new ExecucaoControle();
            execucao.Tipo = ExecucaoControleTipo.ProvaLegadoSincronizacao;

            Assert.Equal(ExecucaoControleTipo.ProvaLegadoSincronizacao, execucao.Tipo);
        }

        [Fact]
        public void Deve_Verificar_Valores_Numericos_Do_Enum_ExecucaoControleTipo()
        {
            Assert.Equal(1, (int)ExecucaoControleTipo.ProvaLegadoSincronizacao);
        }

        [Fact]
        public void Deve_Verificar_Todos_Os_Valores_Do_Enum_ExecucaoControleTipo()
        {
            var valores = Enum.GetValues(typeof(ExecucaoControleTipo));

            Assert.Contains(ExecucaoControleTipo.ProvaLegadoSincronizacao, (ExecucaoControleTipo[])valores);
            Assert.Single(valores);
        }

        [Fact]
        public void Deve_Herdar_De_EntidadeBase()
        {
            var execucao = new ExecucaoControle();

            Assert.IsAssignableFrom<EntidadeBase>(execucao);
        }

        [Fact]
        public void Deve_Criar_ExecucaoControle_Com_UltimaExecucao_Hoje()
        {
            var execucao = new ExecucaoControle { UltimaExecucao = DateTime.Today };

            Assert.Equal(DateTime.Today, execucao.UltimaExecucao);
        }

        [Fact]
        public void Deve_Criar_ExecucaoControle_Com_Id_Definido()
        {
            var execucao = new ExecucaoControle { Id = 7 };

            Assert.Equal(7, execucao.Id);
        }
    }
}