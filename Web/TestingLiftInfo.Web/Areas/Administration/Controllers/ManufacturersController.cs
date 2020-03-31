namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Data;
    using TestingLiftInfo.Web.ViewModels.Administration.Manufacturers;

    public class ManufacturersController : AdministrationController
    {
        private readonly IManufacturersService service;
        private readonly IDeletableEntityRepository<Manufacturer> manufacturerRepository;

        public ManufacturersController(IManufacturersService service, IDeletableEntityRepository<Manufacturer> manufacturerRepository)
        {
            this.service = service;
            this.manufacturerRepository = manufacturerRepository;
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

            var currentManufacturer = this.manufacturerRepository.All().FirstOrDefault(x => x.Name == model.Name);

            if (currentManufacturer == null)
            {
                var manufacturer = new Manufacturer { Name = model.Name };

                await this.manufacturerRepository.AddAsync(manufacturer);
                await this.manufacturerRepository.SaveChangesAsync();
            }

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var manufacturers = this.service.GetAllManufacturersForViewModel();

            var viewModel = new GetAllManufacturerViewModel
            {
                Manufacturers = manufacturers,
            };

            return this.View(viewModel);
        }
    }
}
