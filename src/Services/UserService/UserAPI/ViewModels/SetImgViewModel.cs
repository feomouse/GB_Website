namespace GB_Project.Services.UserService.UserAPI.ViewModels
{
  public class SetImgViewModel
  {
    public string PkId { get; set; }
    public string ImgLocation { get; set; }

    public SetImgViewModel(string pkId, string localtion)
    {
      PkId = pkId;
      ImgLocation = localtion;
    } 
  }
}