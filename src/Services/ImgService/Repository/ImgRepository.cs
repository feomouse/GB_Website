using System;
using System.IO;

namespace GB_Project.Services.ImgService.Repository
{
  public class ImgRepository : IImgRepository
  {
      public string SaveImgToServer(byte[] imgData, string imgType)
      {
        string fileName = Guid.NewGuid().ToString("N") + "." + imgType;
        string imgFileLocation = "D:\\nginx-1.12.2\\nginx-1.12.2\\IMGS\\" + fileName;
        File.WriteAllBytes(imgFileLocation, imgData);
        return "http://localhost:50020/" + fileName;
      }
  }
}