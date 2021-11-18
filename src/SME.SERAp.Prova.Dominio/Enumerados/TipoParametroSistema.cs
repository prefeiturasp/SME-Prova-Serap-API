using System;
using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum TipoParametroSistema
    {
        InicioProvaTurnoManha = 1,
        InicioProvaTurnoIntermediario = 2,
        InicioProvaTurnoTarde = 3,
        TempoExtraProva = 4,
        TempoAlertaProva = 5,
        FimProvaTurnoManha = 6,
        FimProvaTurnoIntermediario = 7,
        FimProvaTurnoTarde = 8,
        InicioProvaTurnoVespertino = 9,
        InicioProvaTurnoNoite = 10,
        InicioProvaTurnoIntegral = 11,
        FimProvaTurnoVespertino = 9,
        FimProvaTurnoNoite = 10,
        FimProvaTurnoIntegral = 11,
    }

    public static class TipoParametroSistemaExtension
    {
        public static TipoParametroSistema ObterParametroTurnoInicio(string tipoTurnoAluno)
        {
            return (TipoTurno)int.Parse(tipoTurnoAluno) switch
            {
                TipoTurno.Manha => TipoParametroSistema.InicioProvaTurnoManha,
                TipoTurno.Intermediario => TipoParametroSistema.InicioProvaTurnoIntermediario,
                TipoTurno.Tarde => TipoParametroSistema.InicioProvaTurnoTarde,
                TipoTurno.Vespertino => TipoParametroSistema.InicioProvaTurnoVespertino,
                TipoTurno.Noite => TipoParametroSistema.InicioProvaTurnoNoite,
                TipoTurno.Integral => TipoParametroSistema.InicioProvaTurnoIntegral,
                _ => default,
            };
        }

        public static TipoParametroSistema ObterParametroTurnoFim(string tipoTurnoAluno)
        {
            return (TipoTurno)int.Parse(tipoTurnoAluno) switch
            {
                TipoTurno.Manha => TipoParametroSistema.FimProvaTurnoManha,
                TipoTurno.Intermediario => TipoParametroSistema.FimProvaTurnoIntermediario,
                TipoTurno.Tarde => TipoParametroSistema.FimProvaTurnoTarde,
                TipoTurno.Vespertino => TipoParametroSistema.FimProvaTurnoVespertino,
                TipoTurno.Noite => TipoParametroSistema.FimProvaTurnoNoite,
                TipoTurno.Integral => TipoParametroSistema.FimProvaTurnoIntegral,
                _ => default,
            };
        }
    }
}