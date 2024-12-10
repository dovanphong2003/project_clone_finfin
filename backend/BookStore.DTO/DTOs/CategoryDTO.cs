using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO.DTOs
{
    public class CategoryDTO
    {
        public long category_id { get; set; }
        public string name { get; set; }
        public long? parent_id { get; set; }
        public bool is_active { get; set; }
    }
}
