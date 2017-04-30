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
                    NameBg = "����� �������",
                    NameEn = "Hot Drinks",
                };

                context.ProductsCategories.Add(hotDrinks);
                #endregion

                #region Soft Drinks                                
                ProductCategory softDrinks = new ProductCategory
                {
                    IsPrimary = true,
                    NameBg = "������������ �������",
                    NameEn = "Soft Drinks",
                    Subcategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "������������",
                            NameEn = "Non-Alcoholic"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "��������� �������",
                            NameEn = "Energy Drinks"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "�������",
                            NameEn = "Shakes"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "������ �������",
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
                    NameBg = "����",
                    NameEn = "Beers",
                };

                context.ProductsCategories.Add(beers);
                #endregion

                #region Cocktails                
                ProductCategory cocktails = new ProductCategory
                {
                    IsPrimary = true,
                    NameBg = "��������",
                    NameEn = "Cocktails",
                    Subcategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "������������ ��������",
                            NameEn = "Non-Alcoholic Cocktails"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "������ ��������",
                            NameEn = "Baileys Cocktails"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "����� ��������",
                            NameEn = "Vodka Cocktails"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "���� ��������",
                            NameEn = "Gin Cocktails"
                        },
                         new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "������ ��������",
                            NameEn = "Tequila Cocktails"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "��� ��������",
                            NameEn = "Rum Cocktails"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "����� ��������",
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
                    NameBg = "������� & ������",
                    NameEn = "Liqueurs & Shots",
                    Subcategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "������",
                            NameEn = "Shots"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "�������",
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
                    NameBg = "���� & ���������",
                    NameEn = "Wines & Champagne",
                    Subcategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "���� ����",
                            NameEn = "White Wines"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "������� ����",
                            NameEn = "RedWines"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "���������",
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
                    NameBg = "������� �������",
                    NameEn = "Spirits",
                    Subcategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "��������� �����",
                            NameEn = "Irish Whiskey"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "���������� �����",
                            NameEn = "Scotch Whisky"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "������",
                            NameEn = "Burboun"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "������ �����",
                            NameEn = "Tennessee Whiskey"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "�������� �����",
                            NameEn = "Aged Whiskey"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "�����",
                            NameEn = "Vodka"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "����",
                            NameEn = "Gin"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "���",
                            NameEn = "Rum"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "������",
                            NameEn = "Tequila"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "������",
                            NameEn = "Brandy"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "������",
                            NameEn = "Vermouth"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "��������� �������",
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
                    NameBg = "����� & ������",
                    NameEn = "Foods & Appetizers",
                    Subcategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "�������",
                            NameEn = "Tosts"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "������",
                            NameEn = "Appetizers"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "�����",
                            NameEn = "Cakes"
                        },
                         new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "����",
                            NameEn = "Nuts"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "�������",
                            NameEn = "Add-Ons"
                        },
                        new ProductCategory
                        {
                            IsPrimary = false,
                            NameBg = "����� �����",
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