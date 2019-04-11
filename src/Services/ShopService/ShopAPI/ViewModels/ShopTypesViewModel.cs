namespace GB_Project.Services.ShopService.ShopAPI.ViewModels
{
  public class ShopTypesViewModel
  {
    public int Id { get; set; }

    public string Name { get ; set; }

    public string Img { get; set; }

    public ShopTypesViewModel(int id, string name, string img)
    {
      Id = id;
      Name = name;
      Img = img;
    }
  }
}