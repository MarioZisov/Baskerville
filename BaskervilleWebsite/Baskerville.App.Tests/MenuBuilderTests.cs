using Baskerville.Data.Contracts.Repository;
using Baskerville.Models.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.App.Tests
{
    [TestClass()]
    public class MenuBuilderTests
    {
        public ICollection<ProductCategory> primaryCategories;
        public IRepository<ProductCategory> 

        [ClassInitialize()]
        public void InitializeCategories()
        {
            this.primaryCategories = 
        }
    }
}
