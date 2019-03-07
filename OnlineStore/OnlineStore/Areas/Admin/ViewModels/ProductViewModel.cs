using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Data.Entities;

namespace OnlineStore.Areas.Admin.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }

        //public List<string> Categories { get; set; }
        
        public List<string> Images { get; set; }
    }
}
