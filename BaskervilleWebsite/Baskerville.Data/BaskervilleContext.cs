namespace Baskerville.Data
{
    using Contracts.Repository;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.DataModels;
    using Repository;
    using System.Data.Entity;
    using System;

    public class BaskervilleContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public BaskervilleContext()
            : base("BaskervilleContext", throwIfV1Schema: false)
        {
        }

        public static BaskervilleContext Create()
        {
            return new BaskervilleContext();
        }

        public DbSet<Subscriber> Subscribers { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Promotion> Promotions { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductsCategories { get; set; }

        public DbSet<MeasurementUnit> MeasurenmentUnits { get; set; }

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

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public System.Data.Entity.DbSet<Baskerville.Models.ViewModels.ProductViewModel> ProductViewModels { get; set; }
    }
}