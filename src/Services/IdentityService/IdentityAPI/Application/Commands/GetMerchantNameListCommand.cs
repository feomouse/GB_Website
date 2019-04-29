using System;

namespace GB_Project.Services.IdentityService.IdentityAPI.Application.Commands
{
  public class GetMerchantNameListCommand
  {
    public string Id { get; set; }

    public GetMerchantNameListCommand(string id)
    {
      Id = id;
    }
  }
}