using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class ParametroSistemaTest
    {
        [Fact]
        public void Deve_Criar_ParametroSistema_Com_Construtor_Parametros()
        {
            var parametro = new ParametroSistema(2024, true, "Descrição", "NomeParam", TipoParametroSistema.FimProvaTurnoIntegral, "ValorX");

            Assert.Equal(2024, parametro.Ano);
            Assert.True(parametro.Ativo);
            Assert.Equal("Descrição", parametro.Descricao);
            Assert.Equal("NomeParam", parametro.Nome);
            Assert.Equal(TipoParametroSistema.FimProvaTurnoIntegral, parametro.Tipo);
            Assert.Equal("ValorX", parametro.Valor);
        }

        [Fact]
        public void Deve_Criar_ParametroSistema_Com_Construtor_Padrao()
        {
            var parametro = new ParametroSistema
            {
                Ano = 2023,
                Ativo = false,
                Descricao = "Desc teste",
                Nome = "Param teste",
                Tipo = TipoParametroSistema.FimProvaTurnoNoite,
                Valor = "100"
            };

            Assert.Equal(2023, parametro.Ano);
            Assert.False(parametro.Ativo);
            Assert.Equal("Desc teste", parametro.Descricao);
            Assert.Equal("Param teste", parametro.Nome);
            Assert.Equal(TipoParametroSistema.FimProvaTurnoNoite, parametro.Tipo);
            Assert.Equal("100", parametro.Valor);
        }

        [Fact]
        public void Deve_Criar_ParametroSistema_Com_Valores_Default()
        {
            var parametro = new ParametroSistema();

            Assert.Null(parametro.Ano);
            Assert.False(parametro.Ativo);
            Assert.Null(parametro.Descricao);
            Assert.Null(parametro.Nome);
            Assert.Null(parametro.Valor);
        }

        [Fact]
        public void Deve_Criar_ParametroSistema_Com_Ativo_True()
        {
            var parametro = new ParametroSistema(2024, true, "Desc", "Nome", TipoParametroSistema.FimProvaTurnoIntegral, "Valor");

            Assert.True(parametro.Ativo);
        }

        [Fact]
        public void Deve_Criar_ParametroSistema_Com_Ativo_False()
        {
            var parametro = new ParametroSistema(2024, false, "Desc", "Nome", TipoParametroSistema.FimProvaTurnoIntegral, "Valor");

            Assert.False(parametro.Ativo);
        }

        [Fact]
        public void Deve_Criar_ParametroSistema_Com_Ano_Nulo_Via_Construtor_Padrao()
        {
            var parametro = new ParametroSistema { Ano = null };

            Assert.Null(parametro.Ano);
        }

        [Fact]
        public void Deve_Criar_ParametroSistema_Com_Descricao_Nula()
        {
            var parametro = new ParametroSistema(2024, true, null, "Nome", TipoParametroSistema.FimProvaTurnoIntegral, "Valor");

            Assert.Null(parametro.Descricao);
        }

        [Fact]
        public void Deve_Criar_ParametroSistema_Com_Nome_Nulo()
        {
            var parametro = new ParametroSistema(2024, true, "Desc", null, TipoParametroSistema.FimProvaTurnoIntegral, "Valor");

            Assert.Null(parametro.Nome);
        }

        [Fact]
        public void Deve_Criar_ParametroSistema_Com_Valor_Nulo()
        {
            var parametro = new ParametroSistema(2024, true, "Desc", "Nome", TipoParametroSistema.FimProvaTurnoIntegral, null);

            Assert.Null(parametro.Valor);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var parametro = new ParametroSistema(2024, true, "Desc", "Nome", TipoParametroSistema.FimProvaTurnoIntegral, "Valor");
            parametro.Ativo = false;
            parametro.Valor = "NovoValor";
            parametro.Ano = 2025;

            Assert.False(parametro.Ativo);
            Assert.Equal("NovoValor", parametro.Valor);
            Assert.Equal(2025, parametro.Ano);
        }

        [Fact]
        public void Deve_Criar_ParametroSistema_Herdando_EntidadeBase()
        {
            var parametro = new ParametroSistema(2024, true, "Desc", "Nome", TipoParametroSistema.FimProvaTurnoIntegral, "Valor");
            parametro.Id = 10;

            Assert.Equal(10, parametro.Id);
        }
    }
}