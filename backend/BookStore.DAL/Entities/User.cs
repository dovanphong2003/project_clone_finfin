using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
    public class User
    {
        public long user_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public byte age {  get; set; }
        public string? gender { get; set; }
        public string? address { get; set; }
        public long role_id { get; set; }
        public string? refreshToken { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public bool isDeleted { get; set; }
        public long? createdBy { get; set; }
        public long? updatedBy { get; set; }
        public long? deleteBy { get; set; }
    }
}
