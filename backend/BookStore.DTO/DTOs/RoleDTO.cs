using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO.DTOs
{
    public class RoleDTO
    {
        public long role_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
        public List<int> ArrIdPermission { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public bool isDeleted { get; set; }
    }
}
