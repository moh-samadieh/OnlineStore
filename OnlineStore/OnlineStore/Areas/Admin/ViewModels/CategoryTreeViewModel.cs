using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Data.Entities;

namespace OnlineStore.Areas.Admin.ViewModels
{
    public class CategoryTreeViewModel
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public bool Checked{ get; set; }

        public List<CategoryTreeViewModel> Children;
    }
}
