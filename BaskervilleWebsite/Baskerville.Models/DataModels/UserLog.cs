namespace Baskerville.Models.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserLog
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
