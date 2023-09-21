namespace DA
{
    public interface IProductRepository
    {
        void EditProduct(string productName, Product newProduct);
        void DeleteProduct(string productName);
        Product? Search(string name);
        void AddProduct(Product product);
        void ClearAllProducts();
        IEnumerable<Product> GetAllProducts();
    }
}
