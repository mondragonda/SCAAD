using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Validators
{
    public static class ControllerRequestErrorMessages
    {
        public static string InvalidRequestInformation
        {
            get
            {
                return "la información enviada en la petición no es válida";
            }
        }

    }
}