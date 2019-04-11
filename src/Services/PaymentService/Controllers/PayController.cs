using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Text;
using GB_Project.Services.PaymentService.Application.Commands;

namespace GB_Project.Services.PaymentService.Controllers
{
  [Route("/v1/api/pay")]
  public class PayController : ControllerBase
  {
    private IFileProvider _fileProvider;

    public PayController(IFileProvider fileProvider) 
    {
      _fileProvider = fileProvider;
    }

    [HttpPost]
    [Route("order")]
    public ActionResult GetPayment([FromHeader] string TotalCost) 
    {
      return Ok("Pay Success");
    }
  }
}