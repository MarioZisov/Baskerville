namespace Baskerville.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.DataModels;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BaskervilleContext : IdentityDbContext<ApplicationUser>
    {
        public BaskervilleContext()
            : base("BaskervilleContext", throwIfV1Schema: false)
        {
        }

        public static BaskervilleContext Create()
        {
            return new BaskervilleContext();
        }
    }
}