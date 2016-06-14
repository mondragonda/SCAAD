using SCAAD.APIs.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCAAD.APIs.Models;
using SCAAD.APIs.Data.Interfaces;

namespace SCAAD.APIs.Logic.Implementations
{
    public class SNILogic : ISNILogic
    {
        public SNILogic(ISNIRepository sniRepository)
        {
            this.sniRepository = sniRepository;
        }
        private readonly ISNIRepository sniRepository;
        public List<SNI> GetAll()
        {
            var SNIs = sniRepository.Get();

            return SNIs;
        }

        public void Insert(SNI SNI)
        {
            sniRepository.Insert(SNI);
        }
    }
}
