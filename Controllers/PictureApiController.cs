using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStartWebApi.Domain;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuickStartWebApi.Controllers
{
    [Route("api/photos")]
    public class PictureApiController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var models = "Welcome To Picture API";
            return Ok(models);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var models = "Welcome To Picture API";
            return Ok(models);
        }

        [HttpPost("upload-picture")]
        public async Task<IActionResult> Upload(int worksiteId, bool isBannerPicture, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest();

            Stream stream = file.OpenReadStream();
            var pictureName = Path.GetFileName(file.FileName);
            var contentType = file.ContentType;

            var fileBinary = new byte[stream.Length];
            stream.Read(fileBinary, 0, fileBinary.Length);

            var fileExtension = Path.GetExtension(file.FileName);
            if (!String.IsNullOrEmpty(fileExtension))
                fileExtension = fileExtension.ToLowerInvariant();

            if (String.IsNullOrEmpty(contentType))
            {
                switch (fileExtension)
                {
                    case ".bmp":
                        contentType = MimeTypes.ImageBmp;
                        break;
                    case ".gif":
                        contentType = MimeTypes.ImageGif;
                        break;
                    case ".jpeg":
                    case ".jpg":
                    case ".jpe":
                    case ".jfif":
                    case ".pjpeg":
                    case ".pjp":
                        contentType = MimeTypes.ImageJpeg;
                        break;
                    case ".png":
                        contentType = MimeTypes.ImagePng;
                        break;
                    case ".tiff":
                    case ".tif":
                        contentType = MimeTypes.ImageTiff;
                        break;
                    default:
                        break;
                }
            }


            return Ok(new
            {
                contentType,
                file.FileName,
                fileBinary 
            });
        }
    }
}
