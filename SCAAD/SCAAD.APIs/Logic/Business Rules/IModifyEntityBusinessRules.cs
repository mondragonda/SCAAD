using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Logic.Business_Rules
{
    public interface IModifyEntityBusinessRules<T>
    {
        bool CanModify(int entityId, T modifiedEntity);
    }
}
