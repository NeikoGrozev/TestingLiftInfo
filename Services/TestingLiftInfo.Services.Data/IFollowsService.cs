namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Web.ViewModels.Follows;

    public interface IFollowsService
    {
        ICollection<Follow> GetAllFollowsForUser(string id);

        public ICollection<LiftDetailViewModels> GetAllFollowsForUserViewModel(string id);

        Task AddFollow(string liftId, string userId);
    }
}
