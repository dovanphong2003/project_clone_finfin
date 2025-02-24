using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO.DTOs
{
    public class BookSoldExtendedDTO
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

        // New field for seller information
        public SellerInfo? infoSeller { get; set; }
    }

    // Class representing seller information
    public class SellerInfo
    {
        public long user_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public long role_id { get; set; } // Role ID instead of role name
    }
}
