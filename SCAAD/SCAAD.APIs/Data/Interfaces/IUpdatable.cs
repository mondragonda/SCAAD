using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SCAAD.APIs.Data.Interfaces
{
    public interface IUpdatable<T> : ICollectionReadable<T>
    {
        void Insert(T model);
        void Update(int modelId, T model);
        void Update(T entity, params Expression<Func<T, object>>[] properties);
        void Delete(T model);
    }
}