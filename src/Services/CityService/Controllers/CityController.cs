using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Text;

namespace CityService.Controllers
{
    [Route("v1/api/city")]
    [ApiController]
    public class CityController : ControllerBase
    {
      private IFileProvider _file;

      public CityController(IFileProvider fileProvider)
      {
          _file = fileProvider;
      }

      [HttpGet]
      [Route("Info")]
      public ActionResult GetCityData()
      {
          var fileInfo = _file.GetFileInfo("data.json");
      
          var stream = fileInfo.CreateReadStream();

          byte[] file = new byte[stream.Length];

          var readNum = stream.Read(file, 0, file.Length);

          var fileStr = Encoding.Default.GetString(file); 

          if(readNum == 0)
          {
              return BadRequest();
          }
          return Ok(fileStr);
      }
    }
}
