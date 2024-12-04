using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.Entities;

namespace BookStore.DTO.DTOs
{
    public class UpdateRequest
    {
        public long id { get; set; } // get id need update
        public Dictionary<string, string> FieldsToUpdate { get; set; } // list field and value need update
    }

}
