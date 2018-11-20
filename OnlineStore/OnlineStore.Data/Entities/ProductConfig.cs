using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Entities
{
    public class ProductConfig
    {
        public int ID { get; set; }
        public int SellerID { get; set; }
        public int ProductID { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Guaranty { get; set; }

        public Seller Seller { get; set; }
        public Product Product { get; set; }
    }
}
