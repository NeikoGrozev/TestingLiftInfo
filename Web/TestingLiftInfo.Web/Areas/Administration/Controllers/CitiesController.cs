namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TestingLiftInfo.Common;
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
        public async Task<IActionResult> Create([FromForm] CreateCityInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var isCreate = await this.cityService.CreateAsync(model.Name);

            if (isCreate)
            {
                this.TempData["CreateCity"] = $"Град {model.Name} е добавен към списъка!";
            }

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            var cities = await this.cityService.GetAllCityForViewModel();
            var viewModel = new GetAllCityViewModel
            {
                Cities = cities,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var city = await this.cityService.GetCurrentCity(id);

            var viewModel = new EditCityViewModel
            {
                CityDetail = city,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] EditCityViewModel model)
        {
            var isCreate = false;

            if (GlobalConstants.Editors.Contains(this.User.Identity.Name))
            {
                isCreate = await this.cityService.EditCity(model.Id, model.Name);
            }

            if (isCreate)
            {
                this.TempData["EditCity"] = $"гр.{model.Name} е редактиран!";
            }

            return this.RedirectToAction("All");
        }
    }
}
