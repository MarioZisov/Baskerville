namespace Baskerville.Data.Mocks
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class FakeDbSet<T> : DbSet<T>, IEnumerable<T>, IQueryable where T : class
    {
        private HashSet<T> set;
        private IQueryable queryable;

        public FakeDbSet()
        {
            this.set = new HashSet<T>();
            this.queryable = this.set.AsQueryable();
        }

        protected HashSet<T> Set => this.set;

        protected IQueryable Queryable => this.queryable;

        public override T Add(T entity)
        {
            this.set.Add(entity);
            return entity;
        }

        public override T Remove(T entity)
        {
            this.set.Remove(entity);
            return entity;
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return this.queryable.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return this.queryable.Provider; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.set.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.set.GetEnumerator();
        }

    }
}
