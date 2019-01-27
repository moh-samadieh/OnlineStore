using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NameFa { get; set; }
        public int BrandID { get; set; }

        public Brand Brand { get; set; }

        public ICollection<ProductConfig> ProductConfigs { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
