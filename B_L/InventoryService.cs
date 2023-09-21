using DA;
namespace BL
{
    public class InventoryService
    {
        private IProductRepository _productRepository;
        public InventoryService(IProductRepository productRepository)
        {
            if(productRepository is null)
                throw new ArgumentNullException(nameof(productRepository));

            _productRepository = productRepository;
        }

        public void ClearAllProducts()
        {
            _productRepository.ClearAllProducts();
        }

        /// <summary>
        /// Add product to the inventory
        /// </summary>
        /// <param name="product"></param>
        /// <returns>false or true, false if the product exists in the inventory</returns>
        public bool AddProduct(Product product)
        {
            try
            {
                _productRepository.AddProduct(product);
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Return all the products in the inventory
        /// </summary>
        /// <returns>All the products</returns>
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts().ToList();
        }

        /// <summary>
        /// Return the product object or null if not shown in the inventory.
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Product</returns>
        public Product? Search (string name)
        {
            return _productRepository.Search(name);
        }


        /// <summary>
        /// Give the values of newProduct to an existed product with productName
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="newProduct"></param>
        /// <returns>false or true, false if the item doesn't exists or the newProduct exists in the inventory</returns>
        public Product? EditProduct(string productName, Product newProduct)
        {
            if(Search(productName) is null) 
            {
                return null;
            }

            _productRepository.EditProduct(productName, newProduct);
            return newProduct;
        }
        /// <summary>
        /// Remove a product with specified productName.
        /// </summary>
        /// <param name="productName"></param>
        /// <returns>false if the element doesn't show in the inventory, otherwise true.</returns>
        public Product? DeleteProduct(string productName)
        {
            Product? prod = Search(productName);
            if (prod is null)
            {
                return null;
            }

            _productRepository.DeleteProduct(productName);
            return prod;
        }

    }
}
