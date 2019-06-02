using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
    public class AddShopImgCommandHandler : IRequestHandler<AddShopImgCommand, int>
    {
      private IShopRepository _repository;

      public AddShopImgCommandHandler ( IShopRepository repository )
      {
        _repository = repository;
      }

      public Task<int> Handle(AddShopImgCommand request, CancellationToken cancellationToken)
      {
        return Task.FromResult(_repository.CreateShopImg(request.ShopId, request.Img));
      }
    }
}