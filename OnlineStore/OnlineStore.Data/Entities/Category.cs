using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Entities
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NameFa { get; set; }
        public Category CategoryParent { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
