using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
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


    }
}
