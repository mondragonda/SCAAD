using System;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Data.Interfaces
{
    public interface IReadable<T>
    {
        T Get(Expression<Func<T, bool>> expresion);
    }
}
