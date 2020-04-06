namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Web.ViewModels.Administration.InspectTypes;

    public interface IInspectTypesService
    {
        Task CreateAsync(string name);

        ICollection<InspectType> GetAllInspectTypes();

        ICollection<InspectTypeDetailViewModel> GetAllInspectTypesForViewModel();
    }
}
