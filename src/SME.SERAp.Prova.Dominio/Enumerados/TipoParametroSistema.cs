using System;
using System.ComponentModel.DataAnnotations;

namespace SME.SERAp.Prova.Dominio
{
    public enum TipoParametroSistema
    {
        InicioProvaTurnoManhaIntegral = 1,
        InicioProvaTurnoTarde = 2,
        InicioProvaTurnoNoite = 3,
        TempoExtraProva = 4,
        TempoAlertaProva = 5,
        FimProvaTurnoManhaIntegral = 6,
        FimProvaTurnoTarde = 7,
        FimProvaTurnoNoite = 8,
    }

    public static class TipoParametroSistemaExtension
    {
        public static TipoParametroSistema ObterParametroTurnoInicio(string tipoTurnoAluno)
        {
            return (TipoTurno)int.Parse(tipoTurnoAluno) switch
            {
                TipoTurno.Manha => TipoParametroSistema.InicioProvaTurnoManhaIntegral,
                TipoTurno.Tarde => TipoParametroSistema.InicioProvaTurnoTarde,
                TipoTurno.Noturno => TipoParametroSistema.InicioProvaTurnoNoite,
                _ => default,
            };
        }

        public static TipoParametroSistema ObterParametroTurnoFim(string tipoTurnoAluno)
        {
            return (TipoTurno)int.Parse(tipoTurnoAluno) switch
            {
                TipoTurno.Manha => TipoParametroSistema.FimProvaTurnoManhaIntegral,
                TipoTurno.Tarde => TipoParametroSistema.FimProvaTurnoTarde,
                TipoTurno.Noturno => TipoParametroSistema.FimProvaTurnoNoite,
                _ => default,
            };
        }
    }
}