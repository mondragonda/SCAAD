using SCAAD.APIs.Data.Implementations;
using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Logic.Business_Rules;
using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Logic.Implementations
{
    public class VigenciaSNIBusinessRules : ICreateEntityBusinessRules<VigenciaSNI>
    {
        public bool CanCreate(VigenciaSNI entity)
        {
            if (SNIExists(entity) && VigenciaSNIDateIsValid(entity))
                return true;
            else
                return false;
        }

        private bool SNIExists(VigenciaSNI entity)
        {
            ISNIRepository sniRepository = new SNIRepository();

            var SNIs = sniRepository.Get();

            var sni = SNIs.Where(s => s.Id == entity.SNI_Id).FirstOrDefault();

            if (sni != null)
                return true;
            else
                return false;
        }

        private bool VigenciaSNIDateIsValid(VigenciaSNI entity)
        {
            var vigenciaSNIDate = entity.Fecha;
            var currentDate = DateTime.Now;

            if (vigenciaSNIDate >= currentDate)
                return true;
            else
                return false;
        }
    }
}
