using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Logic.Business_Rules.VigenciaSNI
{
    public static class VigenciaSNIErrorMessages
    {
        public static string InvalidVigenciaSNI
        {
            get
            {
                return "El id de SNI no esta registrado en el sistema o "+
                       "la fecha de la vigencia del SNI es anterior a "+DateTime.Now;
            }
        }
    }
}
