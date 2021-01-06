namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Web.ViewModels.Administration.InspectTypes;

    public interface IInspectTypesService
    {
        Task<bool> CreateAsync(string name);

        Task<ICollection<InspectType>> GetAllInspectTypes();

        Task<ICollection<InspectTypeDetailViewModel>> GetAllInspectTypesForViewModel();

        Task<InspectTypeDetailViewModel> GetCurrentInspectType(string id);

        Task<bool> EditInspectType(string id, string name);
    }
}
