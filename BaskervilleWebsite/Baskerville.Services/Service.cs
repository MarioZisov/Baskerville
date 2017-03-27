using Baskerville.Data.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Services
{
    public abstract class Service
    {
        private IDbContext context;

        public Service(IDbContext context)
        {
            this.context = context;
        }

        protected IDbContext Context
            => this.context;
    }
}
