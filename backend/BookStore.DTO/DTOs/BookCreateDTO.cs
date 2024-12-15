using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookStore.DTO.DTOs
{

    public class BookCreateDTO
    {
        public long book_id { get; set; }
        public string title { get; set; }

        // Đổi thành lớp con cho infoImage
        //public InfoImageDTO infoImage { get; set; }
        public string imageUrl { get; set; }
        public long price { get; set; }
        public long author_id { get; set; }
        public long publisher_id { get; set; }
        public long category_id { get; set; }
        public int stock_quantity { get; set; }
        public bool status { get; set; }
        public long createdBy { get; set; }
        public DateTime ReceiveDate { get; set; }
    }

    // Tạo lớp con InfoImageDTO để chứa fileName và base64Image
    public class InfoImageDTO
    {
        public string fileName { get; set; }
        public string base64Image { get; set; }
    }
}
