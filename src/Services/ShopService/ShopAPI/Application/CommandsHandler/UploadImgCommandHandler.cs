using GB_Project.Services.ShopService.ShopAPI.Application.Commands;
using System.Threading;
using System.Threading.Tasks;
using GB_Project.Services.ShopService.ShopDomin.AggregatesModel;
using MediatR;

namespace GB_Project.Services.ShopService.ShopAPI.Application.CommandsHandler
{
    public class UploadImgCommandHandler : IRequestHandler<UploadImgCommand, string>
    {
      IShopRepository _repository;

      public UploadImgCommandHandler ( IShopRepository repository )
      {
        _repository = repository;
      }

      public Task<string> Handle(UploadImgCommand request, CancellationToken cancellationToken)
      {
        Shop shop = _repository.GetShopByMerchantId(request.MerchantId);
        string imgLocation = _repository.UploadShopImg(shop, request.ImgName, request.ImgData);

        return Task.FromResult(imgLocation);
      }
    }
}