namespace Baskerville.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Contracts.Repository;
    using Models.DataModels;
    using Data.Repository;
    using Models.ViewModels;
    using Models.Enums;
    using Utilities;

    public class StatisticsService : Service
    {
        private IRepository<Statistics> statistics;
        private IRepository<Subscriber> subscribers;
        private IRepository<UserLog> userLogs;

        public StatisticsService(IDbContext context)
            : base(context)
        {
            this.statistics = new Repository<Statistics>(context);
            this.subscribers = new Repository<Subscriber>(context);
            this.userLogs = new Repository<UserLog>(context);
        }

        public IEnumerable<BarChartViewModel> GetBarChartData(int year)
        {
            var stats = this.statistics.Find(s => s.Year == year).ToList();

            ICollection<BarChartViewModel> models = new List<BarChartViewModel>();
            foreach (var stat in stats)
            {
                BarChartViewModel model = new BarChartViewModel
                {
                    HitsCount = stat.HitsCount,
                    SubscribesCount = stat.SubscribesCount,
                    Month = LanguageTranslator.TranslateNumBgMonth(stat.Month)
                };

                models.Add(model);
            }

            return models;
        }

        public StatisticsViewModel GetStatistics()
        {
            int enSpeakers = this.subscribers
                .Find(s => s.IsActive && !s.IsRemoved && s.PreferedLanguage == Language.EN)
                .Count();

            int bgSpeakers = this.subscribers
                .Find(s => s.IsActive && !s.IsRemoved && s.PreferedLanguage == Language.BG)
                .Count();

            IEnumerable<short> yearsRange = this.statistics
                .GetAll()
                .Select(s => s.Year)
                .Distinct()
                .OrderByDescending(s => s)
                .ToList();

            var logs = this.userLogs
                .GetAll()
                .OrderByDescending(l => l.Date)
                .Take(10)
                .Select(l => new LastLogsViewModel
                    {
                        Date = l.Date,
                        Username = l.User.UserName
                    })
                .ToList();

            int totalVisits = this.statistics.GetAll().Sum(s => s.HitsCount);

            var model = new StatisticsViewModel
            {
                BulgarianSpeakersCount = bgSpeakers,
                EnglishSpeakersCount = enSpeakers,
                YearsRange = yearsRange,
                LastLogs = logs,
                TotaVisits = totalVisits
            };

            return model;
        }
    }
}
