using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApplication
{
    public class ProductDetails
    {


        public int ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"ProductDetails[ID={ID}, Name={Name}]";
        }

    }
}

