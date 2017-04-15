namespace Baskerville.Models.ViewModels.Public
{
    using Constants;
    using System.ComponentModel.DataAnnotations;

    public class ContactBindingModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: PublicMessages.MaxMessageLength, MinimumLength = PublicMessages.MinMessageLength)]
        public string Message { get; set; }

        [Required]
        [StringLength(maximumLength: PublicMessages.MaxNameLength, MinimumLength = PublicMessages.MinNameLength)]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Subject { get; set; }
    }
}
