using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
    public class Book
    {
        public long book_id { get; set; }          
        public string title { get; set; }   
        public string imageUrl { get; set; }
        public long price { get; set; }
        public long author_id { get; set; } 
        public long publisher_id { get; set; }
        public long category_id { get; set; }
        public int stock_quantity { get; set; }
        public string? content_data { get; set; }  
        public bool status { get; set; }
        public DateTime ReceiveDate { get; set; }
        public DateTime? updatedAt { get; set; }
        public bool isDeleted { get; set; } = false;
        public long createdBy { get; set; }
        public long? updatedBy { get; set; }
        public long? deleteBy { get; set; }

    }
}
