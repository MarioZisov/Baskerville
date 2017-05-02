namespace Baskerville.Models.DataModels
{
    using Constants;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(
            maximumLength: AdminMessages.MaxProductNameLegnth,
            MinimumLength = AdminMessages.MinProductNameLegnth)]
        public string NameBg { get; set; }

        [Required]
        [StringLength(
            maximumLength: AdminMessages.MaxProductNameLegnth,
            MinimumLength = AdminMessages.MinProductNameLegnth)]
        public string NameEn { get; set; }

        public string DescriptionBg { get; set; }

        public string DescriptionEn { get; set; }

        public double Price { get; set; }

        public bool IsAvalible { get; set; }

        public bool IsRemoved { get; set; }

        public int? CategoryId { get; set; }

        public ProductCategory Category { get; set; }

        public bool IsPublic { get; set; }
    }
}
