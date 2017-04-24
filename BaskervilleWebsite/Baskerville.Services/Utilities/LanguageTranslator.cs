using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Services.Utilities
{
    public static class LanguageTranslator
    {
        private static readonly IDictionary<string, string> EnBgMonthsDictionary = new Dictionary<string, string>()
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

        private static readonly IDictionary<byte, string> NumBgMonthsDictionry = new Dictionary<byte, string>()
        {
            { 1, "януари" },
            { 2, "февруари" },
            { 3, "март" },
            { 4, "април" },
            { 5, "май" },
            { 6, "юни" },
            { 7, "юли" },
            { 8, "август" },
            { 9, "септември" },
            { 10, "октомври" },
            { 11, "ноември" },
            { 12, "декември" }
        };

        public static string TranslateEnBgMonth(string month)
        {
            string result = EnBgMonthsDictionary[month];

            return result;
        }

        public static string TranslateNumBgMonth(byte num)
        {
            string result = NumBgMonthsDictionry[num];

            return result;
        }
    }
}
