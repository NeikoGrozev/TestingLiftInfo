namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Data.Models.Enumerations;
    using TestingLiftInfo.Services.Data;
    using TestingLiftInfo.Web.ViewModels.Administration.Lifts;

    public class LiftsController : AdministrationController
    {
        private readonly ILiftsService liftService;
        private readonly ICityService cityService;
        private readonly IManufacturerService manufacturerService;
        private readonly IDeletableEntityRepository<Manufacturer> manufacturerRepository;
        private readonly IDeletableEntityRepository<City> cityRepository;
        private readonly IDeletableEntityRepository<Lift> liftRepository;

        public LiftsController(ILiftsService liftService,
            ICityService cityService, 
            IManufacturerService manufacturerService,
            IDeletableEntityRepository<Manufacturer> manufacturerRepository,
            IDeletableEntityRepository<City> cityRepository,
            IDeletableEntityRepository<Lift> liftRepository)
        {
            this.liftService = liftService;
            this.cityService = cityService;
            this.manufacturerService = manufacturerService;
            this.manufacturerRepository = manufacturerRepository;
            this.cityRepository = cityRepository;
            this.liftRepository = liftRepository;
        }

        public IActionResult Create()
        {
            var manufacturer = this.manufacturerService.GEtAllManufacturers();
            var cities = this.cityService.GetAllCity();
            var viewModel = new CreateLiftViewModel
            {
                Manufacturers = manufacturer,
                Cities = cities,

            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string registrationNumber,
            LiftType liftType,
            int numberOfStops,
            int capacity,
            DoorType doorType,
            string manufacturer,
            string city,
            string address)
        {
            var currentManufacturer = this.manufacturerRepository.All().FirstOrDefault(x => x.Name == manufacturer);
            var currentCity = this.cityRepository.All().FirstOrDefault(x => x.Name == city);

            var lift = new Lift
            {
                RegistrationNumber = "777АС" + registrationNumber,
                LiftType = liftType,
                NumberOfStops = numberOfStops,
                Capacity = capacity,
                DoorType = doorType,
                ManufacturerId = currentManufacturer.Id,
                CityId = currentCity.Id,
                Address = address,
            };

            await this.liftRepository.AddAsync(lift);
            await this.liftRepository.SaveChangesAsync();

            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult All()
        {
            //var lifts = this.liftService.GetAllLifts();

            return this.View();
        }
    }
}
