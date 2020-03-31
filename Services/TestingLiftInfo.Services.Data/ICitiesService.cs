namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Web.ViewModels.Administration.Cities;

    public interface ICitiesService
    {
        ICollection<City> GetAllCity();

        ICollection<CityDetailViewModel> GetAllCityForViewModel();
    }
}
