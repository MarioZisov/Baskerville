using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Models.Constants
{
    internal static class PublicMessages
    {
        internal const int MaxMessageLength = 500;

        internal const int MinMessageLength = 10;

        internal const int MaxNameLength = 100;

        internal const int MinNameLength = 2;

        internal const string RequiredMessage = "Полето {0} е задължителенo";

        internal const string LengthMessage = "Полето {0} трябва да бъде между {2} и {1} символа";

        internal const string InvlidEmailMessage = "Невалиден имейл адрес";
    }
}
