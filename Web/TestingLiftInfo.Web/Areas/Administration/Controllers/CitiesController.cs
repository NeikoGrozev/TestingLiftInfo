namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using TestingLiftInfo.Services.Data;
    using TestingLiftInfo.Web.ViewModels.Administration.Cities;

    public class CitiesController : AdministrationController
    {
        private readonly ICitiesService cityService;

        public CitiesController(ICitiesService cityService)
        {
            this.cityService = cityService;
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

            await this.cityService.CreateAsync(model.Name);

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
