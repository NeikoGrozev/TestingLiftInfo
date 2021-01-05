namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Web.ViewModels.Administration.Cities;

    public interface ICitiesService
    {
        Task<bool> CreateAsync(string name);

        Task<ICollection<City>> GetAllCity();

        Task<ICollection<CityDetailViewModel>> GetAllCityForViewModel();

        Task<CityDetailViewModel> GetCurrentCity(string id);

        Task<bool> EditCity(string id, string name);
    }
}
