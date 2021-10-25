using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApplication
{
    public class ProductDetails
    {


        public long ID { get; set; }
        public string Name { get; set; }
        public int SaleQuantity { get; set; }
        public float IndividualItemPrice { get; set; }
        public DateTime datetime { get; set; }

        public override string ToString()
        {
            return $"ProductDetails[ID={this.ID}, Name={this.Name}]";
        }

    }
}

