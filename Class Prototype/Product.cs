using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Prototype
{
    public class Product
    {
        /* Here we have assigned each of our variables and property accessors to our class.
         The get property accessor is used to return the following property values, and the
        set property accessor is used to assign new values.* */
        public string name { get; set; }
        public int quantity { get; set; }
        public decimal price_per_unit { get; set; }

        /* Override the ToString method. This method is overriden so that we may
         * return the values of the objects we create with the Product class.*/
        public override string ToString()
        {
            return name;
        }
    }
}
