using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PriceCompareStrategy : ICompareStrategy
    {
        public bool Compare(Product p1, Product p2)
        {
            //Guards statements
            if(p1 == null && p2 == null) return true;
            if (p1 == null || p2 == null) return false;

            return p1.Price == p2.Price;
        }
    }
}
