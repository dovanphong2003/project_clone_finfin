using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
    public class Book
    {
        public long id { get; set; }          // Mã định danh của sách
        public string title { get; set; }   // Tên sách
        public string author { get; set; }  // Tác giả
        public string type { get; set; }  // thể loại của sách
    }
}
