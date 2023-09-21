using System.Collections.Generic;
using System.Linq;


namespace BL
{
    public class InventoryService
    {
        public InventoryService(IProductRepository productRepository)
        {

        }

        public static void ClearAllProducts()
        {
            products.Clear();
        }

        /// <summary>
        /// Add product to the inventory
        /// </summary>
        /// <param name="product"></param>
        /// <returns>false or true, false if the product exists in the inventory</returns>
        public static bool AddProduct(Product product)
        {
            Product res = Search(product.Name);
            if (res != null)
                return false;

            products.Add(product.Name, product);
            return true;
        }

        /// <summary>
        /// Return all the products in the inventory
        /// </summary>
        /// <returns>All the products</returns>
        public static List<Product> GetAllProducts()
        {
            return products.Values.ToList();
        }

        /// <summary>
        /// Return the product object or null if not shown in the inventory.
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Product</returns>
        public static Product Search (string name)
        {
            return products.ContainsKey(name) ? products[name] : null;
        }

        public static IEnumerable<Product> Search(Product product, params ICompareStrategy[] strategies)
        {
            if(strategies == null || product == null)
                return Enumerable.Empty<Product>();

            var ans = new List<Product>();
            foreach(Product p in  products.Values)
            {
                bool found = true;
                foreach (var strategy in strategies)
                    found = found && strategy.Compare(p, product);

                if (found)
                    ans.Add(p);
            }
            return ans;
        }

        /// <summary>
        /// Give the values of newProduct to an existed product with productName
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="newProduct"></param>
        /// <returns>false or true, false if the item doesn't exists or the newProduct exists in the inventory</returns>
        public static bool EditProduct(string productName, Product newProduct)
        {
            if (newProduct.Name != productName && products.ContainsKey(newProduct.Name))
                return false;

            Product searchForProductWithProductName = Search(productName);
            if (searchForProductWithProductName == null)
                return false;

            products.Remove(productName);
            products.Add(newProduct.Name, newProduct);
            
            return true;
        }
        /// <summary>
        /// Remove a product with specified productName.
        /// </summary>
        /// <param name="productName"></param>
        /// <returns>false if the element doesn't show in the inventory, otherwise true.</returns>
        public static bool DeleteProduct(string productName)
        {
           return products.Remove(productName);
        }

    }
}
