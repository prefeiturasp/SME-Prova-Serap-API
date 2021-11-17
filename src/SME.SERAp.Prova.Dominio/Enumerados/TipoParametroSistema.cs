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
    }

    public static class TipoParametroSistemaExtension
    {
        public static TipoParametroSistema ObterParametroTurno(string tipoTurnoAluno)
        {
            return (TipoTurno)int.Parse(tipoTurnoAluno) switch
            {
                TipoTurno.Manha => TipoParametroSistema.InicioProvaTurnoManhaIntegral,
                TipoTurno.Tarde => TipoParametroSistema.InicioProvaTurnoTarde,
                TipoTurno.Noturno => TipoParametroSistema.InicioProvaTurnoNoite,
                _ => default,
            };
        }
    }
}