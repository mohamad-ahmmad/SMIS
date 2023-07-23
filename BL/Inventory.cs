using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class Inventory
    {
        static Dictionary<string, Product> products = new Dictionary<string, Product>();

        /// <summary>
        /// Add product to the inventory
        /// </summary>
        /// <param name="product"></param>
        /// <returns>false or true, false if the product exists in the inventory</returns>
        public static bool AddProduct(Product product)
        {
            Product res = Search(product);
            if (res != null)
                return false;

            products.Add(product.Name, product);
            return true;
        }
        public static List<Product> GetAllProducts()
        {
            return products.Values.ToList();
        }
        public static Product Search (Product product)
        {
            throw new NotImplementedException();
        }

    }
}
