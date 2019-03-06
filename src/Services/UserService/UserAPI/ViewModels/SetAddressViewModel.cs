namespace GB_Project.Services.UserService.UserAPI.ViewModels
{
  public class SetAddressViewModel
  {
    public string PkId { get; set; }

    public string Address { get; set; }

    public SetAddressViewModel(string pkId, string address)
    {
      PkId = pkId;
      Address = address;
    }
  }
}