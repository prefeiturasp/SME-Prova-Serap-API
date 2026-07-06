using System;
using System.ComponentModel.DataAnnotations;
using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Extensoes
{
    public class EnumExtensionTest
    {
        [Fact]
        public void EhUmDosValores_Deve_Retornar_True_Quando_Valor_Esta_Na_Lista()
        {
            var status = ProvaStatus.Iniciado;

            var resultado = status.EhUmDosValores(ProvaStatus.NaoIniciado, ProvaStatus.Iniciado, ProvaStatus.Finalizado);

            Assert.True(resultado);
        }

        [Fact]
        public void EhUmDosValores_Deve_Retornar_False_Quando_Valor_Nao_Esta_Na_Lista()
        {
            var status = ProvaStatus.EmRevisao;

            var resultado = status.EhUmDosValores(ProvaStatus.NaoIniciado, ProvaStatus.Iniciado, ProvaStatus.Finalizado);

            Assert.False(resultado);
        }

        [Fact]
        public void EhUmDosValores_Deve_Retornar_True_Com_Lista_De_Um_Elemento_Igual()
        {
            var status = ProvaStatus.Pendente;

            var resultado = status.EhUmDosValores(ProvaStatus.Pendente);

            Assert.True(resultado);
        }

        [Fact]
        public void EhUmDosValores_Deve_Retornar_False_Com_Lista_De_Um_Elemento_Diferente()
        {
            var status = ProvaStatus.Pendente;

            var resultado = status.EhUmDosValores(ProvaStatus.Finalizado);

            Assert.False(resultado);
        }

        [Fact]
        public void EhUmDosValores_Deve_Retornar_False_Com_Lista_Vazia()
        {
            var status = ProvaStatus.Iniciado;

            var resultado = status.EhUmDosValores();

            Assert.False(resultado);
        }

        [Fact]
        public void EhUmDosValores_Deve_Retornar_True_Com_Todos_Os_Valores_Possiveis()
        {
            var status = ProvaStatus.FINALIZADA_OFFLINE;

            var resultado = status.EhUmDosValores(
                ProvaStatus.NaoIniciado,
                ProvaStatus.Iniciado,
                ProvaStatus.Finalizado,
                ProvaStatus.Pendente,
                ProvaStatus.EmRevisao,
                ProvaStatus.FINALIZADA_AUTOMATICAMENTE_JOB,
                ProvaStatus.FINALIZADA_AUTOMATICAMENTE_TEMPO,
                ProvaStatus.FINALIZADA_OFFLINE);

            Assert.True(resultado);
        }

        [Fact]
        public void EhUmDosValores_Deve_Funcionar_Com_Enum_FrequenciaAluno()
        {
            var frequencia = FrequenciaAluno.Presente;

            var resultado = frequencia.EhUmDosValores(FrequenciaAluno.Presente, FrequenciaAluno.Remoto);

            Assert.True(resultado);
        }

        [Fact]
        public void EhUmDosValores_Deve_Retornar_False_Com_Enum_FrequenciaAluno_Ausente()
        {
            var frequencia = FrequenciaAluno.Ausente;

            var resultado = frequencia.EhUmDosValores(FrequenciaAluno.Presente, FrequenciaAluno.Remoto);

            Assert.False(resultado);
        }

        [Fact]
        public void ObterNomeCurto_Deve_Retornar_ShortName_Correto_Para_FrequenciaAluno_Presente()
        {
            var resultado = FrequenciaAluno.Presente.ObterNomeCurto();

            Assert.Equal("P", resultado);
        }

        [Fact]
        public void ObterNomeCurto_Deve_Retornar_ShortName_Correto_Para_FrequenciaAluno_Ausente()
        {
            var resultado = FrequenciaAluno.Ausente.ObterNomeCurto();

            Assert.Equal("A", resultado);
        }

        [Fact]
        public void ObterNomeCurto_Deve_Retornar_ShortName_Correto_Para_FrequenciaAluno_Remoto()
        {
            var resultado = FrequenciaAluno.Remoto.ObterNomeCurto();

            Assert.Equal("R", resultado);
        }

        [Fact]
        public void ObterNomeCurto_Deve_Retornar_ShortName_Correto_Para_Modalidade_EJA()
        {
            var resultado = Modalidade.EJA.ObterNomeCurto();

            Assert.Equal("EJA", resultado);
        }

        [Fact]
        public void ObterNomeCurto_Deve_Retornar_ShortName_Correto_Para_Modalidade_Fundamental()
        {
            var resultado = Modalidade.Fundamental.ObterNomeCurto();

            Assert.Equal("EF", resultado);
        }

        [Fact]
        public void ObterNomeCurto_Deve_Retornar_ShortName_Correto_Para_Modalidade_Medio()
        {
            var resultado = Modalidade.Medio.ObterNomeCurto();

            Assert.Equal("EM", resultado);
        }

        [Fact]
        public void ObterNomeCurto_Deve_Retornar_ShortName_Correto_Para_Modalidade_EducacaoInfantil()
        {
            var resultado = Modalidade.EducacaoInfantil.ObterNomeCurto();

            Assert.Equal("EI", resultado);
        }

        [Fact]
        public void ObterNome_Deve_Retornar_Name_Correto_Para_ProvaStatus_NaoIniciado()
        {
            var resultado = ProvaStatus.NaoIniciado.ObterNome();

            Assert.Equal("Não Iniciado", resultado);
        }

        [Fact]
        public void ObterNome_Deve_Retornar_Name_Correto_Para_ProvaStatus_Iniciado()
        {
            var resultado = ProvaStatus.Iniciado.ObterNome();

            Assert.Equal("Iniciado", resultado);
        }

        [Fact]
        public void ObterNome_Deve_Retornar_Name_Correto_Para_ProvaStatus_Finalizado()
        {
            var resultado = ProvaStatus.Finalizado.ObterNome();

            Assert.Equal("Finalizado", resultado);
        }

        [Fact]
        public void ObterNome_Deve_Retornar_Name_Correto_Para_ProvaStatus_Pendente()
        {
            var resultado = ProvaStatus.Pendente.ObterNome();

            Assert.Equal("Pendente", resultado);
        }

        [Fact]
        public void ObterNome_Deve_Retornar_Name_Correto_Para_ProvaStatus_EmRevisao()
        {
            var resultado = ProvaStatus.EmRevisao.ObterNome();

            Assert.Equal("Em Revisão", resultado);
        }

        [Fact]
        public void ObterNome_Deve_Retornar_Name_Correto_Para_FrequenciaAluno_Presente()
        {
            var resultado = FrequenciaAluno.Presente.ObterNome();

            Assert.Equal("Presente", resultado);
        }

        [Fact]
        public void ObterNome_Deve_Retornar_Name_Correto_Para_FrequenciaAluno_Ausente()
        {
            var resultado = FrequenciaAluno.Ausente.ObterNome();

            Assert.Equal("Ausente", resultado);
        }

        [Fact]
        public void ObterNome_Deve_Retornar_Name_Correto_Para_FrequenciaAluno_Remoto()
        {
            var resultado = FrequenciaAluno.Remoto.ObterNome();

            Assert.Equal("Remoto", resultado);
        }

        [Fact]
        public void ObterNome_Deve_Retornar_Name_Correto_Para_Modalidade_Fundamental()
        {
            var resultado = Modalidade.Fundamental.ObterNome();

            Assert.Equal("Ensino Fundamental", resultado);
        }

        [Fact]
        public void ObterNome_Deve_Retornar_Name_Correto_Para_Modalidade_EJA()
        {
            var resultado = Modalidade.EJA.ObterNome();

            Assert.Equal("Educação de Jovens e Adultos", resultado);
        }

        [Fact]
        public void ObterNome_Deve_Retornar_Name_Correto_Para_ExportacaoResultadoStatus_NaoIniciado()
        {
            var resultado = ExportacaoResultadoStatus.NaoIniciado.ObterNome();

            Assert.Equal("Não Iniciado", resultado);
        }

        [Fact]
        public void ObterNome_Deve_Retornar_Name_Correto_Para_ExportacaoResultadoStatus_Cancelado()
        {
            var resultado = ExportacaoResultadoStatus.Cancelado.ObterNome();

            Assert.Equal("Solicitação cancelada", resultado);
        }

        [Fact]
        public void ObterNome_Deve_Retornar_Name_Correto_Para_TipoDispositivo_Mobile()
        {
            var resultado = TipoDispositivo.Mobile.ObterNome();

            Assert.Equal("Mobile", resultado);
        }

        [Fact]
        public void ObterNome_Deve_Retornar_Name_Correto_Para_TipoDispositivo_Web()
        {
            var resultado = TipoDispositivo.Web.ObterNome();

            Assert.Equal("Web", resultado);
        }

        [Fact]
        public void ObterAtributo_Deve_Retornar_DisplayAttribute_Para_Enum_Com_Display()
        {
            var atributo = ProvaStatus.Iniciado.ObterAtributo<DisplayAttribute>();

            Assert.NotNull(atributo);
            Assert.Equal("Iniciado", atributo.Name);
        }

        [Fact]
        public void ObterAtributo_Deve_Retornar_Nulo_Para_Enum_Sem_Atributo()
        {
            var atributo = AlunoProvaProficienciaTipo.Inicial.ObterAtributo<DisplayAttribute>();

            Assert.Null(atributo);
        }

        [Fact]
        public void ObterAtributo_Deve_Retornar_DisplayAttribute_Com_ShortName_Para_FrequenciaAluno()
        {
            var atributo = FrequenciaAluno.Presente.ObterAtributo<DisplayAttribute>();

            Assert.NotNull(atributo);
            Assert.Equal("P", atributo.ShortName);
        }

        [Fact]
        public void ObterNome_Deve_Retornar_Name_Correto_Para_QuestaoTipo_MultiplaEscolha()
        {
            var resultado = QuestaoTipo.MultiplaEscolha.ObterNome();

            Assert.Equal("Múltipla escolha", resultado);
        }

        [Fact]
        public void ObterNome_Deve_Retornar_Name_Correto_Para_QuestaoTipo_RespostaConstruida()
        {
            var resultado = QuestaoTipo.RespostaConstruida.ObterNome();

            Assert.Equal("Resposta construída", resultado);
        }

        [Fact]
        public void ObterNome_Deve_Retornar_Name_Correto_Para_Posicionamento_Direita()
        {
            var resultado = Posicionamento.Direita.ObterNome();

            Assert.Equal("Direta", resultado);
        }

        [Fact]
        public void ObterNome_Deve_Retornar_Name_Correto_Para_Posicionamento_NaoCadastrado()
        {
            var resultado = Posicionamento.NaoCadastrado.ObterNome();

            Assert.Equal("Não Cadastrado", resultado);
        }
    }
}