using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductInventory { get; set; }
        public DateTime ProductExpiration { get; set; }
        public DateTime ProductRegistered { get; set; }

    }
}
