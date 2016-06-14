using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Logic.Interfaces
{
    public interface ISNILogic
    {
        void Insert(SNI SNI);
        List<SNI> GetAll();
    }
}