using System;
using System.Threading;
using System.Threading.Tasks;
using GB_Project.Services.MerchantService.MerchantAPI.Application.Commands;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using MediatR;

namespace GB_Project.Services.MerchantService.MerchantAPI.Application.CommandHandlers
{
  public class AddShopCommandHandler : IRequestHandler<AddShopCommand, int>
  {
    private IMerchantRepository _repo;

    public AddShopCommandHandler(IMerchantRepository repo)
    {
      _repo = repo;
    }

    public Task<int> Handle (AddShopCommand command, CancellationToken cannellationToken)
    {
      return _repo.AddShopIdToMerchant(command.Basic, new Guid(command.ShopId));
    }
  }
}