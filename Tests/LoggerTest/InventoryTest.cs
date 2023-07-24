using BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LoggerTest
{
    [TestClass]
    public class InventoryTest
    {
        [TestMethod]
        public void AddProductTest()
        {
           Inventory.ClearAllProducts();
           var acutal = Inventory.AddProduct(new Product()
            {
                Name = "Chips",
                Price = 14.56M,
                Quantity = 3
            });
            var expected = true;

            Assert.AreEqual(expected, acutal);
        }

        [TestMethod]
        public void AddAnExistedProductTest()
        {
            Inventory.ClearAllProducts();
            Inventory.AddProduct(new Product()
            {
                Name = "Homos",
                Price = 14.56M,
                Quantity = 3
            });
            var actual = Inventory.AddProduct(new Product()
            {
                Name = "Homos",
                Price = 14.56M,
                Quantity = 4
            });
            var expected = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAllProductTest()
        {
            Inventory.ClearAllProducts();
            Inventory.AddProduct(new Product()
            {
                Name = "Chips",
                Price = 14.56M,
                Quantity = 3
            });
            Inventory.AddProduct(new Product()
            {
                Name = "Homos",
                Price = 14.56M,
                Quantity = 4
            });

            var actual = Inventory.GetAllProducts();
            
            var expected = new List<Product>()
            {
              new Product()  
              {
                Name = "Chips",
                Price = 14.56M,
                Quantity = 3
              },
              new Product() 
              {
                Name = "Homos",
                Price = 14.56M,
                Quantity = 4
              }
            };
            for(int i =0; i <  actual.Count; i++)
            {
                Assert.IsTrue(actual[i].Equals(expected[i]));
            }

        }

        [TestMethod]
        public void SearchAnExistedProductTest()
        {
            Inventory.ClearAllProducts();
            Inventory.AddProduct(new Product()
            {
                Name = "Chips",
                Price = 14.56M,
                Quantity = 3
            });
            Inventory.AddProduct(new Product()
            {
                Name = "Homos",
                Price = 14.56M,
                Quantity = 4
            });


            var expected = new Product() 
            { 
                Name = "Homos",
                Price = 14.56M,
                Quantity = 4
            };

            var actual = Inventory.Search(new Product()
            {
                Name = "Homos",
                Price = 0.0M,
                Quantity = 0
            });
            Assert.IsTrue(actual.Equals(expected));
        }
        [TestMethod]
        public void SearchANonExistedProductTest()
        {
            Inventory.ClearAllProducts();
            Inventory.AddProduct(new Product()
            {
                Name = "Chips",
                Price = 14.56M,
                Quantity = 3
            });
            Inventory.AddProduct(new Product()
            {
                Name = "Homos",
                Price = 14.56M,
                Quantity = 4
            });


            Product expected = null;

            var actual = Inventory.Search(new Product()
            {
                Name = "Homoss",
                Price = 0.0M,
                Quantity = 0
            });
            Assert.AreEqual(actual, expected);
        }

    }
}
