using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
    public class Publisher
    {
        public long publisher_id { get; set; }
        public string name { get; set; }
        public string? address { get; set; }

        public string? contact_number { get; set; }
        public string email { get; set; }
        public string? website { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public bool isDeleted { get; set; }
    }
}
