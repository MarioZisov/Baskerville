namespace Baskerville.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.DataModels;
    using Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BaskervilleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BaskervilleContext context)
        {
            this.AddRoles(context);

            this.AddCategoriesWithSubcategories(context);
        }

        private void AddRoles(BaskervilleContext context)
        {
            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                roleManager.Create(new IdentityRole("Admin"));
                roleManager.Create(new IdentityRole("Owner"));
                roleManager.Create(new IdentityRole("Manager"));
                roleManager.Create(new IdentityRole("Employee"));

                context.SaveChanges();
            }
        }

        private void AddCategoriesWithSubcategories(BaskervilleContext context)
        {
            if (!context.ProductsCategories.Any())
            {
                #region Hot Drinks
                ProductCategory hotDrinks = new ProductCategory
                {
                    IsPrimary = true,
                    NameBg = "Топли Напитки",
                    NameEn = "Hot Drinks",
                };

                context.ProductsCategories.Add(hotDrinks);
                #endregion

                #region Soft Drinks                                
                ProductCategory softDrinks = new ProductCategory
                {
                    IsPrimary = true,
                    NameBg = "Безалкохолни Напитки",
                    NameEn = "Soft Drinks",
                    Subcategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Безалкохолни",
                            NameEn = "Non-Alcoholic"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Енергийни Напитки",
                            NameEn = "Energy Drinks"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Шейкове",
                            NameEn = "Shakes"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Ледени Напитки",
                            NameEn = "Ice Drinks"
                        },
                    }
                };

                context.ProductsCategories.Add(softDrinks);
                #endregion

                #region Beers                
                ProductCategory beers = new ProductCategory
                {
                    IsPrimary = true,
                    NameBg = "Бири",
                    NameEn = "Beers",
                };

                context.ProductsCategories.Add(beers);
                #endregion

                #region Cocktails                
                ProductCategory cocktails = new ProductCategory
                {
                    IsPrimary = true,
                    NameBg = "Коктейли",
                    NameEn = "Cocktails",
                    Subcategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Безалкохолни Коктейли",
                            NameEn = "Non-Alcoholic Cocktails"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Бейлис Коктейли",
                            NameEn = "Baileys Cocktails"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Водка Коктейли",
                            NameEn = "Vodka Cocktails"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Джин Коктейли",
                            NameEn = "Gin Cocktails"
                        },
                         new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Текила Коктейли",
                            NameEn = "Tequila Cocktails"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Ром Коктейли",
                            NameEn = "Rum Cocktails"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Уиски Коктейли",
                            NameEn = "Whiskey Cocktails"
                        },
                    }
                };

                context.ProductsCategories.Add(cocktails);
                #endregion

                #region Liqueurs & Shots
                ProductCategory liqueursAndShots = new ProductCategory
                {
                    IsPrimary = true,
                    NameBg = "Ликьори & Шотове",
                    NameEn = "Liqueurs & Shots",
                    Subcategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Шотове",
                            NameEn = "Shots"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Ликьори",
                            NameEn = "Liqueurs"
                        },                       
                    }
                };

                context.ProductsCategories.Add(liqueursAndShots);
                #endregion

                #region Wines & Champagne
                ProductCategory winesAndChampagne = new ProductCategory
                {
                    IsPrimary = true,
                    NameBg = "Вина & Шампанско",
                    NameEn = "Wines & Champagne",
                    Subcategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Бели Вина",
                            NameEn = "White Wines"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Червени Вина",
                            NameEn = "RedWines"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Шампанско",
                            NameEn = "Champagne"
                        },
                    }
                };

                context.ProductsCategories.Add(winesAndChampagne);
                #endregion

                #region Spirits
                ProductCategory spirits = new ProductCategory
                {
                    IsPrimary = true,
                    NameBg = "Спиртни Напитки",
                    NameEn = "Spirits",
                    Subcategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Ирландско Уиски",
                            NameEn = "Irish Whiskey"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Шотландско Уиски",
                            NameEn = "Scotch Whisky"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Бърбън",
                            NameEn = "Burboun"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Тенеси Уиски",
                            NameEn = "Tennessee Whiskey"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Отлежало Уиски",
                            NameEn = "Aged Whiskey"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Водка",
                            NameEn = "Vodka"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Джин",
                            NameEn = "Gin"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Ром",
                            NameEn = "Rum"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Текила",
                            NameEn = "Tequila"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Бренди",
                            NameEn = "Brandy"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Вермут",
                            NameEn = "Vermouth"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Анасонови Напитки",
                            NameEn = "Anason Drinks"
                        },
                    }
                };

                context.ProductsCategories.Add(spirits);
                #endregion

                #region Food And Appetizers
                ProductCategory foodsAndAppetizers = new ProductCategory
                {
                    IsPrimary = true,
                    NameBg = "Храни & Мезета",
                    NameEn = "Foods & Appetizers",
                    Subcategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Тостове",
                            NameEn = "Tosts"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Мезета",
                            NameEn = "Appetizers"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Торти",
                            NameEn = "Cakes"
                        },
                         new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Ядки",
                            NameEn = "Nuts"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Добавки",
                            NameEn = "Add-Ons"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "Парти Хапки",
                            NameEn = "Party Food"
                        },
                    }
                };

                context.ProductsCategories.Add(foodsAndAppetizers);
                #endregion

                context.SaveChanges();
            }
        }
    }
}