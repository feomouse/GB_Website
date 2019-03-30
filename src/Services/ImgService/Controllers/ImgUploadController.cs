using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GB_Project.Services.ImgService.Repository;

namespace ImgService.Controllers
{
    [Route("v1/api/ImgUpload")]
    [ApiController]
    public class ImgUploadController : ControllerBase
    {
      private IImgRepository _repo;

      public ImgUploadController(IImgRepository repo)
      {
        _repo = repo;
      }

      [HttpPost]
      public ActionResult Upload()
      {
        if(Request.Form.Files.Count != 0)
        {
            var stream = Request.Form.Files[0].OpenReadStream();

            byte[] bytes = new byte[stream.Length]; 

            int readNum = stream.Read(bytes, 0, bytes.Length);

            string[] nameArr = Request.Form.Files[0].FileName.Split(".");
          
            string imgType = nameArr[1];

            string imgLoaction = _repo.SaveImgToServer(bytes, imgType);

            return Ok(imgLoaction);
        }

        else return BadRequest("No img");
      }
    }
}
