using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SCAAD.APIs.Data
{
    public abstract class UpdatableRepositoryBase<T> : ReadableRepositoryBase<T> where T : class
    {
        public virtual void Insert(T model)
        {
            try
            {
                context.Set<T>().Add(model);
                this.context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public virtual void Update(int modelId, T model)
        {
            var modelToUpdate = context.Set<T>().Find(modelId);

            context.Entry(modelToUpdate).State = EntityState.Modified;

            context.SaveChanges();
        }

        public virtual void Delete(T model)
        {
            context.Set<T>().Remove(model);
            this.context.SaveChanges();
        }

        public virtual void Update(T entity, params Expression<Func<T, object>>[] properties)
        {
            var entry = context.Entry(entity);
            context.Set<T>().Attach(entity);
            foreach (var property in properties)
            {
                entry.Property(property).IsModified = true;
            }

            context.SaveChanges();
        }
    }
}