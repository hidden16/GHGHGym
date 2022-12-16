using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Subscriptions;
using GHGHGym.Core.Services;
using GHGHGym.Infrastructure.Data;
using GHGHGym.Infrastructure.Data.Common.Repositories;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;
using GHGHGym.Infrastructure.Data.Models.Account;
using GHGHGym.Infrastructure.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace GHGHGym.Tests
{
    [TestFixture]
    public class SubscriptionServiceTest
    {
        private ApplicationDbContext context;
        private IRepository<Subscription> subscriptionRepository;
        private IRepository<SubscriptionType> subscriptionTypeRepository;
        private IRepository<UserSubscription> userSubscriptionRepository;
        private IRepository<ApplicationUser> appUserRepository;
        private ISubscriptionService subscriptionService;

        [SetUp]
        public void SetUp()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("CategoryDb")
                .Options;

            context = new ApplicationDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            subscriptionRepository = new Repository<Subscription>(context);
            subscriptionTypeRepository = new Repository<SubscriptionType>(context);
            userSubscriptionRepository = new Repository<UserSubscription>(context);
            appUserRepository = new Repository<ApplicationUser>(context);
            subscriptionService = new SubscriptionService(subscriptionRepository, subscriptionTypeRepository, userSubscriptionRepository, appUserRepository);
        }

        [Test]
        public async Task Test_AllWithoutTrainerSubscriptionTypes()
        {
            SubscriptionType subType2 = new SubscriptionType
            {
                Id = Guid.Parse("1ced4e8c-0b55-4a56-9e55-da51701ec200"),
                Name = "trainer",
                Price = 50m
            };
            await subscriptionTypeRepository.AddAsync(subType2);

            SubscriptionType subType3 = new SubscriptionType
            {
                Id = Guid.Parse("1ced4e8c-0b55-4a56-9e55-da51701ec201"),
                Name = "Test",
                Price = 50m
            };
            await subscriptionTypeRepository.AddAsync(subType3);
            await subscriptionTypeRepository.SaveChangesAsync();

            var subTypes = subscriptionService.AllWithoutTrainerSubscriptionTypes();

            Assert.AreEqual(4, subTypes.Count());
        }

        [Test]
        public async Task Test_AllWithTrainerSubscriptionTypes()
        {
            SubscriptionType subType = new SubscriptionType
            {
                Id = Guid.Parse("1ced4e8c-0b55-4a56-9e55-da51701ec209"),
                Name = "Test SubType",
                Price = 50m
            };
            await subscriptionTypeRepository.AddAsync(subType);

            SubscriptionType subType2 = new SubscriptionType
            {
                Id = Guid.Parse("1ced4e8c-0b55-4a56-9e55-da51701ec200"),
                Name = "trainer",
                Price = 50m
            };
            await subscriptionTypeRepository.AddAsync(subType2);

            SubscriptionType subType3 = new SubscriptionType
            {
                Id = Guid.Parse("1ced4e8c-0b55-4a56-9e55-da51701ec201"),
                Name = "Test with trainer",
                Price = 50m
            };
            await subscriptionTypeRepository.AddAsync(subType3);
            await subscriptionTypeRepository.SaveChangesAsync();

            var subTypes = subscriptionService.AllWithTrainerSubscriptionTypes();

            Assert.AreEqual(5, subTypes.Count());
        }

        [Test]
        public async Task Test_IsUserSubscribedAsync()
        {
            var userId = Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2");
           
            var user = new ApplicationUser()
            {
                Id = userId,
                Email = "test@abv.bg",
                FirstName = "Ivan",
                LastName = "Ivan",
                Gender = GenderType.Male,
                BirthDate = DateTime.UtcNow,
                UserName = "IvanIvan",
            };
            await appUserRepository.AddAsync(user);
            await appUserRepository.SaveChangesAsync();

            SubscriptionType subType = new SubscriptionType()
            {
                Id = Guid.Parse("1ced4e8c-0b55-4a56-9e55-da51701ec209"),
                Name = "Test SubType",
                Price = 50m
            };

            await subscriptionTypeRepository.AddAsync(subType);
            await subscriptionTypeRepository.SaveChangesAsync();

            Subscription subscription = new Subscription()
            {
                SubscriptionTypeId = subType.Id
            };

            UserSubscription userSub = new UserSubscription()
            {
                Subscription = subscription,
                User = user,
                SubscriptionStartDate = DateTime.UtcNow,
                SubscriptionEndDate = DateTime.UtcNow.AddDays(7)
            };
            await userSubscriptionRepository.AddAsync(userSub);
            await userSubscriptionRepository.SaveChangesAsync();

            var isSubscribed = await subscriptionService.IsUserSubscribedAsync(userId);

            Assert.IsTrue(isSubscribed);

            var isNotSubscribed = await subscriptionService.IsUserSubscribedAsync(Guid.Parse("1ced4e8c-0b55-4a56-9e55-da51701ec201"));
            Assert.IsFalse(isNotSubscribed);

            userSubscriptionRepository.SetDeleted(userSub);
            await userSubscriptionRepository.SaveChangesAsync();

            isSubscribed = await subscriptionService.IsUserSubscribedAsync(userId);
            Assert.IsFalse(isSubscribed);
        }

        [Test]
        public async Task Test_SubscribeAsync()
        {
            var userId = Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2");

            var user = new ApplicationUser()
            {
                Id = userId,
                Email = "test@abv.bg",
                FirstName = "Ivan",
                LastName = "Ivan",
                Gender = GenderType.Male,
                BirthDate = DateTime.UtcNow,
                UserName = "IvanIvan",
            };
            await appUserRepository.AddAsync(user);
            await appUserRepository.SaveChangesAsync();

            SubscriptionType subType = new SubscriptionType()
            {
                Id = Guid.Parse("1ced4e8c-0b55-4a56-9e55-da51701ec209"),
                Name = "Monthly SubType",
                Price = 50m
            };

            await subscriptionTypeRepository.AddAsync(subType);
            await subscriptionTypeRepository.SaveChangesAsync();

            var trainerId = Guid.Parse("654d047b-6c92-466e-915b-fa46c399f6e3");

            SubscriptionViewModel model = new SubscriptionViewModel()
            {
                TrainerId = trainerId,
                StartDate = DateTime.UtcNow,
                SubscriptionTypeId = subType.Id,
                TrainerName = "George"
            };

            await subscriptionService.SubscribeAsync(model, userId);

            var userSub = userSubscriptionRepository.All();
            var sub = subscriptionRepository.All();

            Assert.AreEqual(1, userSub.Count());
            Assert.AreEqual(1, sub.Count());
        }
        [Test]
        public async Task Test_UnsubscribeAsync()
        {
            var userId = Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2");

            var user = new ApplicationUser()
            {
                Id = userId,
                Email = "test@abv.bg",
                FirstName = "Ivan",
                LastName = "Ivan",
                Gender = GenderType.Male,
                BirthDate = DateTime.UtcNow,
                UserName = "IvanIvan",
            };
            await appUserRepository.AddAsync(user);
            await appUserRepository.SaveChangesAsync();

            SubscriptionType subType = new SubscriptionType
            {
                Id = Guid.Parse("1ced4e8c-0b55-4a56-9e55-da51701ec209"),
                Name = "Test SubType",
                Price = 50m
            };

            await subscriptionTypeRepository.AddAsync(subType);
            await subscriptionTypeRepository.SaveChangesAsync();

            Subscription subscription = new Subscription()
            {
                SubscriptionTypeId = subType.Id
            };

            UserSubscription userSub = new UserSubscription()
            {
                Subscription = subscription,
                User = user,
                SubscriptionStartDate = DateTime.UtcNow,
                SubscriptionEndDate = DateTime.UtcNow.AddDays(7)
            };
            await userSubscriptionRepository.AddAsync(userSub);
            await userSubscriptionRepository.SaveChangesAsync();

            var subs = subscriptionRepository.All();

            var sub = await subs.Select(x => x.Id).FirstOrDefaultAsync();

            await subscriptionService.UnsubscribeAsync(sub, userId.ToString());

            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await subscriptionService.UnsubscribeAsync(sub, null);
            });

            var userSubs = userSubscriptionRepository.AllWithDeleted();

            var userSubscription = await userSubs.FirstOrDefaultAsync();

            Assert.AreEqual(1, userSubs.Count());
            Assert.AreEqual(true, userSubscription.IsDeleted);
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
