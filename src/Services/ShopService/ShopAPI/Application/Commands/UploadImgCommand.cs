using MediatR;

namespace GB_Project.Services.ShopService.ShopAPI.Application.Commands
{
  public class UploadImgCommand : IRequest<string>
  {
    public string MerchantId {get; set;}

    public string ImgName {get; set;}

    public byte[] ImgData {get; set;}

    public UploadImgCommand(string merchantId, string imgName, byte[] imgData)
    {
      MerchantId = merchantId;
      ImgName = imgName;
      ImgData = imgData;
    } 
  }  
}