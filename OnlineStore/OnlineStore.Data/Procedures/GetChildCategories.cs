using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineStore.Data.Entities;

namespace OnlineStore.Data.Procedures
{
    public class GetChildCategories
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NameFa { get; set; }
        public int? CategoryParentID { get; set; }
        public int Kind { get; set; }
    }
}
