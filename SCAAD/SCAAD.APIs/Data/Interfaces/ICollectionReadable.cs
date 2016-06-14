using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Data.Interfaces
{
    public interface ICollectionReadable<T>
    {
        List<T> Get();
        List<T> Get(string[] includes);
        List<T> Get(Expression<Func<T, bool>> expresion);
    }
}
