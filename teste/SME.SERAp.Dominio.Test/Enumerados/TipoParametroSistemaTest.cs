using SME.SERAp.Prova.Dominio;
using System;
using Xunit;

namespace SME.SERAp.Dominio.Test.Enumerados
{
    public class TipoParametroSistemaTest
    {
        [Fact]
        public void Deve_Conter_Membro_InicioProvaTurnoManha_Com_Valor_1()
        {
            Assert.Equal(1, (int)TipoParametroSistema.InicioProvaTurnoManha);
        }

        [Fact]
        public void Deve_Conter_Membro_InicioProvaTurnoIntermediario_Com_Valor_2()
        {
            Assert.Equal(2, (int)TipoParametroSistema.InicioProvaTurnoIntermediario);
        }

        [Fact]
        public void Deve_Conter_Membro_InicioProvaTurnoTarde_Com_Valor_3()
        {
            Assert.Equal(3, (int)TipoParametroSistema.InicioProvaTurnoTarde);
        }

        [Fact]
        public void Deve_Conter_Membro_TempoExtraProva_Com_Valor_4()
        {
            Assert.Equal(4, (int)TipoParametroSistema.TempoExtraProva);
        }

        [Fact]
        public void Deve_Conter_Membro_TempoAlertaProva_Com_Valor_5()
        {
            Assert.Equal(5, (int)TipoParametroSistema.TempoAlertaProva);
        }

        [Fact]
        public void Deve_Conter_Membro_FimProvaTurnoManha_Com_Valor_6()
        {
            Assert.Equal(6, (int)TipoParametroSistema.FimProvaTurnoManha);
        }

        [Fact]
        public void Deve_Conter_Membro_FimProvaTurnoIntermediario_Com_Valor_7()
        {
            Assert.Equal(7, (int)TipoParametroSistema.FimProvaTurnoIntermediario);
        }

        [Fact]
        public void Deve_Conter_Membro_FimProvaTurnoTarde_Com_Valor_8()
        {
            Assert.Equal(8, (int)TipoParametroSistema.FimProvaTurnoTarde);
        }

        [Fact]
        public void Deve_Conter_Membro_InicioProvaTurnoVespertino_Com_Valor_9()
        {
            Assert.Equal(9, (int)TipoParametroSistema.InicioProvaTurnoVespertino);
        }

        [Fact]
        public void Deve_Conter_Membro_InicioProvaTurnoNoite_Com_Valor_10()
        {
            Assert.Equal(10, (int)TipoParametroSistema.InicioProvaTurnoNoite);
        }

        [Fact]
        public void Deve_Conter_Membro_InicioProvaTurnoIntegral_Com_Valor_11()
        {
            Assert.Equal(11, (int)TipoParametroSistema.InicioProvaTurnoIntegral);
        }

        [Fact]
        public void Deve_Conter_Membro_FimProvaTurnoVespertino_Com_Valor_12()
        {
            Assert.Equal(12, (int)TipoParametroSistema.FimProvaTurnoVespertino);
        }

        [Fact]
        public void Deve_Conter_Membro_FimProvaTurnoNoite_Com_Valor_13()
        {
            Assert.Equal(13, (int)TipoParametroSistema.FimProvaTurnoNoite);
        }

        [Fact]
        public void Deve_Conter_Membro_FimProvaTurnoIntegral_Com_Valor_14()
        {
            Assert.Equal(14, (int)TipoParametroSistema.FimProvaTurnoIntegral);
        }

        [Fact]
        public void Deve_Conter_Membro_TipoEscolaSerap_Com_Valor_15()
        {
            Assert.Equal(15, (int)TipoParametroSistema.TipoEscolaSerap);
        }

        [Fact]
        public void Deve_Conter_Membro_ToleranciaDataHoraServidor_Com_Valor_16()
        {
            Assert.Equal(16, (int)TipoParametroSistema.ToleranciaDataHoraServidor);
        }

        [Fact]
        public void Deve_Conter_Exatamente_Dezesseis_Membros()
        {
            var valores = Enum.GetValues(typeof(TipoParametroSistema));
            Assert.Equal(16, valores.Length);
        }

        [Fact]
        public void ObterParametroTurnoInicio_Deve_Retornar_Manha_Para_Turno_1()
        {
            var resultado = TipoParametroSistemaExtension.ObterParametroTurnoInicio("1");
            Assert.Equal(TipoParametroSistema.InicioProvaTurnoManha, resultado);
        }

