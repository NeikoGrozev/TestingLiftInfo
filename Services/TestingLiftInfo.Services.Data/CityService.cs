namespace TestingLiftInfo.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;
    using TestingLiftInfo.Web.ViewModels.Administration.Cities;

    public class CityService : ICityService
    {
        private readonly IDeletableEntityRepository<City> repo;

        public CityService(IDeletableEntityRepository<City> repo)
        {
            this.repo = repo;
        }

        public ICollection<City> GetAllCity()
        {
            var cities = this.repo.All().OrderBy(x => x.Name).ToList();

            return cities;
        }
    }
}
