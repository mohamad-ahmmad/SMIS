using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;


namespace DA
{
    public class SqlProductRepository : IProductRepository
    {
        private string _connectionString;
        public SqlProductRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }
        private SqlConnection CreateConnection()
        {
            SqlConnection con = new SqlConnection(this._connectionString);
            con.Open();
            return con;
        }

        private SqlDataReader ExecuteSql(string sql)
        {
            SqlConnection sc = CreateConnection();

            SqlCommand cmd = sc.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataReader reader = cmd.ExecuteReader();
            

            return reader;

        }
        public void AddProduct(Product product)
        {

            ExecuteSql($"INSERT INTO Products (Name, Price, Quantity) " +
                                $"Values ('{product.Name}', {product.Price}, {product.Quantity})");
        }




        public void ClearAllProducts()
        {
            ExecuteSql("DELETE FROM Products");
        }

        public void DeleteProduct(string productName)
        {
            ExecuteSql($"DELETE FROM Products WHERE LOWER(Name) = '{productName}'");
        }

        public void EditProduct(string productName, Product newProduct)
        {
            ExecuteSql($"UPDATE Products " +
                        $"SET Name = '{newProduct.Name}', Price = {newProduct.Price}, Quantity = {newProduct.Quantity} " +
                        $"WHERE LOWER(Name) = '{newProduct.Name.ToLower()}'");
        }

        public Product? Search(string name)
        {
            SqlDataReader reader= ExecuteSql($"SELECT Name, Price, Quantity " +
                        $"FROM Products " +
                        $"WHERE LOWER(Name) = '{name}'");
            
            Product? prod = MapToProduct(reader).FirstOrDefault();

            reader.Close();
            return prod;
        }

        public IEnumerable<Product> MapToProduct(SqlDataReader reader)
        {
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Name = reader.GetString("Name"),
                    Price = reader.GetDecimal("Price"),
                    Quantity = reader.GetInt32("Quantity"),
                });
            }
            return products;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            SqlDataReader reader = ExecuteSql($"SELECT Name, Price, Quantity " +
            $"FROM Products");
            
            return MapToProduct(reader);
        }
    }
}
