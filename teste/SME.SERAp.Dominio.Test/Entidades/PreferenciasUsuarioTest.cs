using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class PreferenciasUsuarioTest
    {
        [Fact]
        public void Deve_Criar_PreferenciasUsuario_Com_Construtor_Parametros()
        {
            var preferencias = new PreferenciasUsuario(1, 14, FamiliaFonte.OpenDyslexic);

            Assert.Equal(1, preferencias.UsuarioId);
            Assert.Equal(14, preferencias.TamanhoFonte);
            Assert.Equal(FamiliaFonte.OpenDyslexic, preferencias.FamiliaFonte);
        }

        [Fact]
        public void Deve_Criar_PreferenciasUsuario_Com_Construtor_Padrao()
        {
            var preferencias = new PreferenciasUsuario
            {
                UsuarioId = 5,
                TamanhoFonte = 16,
                FamiliaFonte = FamiliaFonte.OpenDyslexic
            };

            Assert.Equal(5, preferencias.UsuarioId);
            Assert.Equal(16, preferencias.TamanhoFonte);
            Assert.Equal(FamiliaFonte.OpenDyslexic, preferencias.FamiliaFonte);
        }

        [Fact]
        public void Deve_Criar_PreferenciasUsuario_Com_Valores_Default()
        {
            var preferencias = new PreferenciasUsuario();

            Assert.Equal(0, preferencias.UsuarioId);
            Assert.Equal(0, preferencias.TamanhoFonte);
            Assert.Equal(default(FamiliaFonte), preferencias.FamiliaFonte);
        }

        [Fact]
        public void Deve_Criar_PreferenciasUsuario_Com_UsuarioId_Maximo()
        {
            var preferencias = new PreferenciasUsuario(long.MaxValue, 12, FamiliaFonte.OpenDyslexic);

            Assert.Equal(long.MaxValue, preferencias.UsuarioId);
        }

        [Fact]
        public void Deve_Criar_PreferenciasUsuario_Com_TamanhoFonte_Minimo()
        {
            var preferencias = new PreferenciasUsuario(1, 8, FamiliaFonte.OpenDyslexic);

            Assert.Equal(8, preferencias.TamanhoFonte);
        }

        [Fact]
        public void Deve_Criar_PreferenciasUsuario_Com_TamanhoFonte_Grande()
        {
            var preferencias = new PreferenciasUsuario(1, 32, FamiliaFonte.OpenDyslexic);

            Assert.Equal(32, preferencias.TamanhoFonte);
        }

        [Fact]
        public void Deve_Criar_PreferenciasUsuario_Com_FamiliaFonte_Arial()
        {
            var preferencias = new PreferenciasUsuario(1, 12, FamiliaFonte.OpenDyslexic);

            Assert.Equal(FamiliaFonte.OpenDyslexic, preferencias.FamiliaFonte);
        }

        [Fact]
        public void Deve_Criar_PreferenciasUsuario_Com_FamiliaFonte_TimesNewRoman()
        {
            var preferencias = new PreferenciasUsuario(1, 12, FamiliaFonte.OpenDyslexic);

            Assert.Equal(FamiliaFonte.OpenDyslexic, preferencias.FamiliaFonte);
        }

        [Fact]
        public void Deve_Criar_PreferenciasUsuario_Com_FamiliaFonte_OpenDyslexic()
        {
            var preferencias = new PreferenciasUsuario(1, 12, FamiliaFonte.OpenDyslexic);

            Assert.Equal(FamiliaFonte.OpenDyslexic, preferencias.FamiliaFonte);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var preferencias = new PreferenciasUsuario(1, 12, FamiliaFonte.OpenDyslexic);
            preferencias.TamanhoFonte = 20;
            preferencias.FamiliaFonte = FamiliaFonte.OpenDyslexic;

            Assert.Equal(20, preferencias.TamanhoFonte);
            Assert.Equal(FamiliaFonte.OpenDyslexic, preferencias.FamiliaFonte);
        }

        [Fact]
        public void Deve_Criar_PreferenciasUsuario_Herdando_EntidadeBase()
        {
            var preferencias = new PreferenciasUsuario(1, 12, FamiliaFonte.Poppins);
            preferencias.Id = 99;

            Assert.Equal(99, preferencias.Id);
        }

        [Fact]
        public void Deve_Verificar_Todos_Os_Valores_Do_Enum_FamiliaFonte()
        {
            var valores = System.Enum.GetValues(typeof(FamiliaFonte));

            Assert.Contains(FamiliaFonte.OpenDyslexic, (FamiliaFonte[])valores);
            Assert.Contains(FamiliaFonte.OpenDyslexic, (FamiliaFonte[])valores);
            Assert.Contains(FamiliaFonte.OpenDyslexic, (FamiliaFonte[])valores);
        }
    }
}