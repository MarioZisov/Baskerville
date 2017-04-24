using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Models.DataModels
{
    public class Statistics
    {
        public int Id { get; set; }

        public short Year { get; set; }

        public byte Month { get; set; }

        public int HitsCount { get; set; }

        public int SubscribesCount { get; set; }
    }
}
