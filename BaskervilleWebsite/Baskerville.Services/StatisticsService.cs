using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baskerville.Data.Contracts.Repository;
using Baskerville.Models.DataModels;
using Baskerville.Data.Repository;
using Baskerville.Models.ViewModels;
using Baskerville.Models.Enums;
using Baskerville.Services.Utilities;

namespace Baskerville.Services
{
    public class StatisticsService : Service
    {
        private IRepository<Statistics> statistics;
        private IRepository<Subscriber> subscribers;

        public StatisticsService(IDbContext context)
            : base(context)
        {
            this.statistics = new Repository<Statistics>(context);
            this.subscribers = new Repository<Subscriber>(context);
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

            var model = new StatisticsViewModel
            {
                BulgarianSpeakersCount = bgSpeakers,
                EnglishSpeakersCount = enSpeakers,
                YearsRange = yearsRange
            };

            return model;
        }
    }
}
