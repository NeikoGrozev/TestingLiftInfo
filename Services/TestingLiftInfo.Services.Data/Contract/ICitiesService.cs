namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Web.ViewModels.Administration.Cities;

    public interface ICitiesService
    {
        Task<bool> CreateAsync(string name);

        ICollection<City> GetAllCity();

        ICollection<CityDetailViewModel> GetAllCityForViewModel();
    }
}
