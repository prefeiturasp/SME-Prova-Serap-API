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
    }
}