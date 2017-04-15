using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Models.ViewModels.Public
{
    public class SubscribeBindingModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Prefered Language")]
        public string PreferedLanguage { get; set; }
    }
}
