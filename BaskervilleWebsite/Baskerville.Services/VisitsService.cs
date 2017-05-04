namespace Baskerville.Services
{
    using Data.Contracts.Repository;
    using Utilities;
    using Contracts;

    public class VisitsService : Service, IVisitsService
    {
        public VisitsService(IDbContext context)
            : base(context)
        {
        }

        public void VisitsIncrement()
        {
            var statIncr = new StatisticsIncrementer(this.Statistics);
            statIncr.IncrementVistis();
        }
    }
}