        [Fact]
        public void ObterParametroTurnoInicio_Deve_Retornar_Intermediario_Para_Turno_2()
        {
            var resultado = TipoParametroSistemaExtension.ObterParametroTurnoInicio("2");
            Assert.Equal(TipoParametroSistema.InicioProvaTurnoIntermediario, resultado);
        }

        [Fact]
        public void ObterParametroTurnoInicio_Deve_Retornar_Tarde_Para_Turno_3()
        {
            var resultado = TipoParametroSistemaExtension.ObterParametroTurnoInicio("3");
            Assert.Equal(TipoParametroSistema.InicioProvaTurnoTarde, resultado);
        }

        [Fact]
        public void ObterParametroTurnoInicio_Deve_Retornar_Vespertino_Para_Turno_4()
        {
            var resultado = TipoParametroSistemaExtension.ObterParametroTurnoInicio("4");
            Assert.Equal(TipoParametroSistema.InicioProvaTurnoVespertino, resultado);
        }

        [Fact]
        public void ObterParametroTurnoInicio_Deve_Retornar_Noite_Para_Turno_5()
        {
            var resultado = TipoParametroSistemaExtension.ObterParametroTurnoInicio("5");
            Assert.Equal(TipoParametroSistema.InicioProvaTurnoNoite, resultado);
        }

        [Fact]
        public void ObterParametroTurnoInicio_Deve_Retornar_Integral_Para_Turno_6()
        {
            var resultado = TipoParametroSistemaExtension.ObterParametroTurnoInicio("6");
            Assert.Equal(TipoParametroSistema.InicioProvaTurnoIntegral, resultado);
        }

        [Fact]
        public void ObterParametroTurnoInicio_Deve_Retornar_Default_Para_Turno_Invalido()
        {
            var resultado = TipoParametroSistemaExtension.ObterParametroTurnoInicio("99");
            Assert.Equal(default(TipoParametroSistema), resultado);
        }

        [Fact]
        public void ObterParametroTurnoFim_Deve_Retornar_Manha_Para_Turno_1()
        {
            var resultado = TipoParametroSistemaExtension.ObterParametroTurnoFim("1");
            Assert.Equal(TipoParametroSistema.FimProvaTurnoManha, resultado);
        }

        [Fact]
        public void ObterParametroTurnoFim_Deve_Retornar_Intermediario_Para_Turno_2()
        {
            var resultado = TipoParametroSistemaExtension.ObterParametroTurnoFim("2");
            Assert.Equal(TipoParametroSistema.FimProvaTurnoIntermediario, resultado);
        }

        [Fact]
        public void ObterParametroTurnoFim_Deve_Retornar_Tarde_Para_Turno_3()
        {
            var resultado = TipoParametroSistemaExtension.ObterParametroTurnoFim("3");
            Assert.Equal(TipoParametroSistema.FimProvaTurnoTarde, resultado);
        }

        [Fact]
        public void ObterParametroTurnoFim_Deve_Retornar_Vespertino_Para_Turno_4()
        {
            var resultado = TipoParametroSistemaExtension.ObterParametroTurnoFim("4");
            Assert.Equal(TipoParametroSistema.FimProvaTurnoVespertino, resultado);
        }

        [Fact]
        public void ObterParametroTurnoFim_Deve_Retornar_Noite_Para_Turno_5()
        {
            var resultado = TipoParametroSistemaExtension.ObterParametroTurnoFim("5");
            Assert.Equal(TipoParametroSistema.FimProvaTurnoNoite, resultado);
        }

        [Fact]
        public void ObterParametroTurnoFim_Deve_Retornar_Integral_Para_Turno_6()
        {
            var resultado = TipoParametroSistemaExtension.ObterParametroTurnoFim("6");
            Assert.Equal(TipoParametroSistema.FimProvaTurnoIntegral, resultado);
        }

        [Fact]
        public void ObterParametroTurnoFim_Deve_Retornar_Default_Para_Turno_Invalido()
        {
            var resultado = TipoParametroSistemaExtension.ObterParametroTurnoFim("99");
            Assert.Equal(default(TipoParametroSistema), resultado);
        }
    }
}