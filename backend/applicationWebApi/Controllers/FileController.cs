using BookStore.DAL.Modal;
using BookStore.DTO.DTOs;
using BookStore.Shared.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        // Đảm bảo rằng thư mục trên ổ E đã tồn tại
        private readonly string _storagePath = @"E:\DO_AN_HOC_PHAN_2";

        public FileController()
        {
            // Tạo thư mục nếu chưa có
            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }
        }

        [HttpPost("upload_image")]
        public async Task<IActionResult> UploadFileImage([FromForm] FileUpload fileUpload)
        {
            return Ok("https://cebcu.com/wp-content/uploads/2024/01/anh-gai-xinh-cute-de-thuong-het-ca-nuoc-cham-27.webp");
            //try
            //{
            //    // Kiểm tra xem file có null không
            //    if (fileUpload.file == null || fileUpload.file.Length == 0)
            //    {
            //        return BadRequest("No file uploaded.");
            //    }

            //    // Tạo tên file mới để tránh trùng lặp
            //    var fileName = Path.GetFileName(fileUpload.file.FileName);
            //    var filePath = Path.Combine(_storagePath, fileName);

            //    // Lưu file vào ổ E
            //    using (var fileStream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await fileUpload.file.CopyToAsync(fileStream);
            //        fileStream.Flush();
            //        return Ok(filePath);
            //    }

            //    // Trả về đường dẫn của file đã upload

            //}
            //catch (Exception ex)
            //{
            //    // Xử lý lỗi nếu có
            //    return BadRequest(ex);
            //}
        }
    }
}
