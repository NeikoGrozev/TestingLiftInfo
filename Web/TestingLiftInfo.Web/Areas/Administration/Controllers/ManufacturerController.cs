namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Data;

    public class ManufacturerController : AdministrationController
    {
        private readonly IManufacturerService service;
        private readonly IDeletableEntityRepository<Manufacturer> repository;

        public ManufacturerController(IManufacturerService service, IDeletableEntityRepository<Manufacturer> repository)
        {
            this.service = service;
            this.repository = repository;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            var currentManufacturer = this.repository.All().FirstOrDefault(x => x.Name == name);

            if (currentManufacturer == null)
            {
                var manufacturer = new Manufacturer { Name = name };

                await this.repository.AddAsync(manufacturer);
                await this.repository.SaveChangesAsync();
            }

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var manufacturers = this.service.GEtAllManufacturers();

            return this.View(manufacturers);
        }
    }
}
