using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Data
{
    public abstract class RepositoryBase
    {
        protected SCAAD_DbContext context;

        public RepositoryBase()
        {
            context = new SCAAD_DbContext();
        }
    }
}