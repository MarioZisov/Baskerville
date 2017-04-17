using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Models.ViewModels
{
    public class UserListViewModel
    {
        public string Id { get; set; }

        public string RoleName { get; set; }

        public string Username { get; set; }

        public DateTime LastLogDate { get; set; }
    }
}
