using SCAAD.APIs.Data.Interfaces;
using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Data.Implementations
{
    public class EvidenciasRepository : UpdatableRepositoryBase<Evidencia>, IEvidenciasRepository
    {
        public void InsertEvidencias(Evidencia Evidencia)
        {
            context.Evidencias.Add(Evidencia);
        }
    }
}