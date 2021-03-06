﻿namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TestingLiftInfo.Common;
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
        public async Task<IActionResult> Create([FromForm]CreateManufacturerInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var isCreate = await this.manufacturerService.CreateAsync(model.Name);

            if (isCreate)
            {
                this.TempData["CreateManufacturer"] = $"Производителят {model.Name} е добавен към списъка!";
            }

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            var manufacturers = await this.manufacturerService.GetAllManufacturersForViewModel();

            var viewModel = new GetAllManufacturerViewModel
            {
                Manufacturers = manufacturers,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var manufacturer = await this.manufacturerService.GetCurrentManufacturer(id);

            var viewModel = new EditManufacturerViewModel
            {
                ManufacturerDetail = manufacturer,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] EditManufacturerViewModel model)
        {
            var isCreate = false;

            if (GlobalConstants.Editors.Contains(this.User.Identity.Name))
            {
                isCreate = await this.manufacturerService.EditManufacturer(model.Id, model.Name);
            }

            if (isCreate)
            {
                this.TempData["EditManufacturer"] = $"Произовдител {model.Name} е редактиран!";
            }

            return this.RedirectToAction("All");
        }
    }
}
