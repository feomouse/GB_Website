using System.Threading.Tasks;
using GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel;
using GB_Project.EventBus.BasicEventBus.Abstraction;
using Microsoft.AspNetCore.Identity;

namespace GB_Project.Services.MerchantService.MerchantAPI.IntergrationEvents.EventHandler
{
    public class MerchantRegisteredIntergrationEventHandler : IIntergrationEventHandler<MerchantRegisteredIntergrationEvent>
    {
      private IMerchantRepository _repository;

      public MerchantRegisteredIntergrationEventHandler(IMerchantRepository repository)
      {
        _repository = repository;
      }

      public async Task Handle(MerchantRegisteredIntergrationEvent @event)
      {
        MerchantBasic newMerchant = new MerchantBasic(@event.Id);

        await _repository.CreateMerchantBasic(newMerchant);
      }
    }
}