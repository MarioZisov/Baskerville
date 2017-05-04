namespace Baskerville.Services
{
    using Data.Contracts.Repository;
    using Data.Repository;

    public abstract class Service
    {
        public Service(IDbContext context)
        {
            this.Events = new EventRepositroy(context);
            this.Categoires = new CategoryRepositroy(context);
            this.News = new NewsRepositroy(context);
            this.Products = new ProductRepositroy(context);
            this.Promotions = new PromotionRepositroy(context);
            this.Roles = new RoleRepositroy(context);
            this.Statistics = new StatisticsRepositroy(context);
            this.Subscribers = new SubscriberRepository(context);
            this.UserLogs = new UserLogRepositroy(context);
            this.Users = new UserRepositroy(context);
        }

        public EventRepositroy Events { get; }

        public CategoryRepositroy Categoires { get; }

        public NewsRepositroy News { get; }

        public ProductRepositroy Products { get; }

        public PromotionRepositroy Promotions { get; }

        public RoleRepositroy Roles { get; }

        public StatisticsRepositroy Statistics { get; }

        public SubscriberRepository Subscribers { get; }

        public UserLogRepositroy UserLogs { get; }

        public UserRepositroy Users { get; }
    }
}
