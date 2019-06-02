using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using GB_Project.Services.ShopService.ShopAPI.Application.Commands;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
    public class AddGBProductImgCommandHandler : IRequestHandler<AddGBProductImgCommand, int>
    {
      private IShopRepository _repository;

      public AddGBProductImgCommandHandler ( IShopRepository repository )
      {
        _repository = repository;
      }

      public Task<int> Handle(AddGBProductImgCommand request, CancellationToken cancellationToken)
      {
        return Task.FromResult(_repository.CreateGBProductImg(request.GBProductId, request.Img));
      }
    }
}