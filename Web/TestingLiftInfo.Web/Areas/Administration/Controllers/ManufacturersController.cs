namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using TestingLiftInfo.Services.Data;
    using TestingLiftInfo.Web.ViewModels.Administration.Manufacturers;

    public class ManufacturersController : AdministrationController
    {
        private readonly IManufacturersService manufacturerService;

        public ManufacturersController(IManufacturersService service)
        {
            this.manufacturerService = service;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateManufacturerViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.manufacturerService.CreateAsync(model.Name);

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var manufacturers = this.manufacturerService.GetAllManufacturersForViewModel();

            var viewModel = new GetAllManufacturerViewModel
            {
                Manufacturers = manufacturers,
            };

            return this.View(viewModel);
        }
    }
}
