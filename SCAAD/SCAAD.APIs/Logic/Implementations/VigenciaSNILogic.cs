using SCAAD.APIs.Logic.Interfaces;
using System;
using System.Collections.Generic;
using SCAAD.APIs.Models;
using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Logic.Business_Rules;
using SCAAD.APIs.Logic.Business_Rules.VigenciaSNI;

namespace SCAAD.APIs.Logic.Implementations
{
    public class VigenciaSNILogic : IVigenciaSNILogic
    {
        public VigenciaSNILogic(IVigenciaSNIRepository vigenciaSNIRepository, 
                                ICreateEntityBusinessRules<VigenciaSNI> createVigenciaSNIBusinessRules)
        {
            this.vigenciaSNIRepository = vigenciaSNIRepository;
            this.createVigenciaSNIBusinessRules = createVigenciaSNIBusinessRules;
        }

        private readonly IVigenciaSNIRepository vigenciaSNIRepository;
        private readonly ICreateEntityBusinessRules<VigenciaSNI> createVigenciaSNIBusinessRules;

        public void AddVigenciaSNI(VigenciaSNI vigenciaSNI)
        {
            if (createVigenciaSNIBusinessRules.CanCreate(vigenciaSNI))
                vigenciaSNIRepository.InsertVigenciaSNI(vigenciaSNI);
            else
                throw new InvalidOperationException(VigenciaSNIErrorMessages.InvalidVigenciaSNI);
        }

        public IEnumerable<VigenciaSNI> GetVigenciasSNI()
        {
            var vigenciasSNI = vigenciaSNIRepository.ReadVigenciasSNI();

            return vigenciasSNI;
        }
    }
}
