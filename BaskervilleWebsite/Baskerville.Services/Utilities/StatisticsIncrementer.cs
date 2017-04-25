namespace Baskerville.Services.Utilities
{
    using System;
    using Data.Contracts.Repository;
    using Models.DataModels;

    public class StatisticsIncrementer
    {
        private IRepository<Statistics> statistics;

        public StatisticsIncrementer(IRepository<Statistics> statistics)
        {
            this.statistics = statistics;
        }

        public void IncrementVistis()
        {
            var stat = this.GetCurrentStatistic();
            stat.HitsCount++;
            this.statistics.Update(stat);
        }

        public void IncrementSubscribers()
        {
            var stat = this.GetCurrentStatistic();
            stat.SubscribesCount++;
            this.statistics.Update(stat);
        }

        private Statistics GetCurrentStatistic()
        {
            var date = DateTime.Now;

            int year = date.Year;
            int month = date.Month;

            if (!statistics.Exists(s => s.Year == year))
                this.AddYearWithMonths(year);

            var stat = this.statistics.GetFirst(s => s.Year == year && s.Month == month);

            return stat;
        }

        private void AddYearWithMonths(int year)
        {
            for (byte i = 1; i <= 12; i++)
            {
                Statistics stat = new Statistics
                {
                    Year = (short)year,
                    Month = i,
                    HitsCount = 0,
                    SubscribesCount = 0
                };

                this.statistics.Insert(stat);
            }
        }
    }
}