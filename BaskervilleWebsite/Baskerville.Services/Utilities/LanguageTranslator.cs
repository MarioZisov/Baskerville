using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Services.Utilities
{
    public static class LanguageTranslator
    {
        private static readonly IDictionary<string, string> MonthsDictionry = new Dictionary<string, string>()
        {
            { "January", "януари" },
            { "February", "февруари" },
            { "March", "март" },
            { "April", "април" },
            { "May", "май" },
            { "June", "юни" },
            { "July", "юли" },
            { "August", "август" },
            { "September", "септември" },
            { "October", "октомври" },
            { "November", "ноември" },
            { "December", "декември" }
        };

        public static string TranslateMonth(string month)
        {
            string result = MonthsDictionry[month];

            return result;
        }
    }
}
