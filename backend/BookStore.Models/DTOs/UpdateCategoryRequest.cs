using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.Entities;

namespace BookStore.DTO.DTOs
{
    public class UpdateCategoryRequest
    {
        public long id { get; set; } // Dữ liệu thực tế của đối tượng cần cập nhật
        public Dictionary<string, string> FieldsToUpdate { get; set; } // Danh sách các trường cần cập nhật
    }

}
