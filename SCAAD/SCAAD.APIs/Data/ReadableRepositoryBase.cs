using SCAAD.APIs.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SCAAD.APIs.Data
{
    public abstract class ReadableRepositoryBase<T> : RepositoryBase where T : class
    {
        public virtual List<T> Get()
        {
            return context.Set<T>().ToList();
        }

        public virtual List<T> Get(string includedNavigationProperty)
        {
            return context.Set<T>().Include(includedNavigationProperty).ToList();
        }

        public virtual List<T> Get(string[] includes)
        {
            DbQuery<T> query = context.Set<T>();
            foreach (string include in includes)
            {
                query = query.Include(include);
            }
            return query.AsNoTracking().ToList();
        }

        public virtual List<T> Get(string [] includedNavigationProperties, 
                                   string [] includedNestedNavigationProperties)
        {
            DbQuery<T> query = context.Set<T>();

            foreach (string navigationProperty in includedNavigationProperties)
                query = query.Include(navigationProperty);

            DbQuery<T> nestedNavigationPropertyQuery = null;

            foreach (string nestedNavigationProperty in includedNestedNavigationProperties)
                nestedNavigationPropertyQuery = query.Include(nestedNavigationProperty);

            return query.AsNoTracking().ToList();
          
            
        }

        public virtual List<T> Get(Expression<Func<T, bool>> expresion)
        {
            return context.Set<T>().Where(expresion).ToList();
        }

        public virtual List<T> Get(Expression<Func<T, bool>> expression, string[] includedNavigationProperties
                                  ,string[] includedNestedNavigationProperties)
        {
            DbQuery<T> query = context.Set<T>();

            foreach (var includedNavigationProperty in includedNavigationProperties)
                query = query.Include(includedNavigationProperty);

            DbQuery<T> nestedNavigationPropertiesQuery = null;

            foreach (var includedNestedNavigationProperty in includedNestedNavigationProperties)
                nestedNavigationPropertiesQuery = query.Include(includedNestedNavigationProperty);

            return nestedNavigationPropertiesQuery.AsNoTracking().Where(expression).ToList();                      
        }

        public virtual List<T> Get(Expression<Func<T, bool>> expression, string[] includedNavigationProperties)
        {
            DbQuery<T> query = context.Set<T>();

            foreach (var includedNavigationProperty in includedNavigationProperties)
                query = query.Include(includedNavigationProperty);

            return query.AsNoTracking().Where(expression).ToList();
        }

    }
}