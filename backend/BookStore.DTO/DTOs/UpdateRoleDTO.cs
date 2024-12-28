using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO.DTOs
{
    public class UpdateRoleDTO
    {
        public long id { get; set; } // get id need update
        public Dictionary<string, object> FieldsToUpdate { get; set; }
        public List<int> PermissionUpdate { get; set; }
        public List<int> PermissionDelete { get; set; }
    }
}
