namespace Baskerville.Data.Mocks
{
    using Baskerville.Data.Contracts.Repository;
    using System.Data.Entity;

    public class FakeDbContext : IDbContext
    {
        public int SaveChanges()
        {
            return 0;
        }

        public IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return new FakeDbSet<TEntity>();
        }
    }
}
