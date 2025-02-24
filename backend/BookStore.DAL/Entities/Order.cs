using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
    public class Order
    {
        public long order_id { get; set; }          
        public long? user_id { get; set; }
        public string status { get; set; }   
        public DateTime order_date { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public bool isDeleted { get; set; } = false;
        public long? cart_id { get; set; }
        public string? shippingAddress { get; set; }
        public string paymentMethod { get; set; }
        public long? seller { get; set; }

    }
}
