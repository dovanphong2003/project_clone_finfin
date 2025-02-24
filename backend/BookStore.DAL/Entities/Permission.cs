using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
    public class Permission
    {
        public long permission_id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string method { get; set; }
        public string module { get; set; }
        public string? description { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public bool isDeleted { get; set; }
        public long createdBy { get; set; }
        public long? updatedBy { get; set; }
        public long? deleteBy {  get; set; } 
    }
}
