using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Logic.Business_Rules
{
    public interface ICreateEntityBusinessRules<T>
    {
        bool CanCreate(T entity);
    }
}
