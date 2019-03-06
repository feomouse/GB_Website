/* using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
    public class AddGBRuleCommandHandler : IRequestHandler<AddGBRuleCommand, int>
    {
      private IShopRepository _repository;

      public AddGBRuleCommandHandler ( IShopRepository repository )
      {
        _repository = repository;
      }

      public async Task<int> Handle(AddGBRuleCommand request, CancellationToken cancellationToken)
      {
        GBRule gbRule = new GBRule(request.GBProductId, request.Content);

        _repository.AddGBRule(gbRule);      
              
        return await _repository.Save();
      }
    }
} */