using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Plateform_RH_Finlogik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
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

}

}
