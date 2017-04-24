using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baskerville.Data.Contracts.Repository;
using Baskerville.Models.DataModels;
using Baskerville.Data.Repository;

namespace Baskerville.Services
{
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
            var date = DateTime.Now;

            short year = (short)date.Year;
            byte month = (byte)date.Month;

            if (!statistics.Exists(s => s.Year == year))
                this.AddMonths(year);

            var stat = this.statistics.GetFirst(s => s.Year == year && s.Month == month);
            stat.HitsCount++;

            this.statistics.Update(stat);
        }

        private void AddMonths(short year)
        {
            for (byte i = 1; i <= 12; i++)
            {
                Statistics stat = new Statistics
                {
                    Year = year,
                    Month = i,
                    HitsCount = 0,
                    SubscribesCount = 0
                };

                this.statistics.Insert(stat);
            }
        }
    }
}