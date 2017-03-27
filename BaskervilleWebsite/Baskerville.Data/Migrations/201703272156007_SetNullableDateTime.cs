namespace Baskerville.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNullableDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subscribers", "SubscriptionPendingDate", c => c.DateTime());
            AlterColumn("dbo.Subscribers", "SubscriptionDate", c => c.DateTime());
            AlterColumn("dbo.Subscribers", "UnsubscribeDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subscribers", "UnsubscribeDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Subscribers", "SubscriptionDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Subscribers", "SubscriptionPendingDate", c => c.DateTime(nullable: false));
        }
    }
}
