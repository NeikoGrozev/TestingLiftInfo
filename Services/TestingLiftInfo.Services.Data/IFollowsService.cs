namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Web.ViewModels.Follows;

    public interface IFollowsService
    {
        ICollection<Follow> GetAllFollowsForUser(string id);

        ICollection<LiftDetailViewModels> GetAllFollowsForUserViewModel(string id);

        LiftDetailViewModels GetLiftWithId(string id);

        InspectDetailsViewModel GetInspectWithId(string id);
    }
}
