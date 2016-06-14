using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Common
{
    public static class Constants
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public const string Usuario = "Usuario";
        public const string Director = "Director";
        public const string Docente = "Docente";
        public const string DominoCorreoUABC = "uabc.edu.mx";


        public const int EstadoModificacionActividad_Revision=3;
        public const int EstadoModificacionActividad_Aceptado = 1;
        public const int EstadoModificacionActividad_Rechazado = 2;

        public const int TipoCambio_Modificacion = 1;
        public const int TipoCambio_Cancelacion = 2;

        public const int PAADEstatus_Rechazado = 2;
        public const int PAADEstatus_Aprobado = 1;
        public const int PAADEstatus_RevisionParaModificacion = 3;
        public const int PAADEstatus_RevisionParaAprobacion = 4;
        public const int PAADEstatus_AprobadoParaModificacion = 5;

        public const int ActividadEstatus_NoAcompletado = 1;
        public const int ActividadEstatus_Completado = 2;
        public const int ActividadEstatus_RevisionParaModificacion = 3;
        public const int ActividadEstatus_RevisionParaCancelacion = 4;
    }
}
