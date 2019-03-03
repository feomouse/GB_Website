namespace GB_Project.Services.IdentityService.IdentityAPI.ViewModels
{
    public class SignInViewModel
    {
      public string Email { get; set; }

      public string PassWord { get; set; }

      
      public SignInViewModel(string email, string passWord)
      {
        Email = email;
        PassWord = passWord; 
      }
    }
}