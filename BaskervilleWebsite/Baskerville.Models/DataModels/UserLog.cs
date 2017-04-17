﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Models.DataModels
{
    public class UserLog
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}