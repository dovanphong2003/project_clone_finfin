using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
   public class Author
    {
       
            public long author_id { get; set; }          
            public string name { get; set; }   
            public string? bio { get; set; }  
            public DateTime createdAt { get; set; }
            public DateTime? updatedAt { get; set; }
            public bool isDeleted { get; set; }
    }
}
