using System;
using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class ProvaAlunoTest
    {
        private readonly DateTime _criadoEm = new DateTime(2024, 5, 10, 9, 0, 0);
        private readonly DateTime _finalizadoEm = new DateTime(2024, 5, 10, 11, 0, 0);
        private readonly DateTime _criadoEmServidor = new DateTime(2024, 5, 10, 9, 0, 5);

        [Fact]
        public void Deve_Criar_ProvaAluno_Com_Construtor_Parametros()
        {
            var provaAluno = new ProvaAluno(10, ProvaStatus.Iniciado, 99, _criadoEm, _finalizadoEm, TipoDispositivo.Mobile, "dev-001", _criadoEmServidor);

            Assert.Equal(10, provaAluno.ProvaId);
            Assert.Equal(ProvaStatus.Iniciado, provaAluno.Status);
            Assert.Equal(99, provaAluno.AlunoRA);
            Assert.Equal(_criadoEm, provaAluno.CriadoEm);
            Assert.Equal(_finalizadoEm, provaAluno.FinalizadoEm);
            Assert.Equal(TipoDispositivo.Mobile, provaAluno.TipoDispositivo);
            Assert.Equal("dev-001", provaAluno.DispositivoId);
            Assert.Equal(_criadoEmServidor, provaAluno.CriadoEmServidor);
        }

        [Fact]
        public void Deve_Criar_ProvaAluno_Com_Construtor_Padrao()
        {
            var antes = DateTime.Now;
            var provaAluno = new ProvaAluno
            {
                ProvaId = 5,
                AlunoRA = 123,
                Status = ProvaStatus.Pendente
            };
            var depois = DateTime.Now;

            Assert.Equal(5, provaAluno.ProvaId);
            Assert.Equal(123, provaAluno.AlunoRA);
            Assert.Equal(ProvaStatus.Pendente, provaAluno.Status);
            Assert.InRange(provaAluno.CriadoEm, antes, depois);
        }

        [Fact]
        public void Deve_Definir_CriadoEm_Automaticamente_No_Construtor_Padrao()
        {
            var antes = DateTime.Now;
            var provaAluno = new ProvaAluno();
            var depois = DateTime.Now;

            Assert.InRange(provaAluno.CriadoEm, antes, depois);
        }

        [Fact]
        public void Deve_Criar_ProvaAluno_Com_FinalizadoEm_Nulo()
        {
            var provaAluno = new ProvaAluno(1, ProvaStatus.Iniciado, 99, _criadoEm, null, TipoDispositivo.Web, "dev", _criadoEmServidor);

            Assert.Null(provaAluno.FinalizadoEm);
        }

        [Fact]
        public void Deve_Criar_ProvaAluno_Com_FinalizadoEmServidor_Nulo_Por_Padrao()
        {
            var provaAluno = new ProvaAluno(1, ProvaStatus.Iniciado, 99, _criadoEm, null, TipoDispositivo.Web, "dev", _criadoEmServidor);

            Assert.Null(provaAluno.FinalizadoEmServidor);
        }

        [Fact]
        public void Deve_Atribuir_FinalizadoEmServidor_Apos_Criacao()
        {
            var provaAluno = new ProvaAluno(1, ProvaStatus.Iniciado, 99, _criadoEm, null, TipoDispositivo.Web, "dev", _criadoEmServidor);
            provaAluno.FinalizadoEmServidor = _finalizadoEm;

            Assert.Equal(_finalizadoEm, provaAluno.FinalizadoEmServidor);
        }

        [Fact]
        public void Deve_Criar_ProvaAluno_Com_Status_Pendente()
        {
            var provaAluno = new ProvaAluno(1, ProvaStatus.Pendente, 1, _criadoEm, null, TipoDispositivo.Mobile, "d", _criadoEmServidor);

            Assert.Equal(ProvaStatus.Pendente, provaAluno.Status);
        }

        [Fact]
        public void Deve_Criar_ProvaAluno_Com_Status_Iniciado()
        {
            var provaAluno = new ProvaAluno(1, ProvaStatus.Iniciado, 1, _criadoEm, null, TipoDispositivo.Mobile, "d", _criadoEmServidor);

            Assert.Equal(ProvaStatus.Iniciado, provaAluno.Status);
        }

        [Fact]
        public void Deve_Criar_ProvaAluno_Com_Status_Finalizado()
        {
            var provaAluno = new ProvaAluno(1, ProvaStatus.Finalizado, 1, _criadoEm, _finalizadoEm, TipoDispositivo.Mobile, "d", _criadoEmServidor);

            Assert.Equal(ProvaStatus.Finalizado, provaAluno.Status);
        }

        [Fact]
        public void Deve_Criar_ProvaAluno_Com_TipoDispositivo_Tablet()
        {
            var provaAluno = new ProvaAluno(1, ProvaStatus.Iniciado, 1, _criadoEm, null, TipoDispositivo.Tablet, "d", _criadoEmServidor);

            Assert.Equal(TipoDispositivo.Tablet, provaAluno.TipoDispositivo);
        }

        [Fact]
        public void Deve_Criar_ProvaAluno_Com_TipoDispositivo_Web()
        {
            var provaAluno = new ProvaAluno(1, ProvaStatus.Iniciado, 1, _criadoEm, null, TipoDispositivo.Web, "d", _criadoEmServidor);

            Assert.Equal(TipoDispositivo.Web, provaAluno.TipoDispositivo);
        }

        [Fact]
        public void Deve_Criar_ProvaAluno_Com_DispositivoId_Nulo()
        {
            var provaAluno = new ProvaAluno(1, ProvaStatus.Iniciado, 1, _criadoEm, null, TipoDispositivo.Mobile, null, _criadoEmServidor);

            Assert.Null(provaAluno.DispositivoId);
        }

        [Fact]
        public void Deve_Criar_ProvaAluno_Com_CriadoEmServidor_Nulo()
        {
            var provaAluno = new ProvaAluno(1, ProvaStatus.Iniciado, 1, _criadoEm, null, TipoDispositivo.Mobile, "d", default);

            Assert.Equal(default(DateTime), provaAluno.CriadoEmServidor);
        }

        [Fact]
        public void Deve_Criar_ProvaAluno_Com_AlunoRA_Maximo()
        {
            var provaAluno = new ProvaAluno(1, ProvaStatus.Iniciado, long.MaxValue, _criadoEm, null, TipoDispositivo.Web, "d", _criadoEmServidor);

            Assert.Equal(long.MaxValue, provaAluno.AlunoRA);
        }

        [Fact]
        public void Deve_Criar_ProvaAluno_Com_Frequencia_Padrao()
        {
            var provaAluno = new ProvaAluno();

            Assert.Equal(default(FrequenciaAluno), provaAluno.Frequencia);
        }

        [Fact]
        public void Deve_Alterar_Status_Apos_Criacao()
        {
            var provaAluno = new ProvaAluno(1, ProvaStatus.Pendente, 1, _criadoEm, null, TipoDispositivo.Mobile, "d", _criadoEmServidor);
            provaAluno.Status = ProvaStatus.Finalizado;

            Assert.Equal(ProvaStatus.Finalizado, provaAluno.Status);
        }

        [Fact]
        public void Deve_Criar_ProvaAluno_Herdando_EntidadeBase()
        {
            var provaAluno = new ProvaAluno();
            provaAluno.Id = 42;

            Assert.Equal(42, provaAluno.Id);
        }
    }
}