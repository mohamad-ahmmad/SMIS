using BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LoggerTest
{

  
    [TestClass]
    public class InventoryTest
    {
        void SetUpInventory()
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
        }
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
            SetUpInventory();

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
            SetUpInventory();


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
            SetUpInventory();


            Product expected = null;

            var actual = Inventory.Search(new Product()
            {
                Name = "Homoss",
                Price = 0.0M,
                Quantity = 0
            });
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void SearchUsingPriceStrategyTest()
        {
            SetUpInventory();

            var actual = Inventory.Search(new Product() 
            {
                Name = "",
                Price = 14.56M,
                Quantity = 0
            },
            new PriceCompareStrategy()
            );
            List<Product> actualList= actual.ToList();

            var expected = new List<Product>()
            {
            new Product() {
                Name = "Chips",
                Price = 14.56M,
                Quantity = 3
            },
            new Product() {
                Name = "Homos",
                Price = 14.56M,
                Quantity = 4
            }
            };

            for(int i =0; i < actualList.Count ; i++) 
            {
                Assert.IsTrue(actualList[i].Equals(expected[i]));
            }

        }

    }
}
