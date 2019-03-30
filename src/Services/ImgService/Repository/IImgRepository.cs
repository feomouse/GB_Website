namespace GB_Project.Services.ImgService.Repository
{
  public interface IImgRepository
  {
      string SaveImgToServer(byte[] imgData, string imgType);
  }
}