using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data.Entities
{
    public class OrderItem
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public long Price { get; set; }
        public Order Order { get; set; }
    }
}
