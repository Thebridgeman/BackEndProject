using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApplication
{
    class ReadFunctionServices
    {
       

        private readonly ReadRepository readRepository;

        public ReadFunctionServices(ReadRepository readRepository)
        {
            this.readRepository = readRepository;
        }

    }
}
