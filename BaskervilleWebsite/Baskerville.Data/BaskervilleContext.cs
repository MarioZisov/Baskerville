namespace Baskerville.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.DataModels;
    using System.Data.Entity;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BaskervilleContext>(null);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>()
                .ToTable("Users");

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("Users");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles");

            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UserRoles");

            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaims");

            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserLogins");
        }
    }
}