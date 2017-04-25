using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Models.ViewModels
{
    public class StatisticsViewModel
    {
        public int EnglishSpeakersCount { get; set; }

        public int BulgarianSpeakersCount { get; set; }

        public int TotaVisits { get; set; }

        public IEnumerable<short> YearsRange { get; set; }

        public IEnumerable<LastLogsViewModel> LastLogs { get; set; }
    }
}
