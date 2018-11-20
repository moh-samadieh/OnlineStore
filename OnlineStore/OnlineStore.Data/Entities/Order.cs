using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Data.Entities
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
