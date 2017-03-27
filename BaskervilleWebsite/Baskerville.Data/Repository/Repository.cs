using Baskerville.Data.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Data.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly IDbContext context;
        private IDbSet<T> entities;

        public Repository(IDbContext context)
        {
            this.context = context;
        }

        protected IDbSet<T> Entities
            => this.entities ?? this.context.Set<T>();

        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        public void Delete(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            foreach (var entity in entities)
                this.Entities.Remove(entity);

            this.context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this.Entities.Remove(entity);

            this.context.SaveChanges();
        }

        public void Insert(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException();

            foreach (var entity in entities)
                this.Entities.Add(entity);

            this.context.SaveChanges();
        }

        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            this.Entities.Add(entity);

            this.context.SaveChanges();
        }

        public void Update(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException();

            this.context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            this.context.SaveChanges();
        }
    }
}
