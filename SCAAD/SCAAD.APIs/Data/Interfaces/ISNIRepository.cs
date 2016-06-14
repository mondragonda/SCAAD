using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Data.Interfaces
{
    public interface ISNIRepository : IUpdatable<SNI>, ICollectionReadable<SNI>
    {
    }
}