namespace Baskerville.Services
{
    using Data.Contracts.Repository;
    using Models.DataModels;
    using Data.Repository;
    using Utilities;

    public class VisitsService : Service
    {
        IRepository<Statistics> statistics;

        public VisitsService(IDbContext context)
            : base(context)
        {
            this.statistics = new Repository<Statistics>(context);
        }

        public void VisitsIncrement()
        {
            var statIncr = new StatisticsIncrementer(this.statistics);
            statIncr.IncrementVistis();
        }
    }
}