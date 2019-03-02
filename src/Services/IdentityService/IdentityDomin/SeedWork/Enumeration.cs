namespace GB_Project.Services.IdentityService.IdentityDomin.SeedWork
{
    public abstract class Enumeration
    {
      public int Id { get; private set; }

      public string Name { get;  private set; }

      public Enumeration ( int id, string name)
      {
        Id = id;
        Name = name;
      }
    }
}