namespace Baskerville.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Contracts.Repository;
    using Models.DataModels;
    using Models.ViewModels;
    using Models.Enums;
    using Utilities;
    using Contracts;

    public class StatisticsService : Service, IStatisticsService
    {
        public StatisticsService(IDbContext context)
            : base(context)
        {
        }

        public IEnumerable<BarChartViewModel> GetBarChartData(int year)
        {
            var stats = this.Statistics.Find(s => s.Year == year).ToList();

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
            int enSpeakers = this.Subscribers
                .Find(s => s.IsActive && !s.IsRemoved && s.PreferedLanguage == Language.EN)
                .Count();

            int bgSpeakers = this.Subscribers
                .Find(s => s.IsActive && !s.IsRemoved && s.PreferedLanguage == Language.BG)
                .Count();

            IEnumerable<short> yearsRange = this.Statistics
                .GetAll()
                .Select(s => s.Year)
                .Distinct()
                .OrderByDescending(s => s)
                .ToList();

            var logs = this.UserLogs
                .GetAll()
                .OrderByDescending(l => l.Date)
                .Take(10)
                .Select(l => new LastLogsViewModel
                    {
                        Date = l.Date,
                        Username = l.User.UserName
                    })
                .ToList();

            int totalVisits = this.Statistics.GetAll().Sum(s => s.HitsCount);

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
