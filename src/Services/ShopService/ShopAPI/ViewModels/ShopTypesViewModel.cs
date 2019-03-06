namespace GB_Project.Services.ShopService.ShopAPI.ViewModels
{
  public class ShopTypesViewModel
  {
    public int Id { get; set; }

    public string Name { get ; set; }

    public ShopTypesViewModel(int id, string name)
    {
      Id = id;
      Name = name;
    }
  }
}