using MongoDB.Bson;
using MongoDB.Driver;
 
namespace DA
{
    public class DocumentProductRepository : IProductRepository
    {
        private readonly IMongoCollection<BsonDocument> _productCollection;
        public DocumentProductRepository(string connectionString)
        {
            _productCollection = new MongoClient(connectionString).GetDatabase("sims").GetCollection<BsonDocument>("Products");
        }
        public void AddProduct(Product product)
        {
            var productBSONDocument = new BsonDocument
            {
                {"Name", product.Name },
                {"Price", product.Price },
                {"Quantity", product.Quantity }
            };
            _productCollection.InsertOne(productBSONDocument);
        }
        public IEnumerable<Product> GetAllProducts()
        {
         return   _productCollection.Find(Builders<BsonDocument>.Filter.Empty)
                .ToList()
                .Select(bson => new Product
                {
                    Name = bson.GetValue("Name").ToString()!,
                    Price = Decimal.Parse(bson.GetValue("Price").ToString()!),
                    Quantity = int.Parse(bson.GetValue("Quantity").ToString()!),
                });
        }
        public void ClearAllProducts()
        {
            _productCollection.DeleteMany(Builders<BsonDocument>.Filter.Empty);
        }

        public void DeleteProduct(string productName)
        {
            _productCollection.DeleteOne(Builders<BsonDocument>.Filter.Eq("Name", productName));
        }

        public void EditProduct(string productName, Product newProduct)
        {
            _productCollection.UpdateOne(
                Builders<BsonDocument>.Filter.Eq("Name", productName),
                Builders<BsonDocument>.Update.Set("Name", newProduct.Name)
                                            .Set("Price", (double)newProduct.Price)
                                            .Set("Quantity", newProduct.Quantity)
          );
        }

        public Product? Search(string name)
        {
             var product = _productCollection.Find(Builders<BsonDocument>.Filter.Eq("Name", name)).FirstOrDefault();
             if(product is null)
                return null;

            return new Product
            {
                Name = product.GetValue("Name").ToString(),
                Price = Decimal.Parse(product.GetValue("Price").ToString()!),
                Quantity =int.Parse(product.GetValue("Quantity").ToString()!),
            };
            
        }
    }
}
