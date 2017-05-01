namespace Baskerville.Services
{
    using Data.Contracts.Repository;
    using Models.DataModels;
    using Data.Repository;
    using Utilities;
    using Contracts;

    public class VisitsService : Service, IVisitsService
    {
        IRepository<Statistics> statistics;

        public VisitsService()
        {
            this.statistics = new Repository<Statistics>(this.Context);
        }

        public void VisitsIncrement()
        {
            var statIncr = new StatisticsIncrementer(this.statistics);
            statIncr.IncrementVistis();
        }
    }
}