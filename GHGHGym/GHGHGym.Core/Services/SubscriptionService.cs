using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Subscriptions;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;
using GHGHGym.Infrastructure.Data.Models.Account;

namespace GHGHGym.Core.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private const string trainer = "trainer";
        private readonly IRepository<Subscription> subscriptionRepository;
        private readonly IRepository<SubscriptionType> subscriptionTypeRepository;
        private readonly IRepository<UserSubscription> userSubscriptionRepository;
        private readonly IRepository<ApplicationUser> appUserRepository;
        public SubscriptionService(IRepository<Subscription> subscriptionRepository,
            IRepository<SubscriptionType> subscriptionTypeRepository,
            IRepository<UserSubscription> userSubscriptionRepository,
            IRepository<ApplicationUser> appUserRepository)
        {
            this.subscriptionRepository = subscriptionRepository;
            this.subscriptionTypeRepository = subscriptionTypeRepository;
            this.userSubscriptionRepository = userSubscriptionRepository;
            this.appUserRepository = appUserRepository;
        }
        public IEnumerable<SubscriptionTypeViewModel> AllWithTrainerSubscriptionTypes()
        {
            var model = subscriptionTypeRepository.All()
                .Where(x => x.Name.Contains(trainer))
                .Select(x => new SubscriptionTypeViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
                })
                .ToList();
            return model;
        }

        public async Task<bool> IsUserSubscribedAsync(Guid userId)
        {
            var user = await appUserRepository.GetByIdAsync(userId);
            if (user.UsersSubscriptions.Any(x=>!x.IsDeleted))
            {
                return true;
            }
            return false;
        }

        public async Task SubscribeAsync(SubscriptionViewModel model, Guid userId)
        {
            var user = await appUserRepository.GetByIdAsync(userId);
            var subType = await subscriptionTypeRepository.GetByIdAsync(model.SubscriptionTypeId);

            DateTime endDate;
            if (subType.Name.Contains("Weekly"))
            {
                endDate = model.StartDate.AddDays(7);
            }
            else if (subType.Name.Contains("Monthly"))
            {
                endDate = model.StartDate.AddMonths(1);
            }
            else
            {
                endDate = model.StartDate.AddYears(1);
            }

            Subscription subscription = new Subscription()
            {
                SubscriptionTypeId = model.SubscriptionTypeId,
            };

            UserSubscription userSub = new UserSubscription()
            {
                Subscription = subscription,
                User = user,
                SubscriptionStartDate = model.StartDate,
                SubscriptionEndDate = endDate,
            };
            if (model.TrainerId != null)
            {
                userSub.TrainerId = model.TrainerId;
            }
            subscription.UsersSubscriptions.Add(userSub);

            await subscriptionRepository.AddAsync(subscription);
            await userSubscriptionRepository.AddAsync(userSub);

            await subscriptionRepository.SaveChangesAsync();
        }
    }
}
