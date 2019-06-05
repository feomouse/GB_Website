using System;
using System.Threading;
using System.Threading.Tasks;
using GB_Project.Services.MerchantService.MerchantAPI.Application.Commands;
using GB_Project.Services.MerchantService.MerchantAPI.Query;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using MediatR;

namespace GB_Project.Services.MerchantService.MerchantAPI.Application.CommandHandlers
{
  public class UnbindShopCommandHandler : IRequestHandler<UnbindShopCommand, int>
  {
    private IMerchantRepository _repo;

    private IMerchantQuery _query;

    public UnbindShopCommandHandler(IMerchantRepository repo, IMerchantQuery query)
    {
      _repo = repo;

      _query = query;
    }

    public Task<int> Handle (UnbindShopCommand command, CancellationToken cannellationToken)
    {
      return Task.FromResult(_repo.UnbindShopFromMerchant(command.MerchantId, command.ShopId));
    }
  }
}