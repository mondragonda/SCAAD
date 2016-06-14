using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.EmailTemplates
{
    public static class EmailHtmlTemplates
    {
        public class EmailContent
        {
            public string Subject { get; set; }
            public string Body { get; set; }

        }
        public static EmailContent CorreoAgregarDocente(string UserName, string Password)
        {
            EmailContent emailContent = new EmailContent()
            {
                Subject = string.Format("Creación de cuenta de acceso al Sistema"),
                Body = string.Format("<p align=\"left\">Por este medio se te notifica que ya cuentas con una cuenta con acceso " +
                "al Sistema De Actividades Académicas y Docencia (SCAAD) donde podrás subir tu "+
                "Propuesta Académica de Actividades y Docencia (PAAD) cada semestre."+
                "<br/>Podrás ingresar con tu cuenta de correo institucional como nombre de usuario: <b> {0} </b> "+
                "y por contraseña con tu número de empleado: <b> {1} </b>." +
                "Al momento de ingresar se te pedirá actualizar tu información personal y podrás cambiar tu contraseña.<br/>Atte."+
                "<br/>El Sistema De Actividades Académicas y Docencia(SCAAD)</p>", UserName, Password)
            };



            return emailContent;
        }

        public static EmailContent CorreoRevocaciónDeAccesoAlSistema()
        {
            EmailContent emailContent = new EmailContent()
            {
                Subject = string.Format("Revocación de acceso al Sistema"),
                Body = string.Format("<p align=\"left\">Por este medio se te notifica que se te revoco el acceso al Sistema De Actividades Académicas y Docencia (SCAAD). " +
                "Si deseas volver a recuperar tu acceso por favor comunícate con el Administrador del Sistema, lo antes posible."+
                "<br/>Atte."+
                "<br/>El Sistema De Actividades Académicas y Docencia(SCAAD)</p>")
            };



            return emailContent;
        }


        public static EmailContent CorreoAutorizaciónDeAccesoAlSistema()
        {
            EmailContent emailContent = new EmailContent()
            {
                Subject = string.Format("Autorización de acceso al Sistema"),
                Body = string.Format("<p align=\"left\">Por este medio se te notifica que vuelves a tener acceso al Sistema De Actividades Académicas y Docencia (SCAAD).  " +
                "<br/>Atte." +
                "<br/>El Sistema De Actividades Académicas y Docencia(SCAAD)</p>")
            };



            return emailContent;
        }

        public static EmailContent CorreoSolicitudDeRevisiónDePAADParaAprobación(Docente Docente,Periodo Periodo)
        {
            EmailContent emailContent = new EmailContent()
            {
                Subject = string.Format("Solicitud de revisión de PAAD para aprobación"),
                Body = string.Format("<p align=\"left\">Por este medio se te notifica que el docente {0} "+
                "ha solicitado que la cabecera de su PAAD del periodo {1} se revise para autorizar su aprobación.  " +
                "<br/>Atte." +
                "<br/>El Sistema De Actividades Académicas y Docencia(SCAAD)</p>",Docente.NombreCompleto,Periodo.Ciclo)
            };



            return emailContent;
        }


        public static EmailContent CorreoSolicitudDeRevisiónDePAADParaModificación(Docente Docente, Periodo Periodo,string Motivo)
        {
            EmailContent emailContent = new EmailContent()
            {
                Subject = string.Format("Solicitud de revisión de PAAD para aprobación"),
                Body = string.Format("<p align=\"left\">Por este medio se te notifica que el docente {0} " +
                "ha solicitado que la cabecera de su PAAD del periodo {1} se revise para autorizar su modificación. El docente justifica el cambio debido a que:  " +
                "<br/><b>{2}</b>"+
                "<br/>Atte." +
                "<br/>El Sistema De Actividades Académicas y Docencia(SCAAD)</p>", Docente.NombreCompleto, Periodo.Ciclo,Motivo)
            };



            return emailContent;
        }

        public static EmailContent CorreoSolicitudDeRevisiónDeActividadParaModificación(Docente Docente, Periodo Periodo, string Motivo)
        {
            EmailContent emailContent = new EmailContent()
            {
                Subject = string.Format("Solicitud de revisión de PAAD para aprobación"),
                Body = string.Format("<p align=\"left\">Por este medio se te notifica que el docente {0} " +
                "ha solicitado que la cabecera de su PAAD del periodo {1} se revise para autorizar su modificación. El docente justifica el cambio debido a que:  " +
                "<br/><b>{2}</b>" +
                "<br/>Atte." +
                "<br/>El Sistema De Actividades Académicas y Docencia(SCAAD)</p>", Docente.NombreCompleto, Periodo.Ciclo, Motivo)
            };



            return emailContent;
        }
    }
}