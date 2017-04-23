using Baskerville.Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Models.ViewModels
{
    public class NewsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Публично")]
        public bool IsPublic { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [StringLength(maximumLength: AdminMessages.MaxTitleLength, MinimumLength = AdminMessages.MinTitleLength, ErrorMessage = AdminMessages.TitleLengthMessage)]
        [Display(Name = "Заглавие (бг)")]
        public string TitleBg { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [StringLength(maximumLength: AdminMessages.MaxNewsLength, MinimumLength = AdminMessages.MinNewsLength, ErrorMessage = AdminMessages.NewsLengthMessage)]
        [Display(Name = "Съобщение (бг)")]
        public string MessageBg { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [StringLength(maximumLength: AdminMessages.MaxFromLength, MinimumLength = AdminMessages.MinFromLength, ErrorMessage = AdminMessages.FromLengthMessage)]
        [Display(Name = "От (бг)")]
        public string FromBg { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [StringLength(maximumLength: AdminMessages.MaxTitleLength, MinimumLength = AdminMessages.MinTitleLength, ErrorMessage = AdminMessages.TitleLengthMessage)]
        [Display(Name = "Заглавие (анг)")]
        public string TitleEn { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [StringLength(maximumLength: AdminMessages.MaxNewsLength, MinimumLength = AdminMessages.MinNewsLength, ErrorMessage = AdminMessages.NewsLengthMessage)]
        [Display(Name = "Съобщение (анг)")]
        public string MessageEn { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [StringLength(maximumLength: AdminMessages.MaxFromLength, MinimumLength = AdminMessages.MinFromLength, ErrorMessage = AdminMessages.FromLengthMessage)]
        [Display(Name = "От (анг)")]
        public string FromEn { get; set; }
    }
}
