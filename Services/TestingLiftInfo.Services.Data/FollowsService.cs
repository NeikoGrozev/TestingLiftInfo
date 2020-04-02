namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;
    using TestingLiftInfo.Web.ViewModels.Follows;

    public class FollowsService : IFollowsService
    {
        private readonly IDeletableEntityRepository<Follow> followRepository;
        private readonly IDeletableEntityRepository<Lift> liftRepository;
        private readonly ILiftsService liftsService;

        public FollowsService(IDeletableEntityRepository<Follow> followRepository, IDeletableEntityRepository<Lift> liftRepository, ILiftsService liftsService)
        {
            this.followRepository = followRepository;
            this.liftRepository = liftRepository;
            this.liftsService = liftsService;
        }

        public async Task AddFollow(string liftId, string userId)
        {
            var follow = new Follow()
            {
                ApplicationUserId = userId,
                LiftId = liftId,
            };

            await this.followRepository.AddAsync(follow);
            await this.followRepository.SaveChangesAsync();
        }

        public ICollection<Follow> GetAllFollowsForUser(string id)
        {
            var follows = this.followRepository
                .All()
                .Where(x => x.ApplicationUserId == id)
                .ToList();

            return follows;
        }

        public ICollection<LiftDetailViewModels> GetAllFollowsForUserViewModel(string id)
        {
            var follows = this.followRepository
                .All()
                .Where(x => x.ApplicationUserId == id)
                .ToList();

            var lifts = new List<LiftDetailViewModels>();

            foreach (var item in follows)
            {
                var lift = this.GetLiftWithId(item.LiftId);

                if (lift != null)
                {
                    lifts.Add(lift);
                }
            }

            return lifts;
        }

        private LiftDetailViewModels GetLiftWithId(string id)
        {
            var lift = this.liftRepository
                .All().Where(x => x.Id == id)
                .To<LiftDetailViewModels>()
                .FirstOrDefault();

            return lift;
        }
    }
}
