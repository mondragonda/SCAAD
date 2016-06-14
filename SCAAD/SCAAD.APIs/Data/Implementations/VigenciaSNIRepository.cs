using SCAAD.APIs.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCAAD.APIs.Models;

namespace SCAAD.APIs.Data.Implementations
{
    public class VigenciaSNIRepository : UpdatableRepositoryBase<VigenciaSNI>, IVigenciaSNIRepository
    {
        public void InsertVigenciaSNI(VigenciaSNI vigenciaSNI)
        {
            base.Insert(vigenciaSNI);
        }

        public IEnumerable<VigenciaSNI> ReadVigenciasSNI()
        {
            var vigenciasSNI = base.Get("SNI");

            return vigenciasSNI;
        }
    }
}
