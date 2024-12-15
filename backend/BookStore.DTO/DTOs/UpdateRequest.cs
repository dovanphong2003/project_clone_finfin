using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO.DTOs
{
    public class UpdateRequest
    {
        public long id { get; set; } // get id need update
        public Dictionary<string, object> FieldsToUpdate { get; set; } // list field and value need update
    }

}
