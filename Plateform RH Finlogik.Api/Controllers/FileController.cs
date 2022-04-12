using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Net.Http.Headers;

namespace Plateform_RH_Finlogik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        public JsonResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Ressources", "images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);


                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return new JsonResult(dbPath);


            }
            catch (Exception ex)
            {
                return new JsonResult("");
            }
        }

    
    [HttpPost("uploadCV"), DisableRequestSizeLimit]
    public JsonResult UploadCvs()
    {
        try
        {
            var file = Request.Form.Files[0];
            var folderName = Path.Combine("Ressources", "CVs");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);


            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fullPath = Path.Combine(pathToSave, fileName);
            var dbPath = Path.Combine(folderName, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return new JsonResult(dbPath);


        }
        catch (Exception ex)
        {
            return new JsonResult("");
        }
    }
        [HttpGet("download"), DisableRequestSizeLimit]
        public async Task<IActionResult> Download([FromQuery] string fileUrl)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileUrl);
            if (!System.IO.File.Exists(filePath))
                return NotFound();
            var memory = new MemoryStream();
            await using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(filePath), filePath);
        }
            private string GetContentType(string path)
            {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;

            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
            }
        /*[HttpGet("getCVFiles"), DisableRequestSizeLimit]
        public IActionResult getCVFiles()
        {
            try
            {
                var folderName = Path.Combine("Resources", "CVs");
                var pathToRead = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var cvs = Directory.EnumerateFiles(pathToRead)
                    .Where(IsCVFile)
                    .Select(fullPath => Path.Combine(folderName, Path.GetFileName(fullPath)));

                return Ok(new { cvs });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        private bool IsCVFile(string fileName)
        {
            return fileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase)
                || fileName.EndsWith(".word", StringComparison.OrdinalIgnoreCase)
              
        }*/

    }

}
