using Baskerville.Models.Constants;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Models.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        [Required(ErrorMessage = AdminMessages.RequiredFieldMessage)]
        [Display(Name = "Роля")]
        public string RoleName { get; set; }

        public IEnumerable<DateTime> LastLogs { get; set; }

        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
