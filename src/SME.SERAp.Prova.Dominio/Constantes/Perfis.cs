using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dominio.Constantes
{
   public static class Perfis
    {
        public readonly static Guid PERFIL_ADMINISTRADOR = Guid.Parse("AAD9D772-41A3-E411-922D-782BCB3D218E");
        public readonly static Guid PERFIL_ADMINISTRADOR_NTA = Guid.Parse("22366A3E-9E4C-E711-9541-782BCB3D218E");
        public readonly static Guid PERFIL_PROFESSOR = Guid.Parse("E77E81B1-191E-E811-B259-782BCB3D2D76");
        public readonly static Guid PERFIL_SERAP_DRE = Guid.Parse("104F0759-87E8-E611-9541-782BCB3D218E");
        public readonly static Guid PERFIL_SERAP_UE = Guid.Parse("4318D329-17DC-4C48-8E59-7D80557F7E77");
    }
}
