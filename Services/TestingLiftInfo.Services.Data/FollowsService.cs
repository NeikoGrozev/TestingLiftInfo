namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;
    using TestingLiftInfo.Web.ViewModels.Follows;

    public class FollowsService : IFollowsService
    {
        private readonly IDeletableEntityRepository<Follow> followRepository;
        private readonly IDeletableEntityRepository<Lift> liftRepository;
        private readonly IDeletableEntityRepository<Inspect> inspectRepository;

        public FollowsService(IDeletableEntityRepository<Follow> followRepository, IDeletableEntityRepository<Lift> liftRepository, IDeletableEntityRepository<Inspect> inspectRepository)
        {
            this.followRepository = followRepository;
            this.liftRepository = liftRepository;
            this.inspectRepository = inspectRepository;
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

            lifts = lifts
                .OrderBy(x => x.CreatedOn)
                .ToList();

            return lifts;
        }

        public InspectDetailsViewModel GetInspectWithId(string id)
        {
            var inspect = this.inspectRepository
              .All()
              .Where(x => x.Id == id)
              .To<InspectDetailsViewModel>()
              .FirstOrDefault();

            return inspect;
        }

        public LiftDetailViewModels GetLiftWithId(string id)
        {
            var lift = this.liftRepository
                .All()
                .Where(x => x.Id == id)
                .To<LiftDetailViewModels>()
                .FirstOrDefault();

            return lift;
        }
    }
}
