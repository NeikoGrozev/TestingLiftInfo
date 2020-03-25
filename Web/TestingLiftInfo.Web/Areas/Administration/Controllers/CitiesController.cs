namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Data;
    using TestingLiftInfo.Web.ViewModels.Administration.Cities;

    public class CitiesController : AdministrationController
    {
        private readonly ICitiesService cityService;
        private readonly IDeletableEntityRepository<City> repository;

        public CitiesController(ICitiesService cityService, IDeletableEntityRepository<City> repository)
        {
            this.cityService = cityService;
            this.repository = repository;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateCityViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var currentCity = this.repository
                .All()
                .FirstOrDefault(x => x.Name == model.Name);

            if (currentCity == null)
            {
                var city = new City
                {
                    Name = model.Name,
                };

                await this.repository.AddAsync(city);
                await this.repository.SaveChangesAsync();
            }

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var cities = this.cityService.GetAllCityForViewModel();
            var viewModel = new GetAllCityViewModel
            {
                Cities = cities,
            };

            return this.View(viewModel);
        }
    }
}
