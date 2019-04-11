using System;

namespace GB_Project.Services.IdentityService.IdentityAPI.ViewModels
{
    public class SignInViewModel
    {
      public TokenViewModel Token { get; set; }

      public Guid PkId { get; set; }

      public SignInViewModel(TokenViewModel token, Guid pkId)
      {
        Token = token;
        PkId = pkId;
      }
    }
}