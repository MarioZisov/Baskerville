namespace Baskerville.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.DataModels;
    using Models.Enums;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BaskervilleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(BaskervilleContext context)
        {
            //#region Add Roles
            //if (!context.Roles.Any(r => r.Name == "Admin"))
            //{
            //    var roleStore = new RoleStore<IdentityRole>(context);
            //    var roleManager = new RoleManager<IdentityRole>(roleStore);
            //    roleManager.Create(new IdentityRole("Admin"));
            //}

            //if (!context.Roles.Any(r => r.Name == "Owner"))
            //{
            //    var roleStore = new RoleStore<IdentityRole>(context);
            //    var roleManager = new RoleManager<IdentityRole>(roleStore);
            //    roleManager.Create(new IdentityRole("Owner"));
            //}

            //if (!context.Roles.Any(r => r.Name == "Manager"))
            //{
            //    var roleStore = new RoleStore<IdentityRole>(context);
            //    var roleManager = new RoleManager<IdentityRole>(roleStore);
            //    roleManager.Create(new IdentityRole("Manager"));
            //}

            //if (!context.Roles.Any(r => r.Name == "Employee"))
            //{
            //    var roleStore = new RoleStore<IdentityRole>(context);
            //    var roleManager = new RoleManager<IdentityRole>(roleStore);
            //    roleManager.Create(new IdentityRole("Employee"));
            //}
            //#endregion

            //#region Add Product Categories & Products
            //if (!context.ProductsCategories.Any())
            //{
            //    #region Add Categories
            //    var hotDrinks = new ProductCategory
            //    {
            //        IsRemoved = false,
            //        NameBg = "Топли Напитки",
            //        NameEn = "Hot Drinks"
            //    };

            //    var spiritDrinks = new ProductCategory
            //    {
            //        IsRemoved = false,
            //        NameBg = "Спиртни Напитки",
            //        NameEn = "Spirit Drinks"
            //    };

            //    var cocktails = new ProductCategory
            //    {
            //        IsRemoved = false,
            //        NameBg = "Коктейли",
            //        NameEn = "Cocktails"
            //    };

            //    context.ProductsCategories.Add(hotDrinks);
            //    context.ProductsCategories.Add(spiritDrinks);
            //    context.ProductsCategories.Add(cocktails);
            //    #endregion

            //    #region Add Subcategories
            //    ProductCategory vodka = new ProductCategory
            //    {
            //        IsPrimary = false,
            //        IsRemoved = false,
            //        NameBg = "Водка",
            //        NameEn = "Vodka"
            //    };

            //    ProductCategory whiskey = new ProductCategory
            //    {
            //        IsPrimary = false,
            //        IsRemoved = false,
            //        NameBg = "Уиски",
            //        NameEn = "Whiskey"
            //    };

            //    spiritDrinks.Subcategories.Add(vodka);
            //    spiritDrinks.Subcategories.Add(whiskey);
            //    #endregion

            //    if (!context.Products.Any())
            //    {
            //        #region Add Spirit Drinks
            //        var wiskey1 = new Product
            //        {
            //            IsPublic = true,
            //            IsRemoved = false,
            //            NameBg = "Джеймсън",
            //            NameEn = "Jameson",
            //            Price = 4.9,
            //            IsAvalible = true,
            //            DescriptionBg = "Много добро уиски.",
            //            DescriptionEn = "Worst wiskey ever.",
            //            Quantity = 50
            //        };

            //        var wiskey2 = new Product
            //        {
            //            IsPublic = true,
            //            IsRemoved = false,
            //            NameBg = "Джим Бийм",
            //            NameEn = "Jim Beam",
            //            Price = 5.6,
            //            IsAvalible = true,
            //            DescriptionBg = "Много добро уиски.",
            //            DescriptionEn = "Worst wiskey ever.",
            //            Quantity = 50
            //        };

            //        var vodka1 = new Product
            //        {
            //            IsPublic = true,
            //            IsRemoved = false,
            //            NameBg = "Грей Гус",
            //            NameEn = "Grey Goose",
            //            Price = 8.9,
            //            IsAvalible = true,
            //            DescriptionBg = "Много добро уиски.",
            //            DescriptionEn = "Worst wiskey ever.",
            //            Quantity = 50
            //        };

            //        var vodka2 = new Product
            //        {
            //            IsPublic = true,
            //            IsRemoved = false,
            //            NameBg = "Финландия",
            //            NameEn = "Findladia",
            //            Price = 4.3,
            //            IsAvalible = true,
            //            DescriptionBg = "Много добро уиски.",
            //            DescriptionEn = "Worst wiskey ever.",
            //            Quantity = 50
            //        };

            //        whiskey.Products.Add(wiskey1);
            //        whiskey.Products.Add(wiskey2);
            //        vodka.Products.Add(vodka1);
            //        vodka.Products.Add(vodka2);
            //        #endregion

            //        #region Add Hot Drinks
            //        var hotDrink1 = new Product
            //        {
            //            IsPublic = true,
            //            IsRemoved = false,
            //            NameBg = "Кафе",
            //            NameEn = "Coffee",
            //            Price = 2.9,
            //            IsAvalible = true,
            //            DescriptionBg = "Много горещо и много вкусно.",
            //            DescriptionEn = "Very hot and delicious.",
            //            Quantity = 40
            //        };

            //        var hotDrink2 = new Product
            //        {
            //            IsPublic = true,
            //            IsRemoved = false,
            //            NameBg = "Капучино",
            //            NameEn = "Cappuccino",
            //            Price = 3.9,
            //            IsAvalible = true,
            //            DescriptionBg = "Много горещо и много вкусно.",
            //            DescriptionEn = "Very hot and delicious.",
            //            Quantity = 100
            //        };

            //        var hotDrink3 = new Product
            //        {
            //            IsPublic = true,
            //            IsRemoved = false,
            //            NameBg = "Топло Мляко",
            //            NameEn = "Hot Milk",
            //            Price = 2.9,
            //            IsAvalible = true,
            //            DescriptionBg = "Много горещо и много вкусно.",
            //            DescriptionEn = "Very hot and delicious.",
            //            Quantity = 150
            //        };

            //        var hotDrink4 = new Product
            //        {
            //            IsPublic = true,
            //            IsRemoved = false,
            //            NameBg = "Горещ Шоколод",
            //            NameEn = "Hot Chocolate",
            //            Price = 3.9,
            //            IsAvalible = true,
            //            DescriptionBg = "Много горещо и много вкусно.",
            //            DescriptionEn = "Very hot and delicious.",
            //            Quantity = 150
            //        };

            //        hotDrinks.Products.Add(hotDrink1);
            //        hotDrinks.Products.Add(hotDrink2);
            //        hotDrinks.Products.Add(hotDrink3);
            //        hotDrinks.Products.Add(hotDrink4);
            //        #endregion

            //        #region Add Cocktails
            //        var cocktail1 = new Product
            //        {
            //            IsPublic = true,
            //            IsRemoved = false,
            //            NameBg = "Маргарита",
            //            NameEn = "Margarita",
            //            Price = 6.9,
            //            IsAvalible = true,
            //            DescriptionBg = "Най-добрият коктейл в града!",
            //            DescriptionEn = "The best cocktail in town!",
            //            Quantity = 150
            //        };

            //        var cocktail2 = new Product
            //        {
            //            IsPublic = true,
            //            IsRemoved = false,
            //            NameBg = "Блъди Мери",
            //            NameEn = "Bloody Merry",
            //            Price = 5.9,
            //            IsAvalible = true,
            //            DescriptionBg = "Най-добрият коктейл в града!",
            //            DescriptionEn = "The best cocktail in town!",
            //            Quantity = 150
            //        };

            //        var cocktail3 = new Product
            //        {
            //            IsPublic = true,
            //            IsRemoved = false,
            //            NameBg = "Бял Руснак",
            //            NameEn = "White Russian",
            //            Price = 3.9,
            //            IsAvalible = true,
            //            DescriptionBg = "Най-добрият коктейл в града!",
            //            DescriptionEn = "The best cocktail in town!",
            //            Quantity = 150
            //        };

            //        var cocktail4 = new Product
            //        {
            //            IsPublic = true,
            //            IsRemoved = false,
            //            NameBg = "Черен Руснак",
            //            NameEn = "Black Russian",
            //            Price = 3.9,
            //            IsAvalible = true,
            //            DescriptionBg = "Най-добрият коктейл в града!",
            //            DescriptionEn = "The best cocktail in town!",
            //            Quantity = 150
            //        };

            //        cocktails.Products.Add(cocktail1);
            //        cocktails.Products.Add(cocktail2);
            //        cocktails.Products.Add(cocktail3);
            //        cocktails.Products.Add(cocktail4);
            //        #endregion 
            //    }
            //}
            //#endregion

            //#region Add Events
            //if (!context.Events.Any())
            //{
            //    var event1 = new Event
            //    {
            //        IsRemoved = false,
            //        IsPublic = true,
            //        StartDate = new DateTime(2017, 04, 01, 22, 00, 00),
            //        NameBg = "Пурвоаприлско Парти",
            //        NameEn = "April fools party",
            //        DescriptionEn = "It is still important to remember that web development is generally split up into client side coding, covering aspects such as the layout and design.",
            //        DescriptionBg = "тон все пак е важно да се помни, че уеб програмиране обикновено се разделя на клиентска страна кодиране, която обхваща аспекти, като например оформлението и дизайна, както и от страна на сървъра кодиране",
            //        ImageUrl = "http://stern-ticketing-event.sternwebagency.com/wp-content/uploads/2015/10/cocktail-partyd.jpg"
            //    };

            //    var event2 = new Event
            //    {
            //        IsRemoved = false,
            //        IsPublic = true,
            //        StartDate = new DateTime(2017, 04, 01, 22, 00, 00),
            //        NameBg = "Великденско Парти",
            //        NameEn = "Easter Party",
            //        DescriptionEn = "It is still important to remember that web development is generally split up into client side coding, covering aspects such as the layout and design.",
            //        DescriptionBg = "тон все пак е важно да се помни, че уеб програмиране обикновено се разделя на клиентска страна кодиране, която обхваща аспекти, като например оформлението и дизайна, както и от страна на сървъра кодиране",
            //        ImageUrl = "http://wallpaper-gallery.net/images/party-images/party-images-17.jpg"
            //    };

            //    context.Events.Add(event1);
            //    context.Events.Add(event2);
            //}
            //#endregion

            //#region Add Promotions
            //if (!context.Promotions.Any())
            //{
            //    var promo1 = new Promotion
            //    {
            //        IsPublic = true,
            //        IsRemoved = false,
            //        NameEn = "Free vodka for breakfast.",
            //        NameBg = "Безплатна водка за закуска",
            //        DescriptionEn = "ASP.NET MVC gives you a powerful, patterns-based way to build dynamic websites that.",
            //        DescriptionBg = "ASP.NET MVC дава мощен, модели, базирани начин за изграждане на динамични уеб сайтове, които"
            //    };
            //    var promo2 = new Promotion
            //    {
            //        IsPublic = true,
            //        IsRemoved = false,
            //        NameEn = "5 Blowjobs on price of 10",
            //        NameBg = "5 Арабска Свирки на цената на 10",
            //        DescriptionEn = "ASP.NET MVC gives you a powerful, patterns-based way to build dynamic websites that.",
            //        DescriptionBg = "ASP.NET MVC дава мощен, модели, базирани начин за изграждане на динамични уеб сайтове, които"
            //    };

            //    var promo3 = new Promotion
            //    {
            //        IsPublic = true,
            //        IsRemoved = false,
            //        NameEn = "Two pcs of bread with hotdog",
            //        NameBg = "Две филии хляб с кремвирш",
            //        DescriptionEn = "ASP.NET MVC gives you a powerful, patterns-based way to build dynamic websites that.",
            //        DescriptionBg = "ASP.NET MVC дава мощен, модели, базирани начин за изграждане на динамични уеб сайтове, които"
            //    };

            //    var promo4 = new Promotion
            //    {
            //        IsPublic = true,
            //        IsRemoved = false,
            //        NameEn = "Eggs on eyes",
            //        NameBg = "Яйца на очи",
            //        DescriptionEn = "ASP.NET MVC gives you a powerful, patterns-based way to build dynamic websites that.",
            //        DescriptionBg = "ASP.NET MVC дава мощен, модели, базирани начин за изграждане на динамични уеб сайтове, които"
            //    };

            //    context.Promotions.Add(promo1);
            //    context.Promotions.Add(promo2);
            //    context.Promotions.Add(promo3);
            //    context.Promotions.Add(promo4);
            //}
            //#endregion

            //#region Add Subscribers
            //if (!context.Subscribers.Any())
            //{
            //    var subs1 = new Subscriber
            //    {
            //        Email = "subscirber1@sub.com",
            //        IsActive = true,
            //        IsRemoved = false,
            //        PreferedLanguage = Language.EN,
            //        SubscriptionDate = new DateTime(2016, 01, 01)
            //    };

            //    var subs2 = new Subscriber
            //    {
            //        Email = "subscirber2@sub.com",
            //        IsActive = true,
            //        IsRemoved = false,
            //        PreferedLanguage = Language.BG,
            //        SubscriptionDate = new DateTime(2017, 01, 01)
            //    };

            //    var subs3 = new Subscriber
            //    {
            //        Email = "subscirber3@sub.com",
            //        IsActive = true,
            //        IsRemoved = false,
            //        PreferedLanguage = Language.BG,
            //        SubscriptionDate = new DateTime(2016, 06, 06)
            //    };

            //    context.Subscribers.Add(subs1);
            //    context.Subscribers.Add(subs2);
            //    context.Subscribers.Add(subs3);
            //}
            //#endregion

            //context.SaveChanges();
        }
    }
}