namespace GB_project.Services.MerchantService.MerchantDomin.SeedWork
{
    public abstract class Enumeration
    {
      public int Id { get; private set; }

      public string Name { get; private set; }

      public Enumeration ()
      {

      }

      public Enumeration (int id, string name)
      {
        Id = id;
        Name = name;
      }

    }
}