using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Entities
{
    public class ProductImage
    {
        public int ID { get; set; }
        public int ProductID { get; set; }

        [Required]
        public string ImageURL { get; set; }

        public Product Product { get; set; }

        [NotMapped]
        public string WebImageURL => this.ImageURL;
    }
}
