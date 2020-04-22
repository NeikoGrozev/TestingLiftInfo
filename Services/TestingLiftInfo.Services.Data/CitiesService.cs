namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> CreateAsync(string name)
        {
            var currentCity = this.cityRepository
               .All()
               .FirstOrDefault(x => x.Name == name);

            var isCreate = false;

            if (currentCity == null && !string.IsNullOrWhiteSpace(name))
            {
                var city = new City
                {
                    Name = name,
                };

                await this.cityRepository.AddAsync(city);
                await this.cityRepository.SaveChangesAsync();

                isCreate = true;
            }

            return isCreate;
        }

        public async Task<ICollection<City>> GetAllCity()
        {
            var cities = await this.cityRepository
               .All()
               .OrderBy(x => x.Name)
               .ToListAsync();

            return cities;
        }

        public async Task<ICollection<CityDetailViewModel>> GetAllCityForViewModel()
        {
            var cities = await this.cityRepository
                .All()
                .OrderBy(x => x.Name)
                .To<CityDetailViewModel>()
                .ToListAsync();

            return cities;
        }
    }
}
