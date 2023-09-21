using Common;

namespace DA
{
    public class Product : ILoggable
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public string Log()
        {
            return $"Name : {Name}, Price : {Price}, Quantity : {Quantity}";
        }

        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Product p2 = (Product)obj;
                return this.Name == p2.Name && this.Price == p2.Price && this.Quantity == p2.Quantity;
            }
        }

    }
}
