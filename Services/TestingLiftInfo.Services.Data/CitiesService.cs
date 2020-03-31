namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;
    using TestingLiftInfo.Web.ViewModels.Administration.Cities;

    public class CitiesService : ICitiesService
    {
        private readonly IDeletableEntityRepository<City> cityRepository;

        public CitiesService(IDeletableEntityRepository<City> cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        public ICollection<City> GetAllCity()
        {
            var cities = this.cityRepository
               .All()
               .OrderBy(x => x.Name)
               .ToList();

            return cities;
        }

        public ICollection<CityDetailViewModel> GetAllCityForViewModel()
        {
            var cities = this.cityRepository
                .All()
                .OrderBy(x => x.Name)
                .To<CityDetailViewModel>()
                .ToList();

            return cities;
        }
    }
}
