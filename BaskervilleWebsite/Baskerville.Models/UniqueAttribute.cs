using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Models
{
    public class UniqueAttribute : ValidationAttribute
    {
        public UniqueAttribute()
        {
        }

        public UniqueAttribute(Func<string> errorMessageAccessor)
            : base(errorMessageAccessor)
        {
        }

        public UniqueAttribute(string errorMessage)
            : base(errorMessage)
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var context = new BaskervilleContext();

            return base.IsValid(value, validationContext);
        }
    }
}
