using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Modal
{
    public class AddOrder
    {
        public long order_id { get; set; }
        public bigint seller {get;set}
        public List<OrderItem> data { get; set; }
        public DateTime createdAt { get; set; }
        public int createdBy { get; set; }
    }

    public class OrderItem
    {
        public BookB book { get; set; }
        public int quantity { get; set; }
    }

    public class BookB
    {
        public long book_id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
    }

}
