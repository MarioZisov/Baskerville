namespace Baskerville.Services
{
    using Data;
    using Data.Contracts.Repository;

    public abstract class Service
    {
        public Service()
        {
            this.Context = new BaskervilleContext();
        }

        protected IDbContext Context { get; private set; }
    }
}
