namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{

    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Data;
    using TestingLiftInfo.Web.Controllers;
    using TestingLiftInfo.Web.ViewModels.Administration.Cities;

    public class CityController : AdministrationController
    {
        private readonly ICityService cityService;
        private readonly IDeletableEntityRepository<City> repository;

        public CityController(ICityService cityService, IDeletableEntityRepository<City> repository)
        {
            this.cityService = cityService;
            this.repository = repository;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            var currentCity = this.repository.All().FirstOrDefault(x => x.Name == name);

            if (currentCity == null)
            {
                var city = new City { Name = name };

                await this.repository.AddAsync(city);
                await this.repository.SaveChangesAsync();
            }

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var cities = this.cityService.GetAllCity();

            return this.View(cities);
        }
    }
}
