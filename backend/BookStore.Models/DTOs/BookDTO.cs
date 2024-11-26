using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTO.DTOs
{
    public class BookDTO
    {
        public long id { get; set; }          // Mã định danh của sách
        public string title { get; set; }   // Tên sách
        public string author { get; set; }  // Tác giả
    }
}
