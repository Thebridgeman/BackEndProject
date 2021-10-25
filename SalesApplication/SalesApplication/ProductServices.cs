using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApplication
{
    class ProductServices
    {
        private IList<ProductDetails> productDetails;
        private static int counter = 0;

        private readonly SalesRepository salesRepository;

        public ProductServices(SalesRepository salesRepository)
        {
            this.salesRepository = salesRepository;
        }

        internal ProductDetails Create(ProductDetails toCreate)
        {
            ProductDetails newProductDetails = salesRepository.Create(toCreate);
            return newProductDetails;
        }

        internal IEnumerable<ProductDetails> Read()
        {
            return salesRepository.Read();
        }
 
    }
}
