using Baskerville.Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Models.ViewModels
{
    public class MessageViewModel
    {
        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [StringLength(maximumLength: AdminMessages.MaxSubjectLegnth, MinimumLength = AdminMessages.MinSubjectLegnth, ErrorMessage = AdminMessages.SubjectLengthMessage)]
        [Display(Name = "Тема (БГ)")]
        public string SubjectBg { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [StringLength(maximumLength: AdminMessages.MaxContentLegnth, MinimumLength = AdminMessages.MinContentLegnth, ErrorMessage = AdminMessages.ContentLengthMessage)]
        [Display(Name = "Съобщение (БГ)")]
        public string ContentBg { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]        
        [StringLength(maximumLength: AdminMessages.MaxSubjectLegnth, MinimumLength = AdminMessages.MinSubjectLegnth, ErrorMessage = AdminMessages.SubjectLengthMessage)]
        [Display(Name = "Тема (АН)")]
        public string SubjectEn { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [StringLength(maximumLength: AdminMessages.MaxContentLegnth, MinimumLength = AdminMessages.MinContentLegnth, ErrorMessage = AdminMessages.ContentLengthMessage)]
        [Display(Name = "Съобщение (АН)")]
        public string ContentEn { get; set; }
    }
}
