using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Subscriptions;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;

namespace GHGHGym.Core.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private const string trainer = "trainer";
        private readonly IRepository<SubscriptionType> subscriptionTypeRepository;
        public SubscriptionService(IRepository<SubscriptionType> subscriptionTypeRepository)
        {
            this.subscriptionTypeRepository = subscriptionTypeRepository;
        }
        public IEnumerable<SubscriptionTypeViewModel> AllWithTrainerSubscriptionTypes()
        {
            var model = subscriptionTypeRepository.All()
                .Where(x=>x.Name.Contains(trainer))
                .Select(x => new SubscriptionTypeViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
                })
                .ToList();
            return model;
        }
    }
}
