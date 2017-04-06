using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Models
{
    internal class Constants
    {
        #region Validation attrbiutes constants
        internal const string RequiredFildMessage = "Полето е задължително";

        internal const string NameLenghtMessage = "Името трябва да е между {2} и {1} символа";

        internal const string DescriptionLenghtMessage = "Описаниeто трябва да е между {2} и {1} символа";

        internal const int MinProductNameLegnth = 2;

        internal const int MaxProductNameLegnth = 255;

        internal const int MinEventNameLegnth = 5;

        internal const int MaxEventNameLegnth = 50;

        internal const int MinEventDescriptionLegnth = 20;

        internal const int MaxEventDescriptionLegnth = 500;
        #endregion
    }
}
