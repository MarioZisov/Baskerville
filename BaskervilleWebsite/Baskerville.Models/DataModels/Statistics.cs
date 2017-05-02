namespace Baskerville.Models.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class Statistics
    {
        public int Id { get; set; }

        [Range(1999, 9999)]
        public short Year { get; set; }

        [Range(1, 12)]
        public byte Month { get; set; }

        public int HitsCount { get; set; }

        public int SubscribesCount { get; set; }
    }
}
