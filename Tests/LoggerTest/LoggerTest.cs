using BL;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LoggerTest
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void LogProductTest()
        {
            var product = new Product()
            {
                Name = "Chips",
                Price = 14.56M,
                Quantity = 3
            };

            var actual = product.Log();

            var expected = "Name : Chips, Price : 14.56, Quantity : 3";

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void LogListOfProductTest() 
        {
            var list = new List<Product>()
            {
            new Product()
            {
                Name = "Chips",
                Price = 14.56M,
                Quantity = 3
            },
            new Product()
            {
                Name = "Botato",
                Price = 13.56M,
                Quantity = 3
            }
        };

            var act = "";

            foreach(var item in list)
            {
                act +=$"{item.Log()}\n";
            }

            var expected = "Name : Chips, Price : 14.56, Quantity : 3\n" +
                            "Name : Botato, Price : 13.56, Quantity : 3\n";

            Assert.AreEqual(expected, act);
        }
    }
}
