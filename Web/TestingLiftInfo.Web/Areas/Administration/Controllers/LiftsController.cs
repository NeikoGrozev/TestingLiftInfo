﻿namespace TestingLiftInfo.Web.Areas.Administration.Controllers
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
        private readonly ICitiesService cityService;
        private readonly IManufacturersService manufacturerService;
        private readonly IDeletableEntityRepository<Manufacturer> manufacturerRepository;
        private readonly IDeletableEntityRepository<City> cityRepository;
        private readonly IDeletableEntityRepository<Lift> liftRepository;

        public LiftsController(
            ILiftsService liftService,
            ICitiesService cityService,
            IManufacturersService manufacturerService,
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
            var manufacturers = this.manufacturerService.GetAllManufacturers();
            var cities = this.cityService.GetAllCity();
            var inputModel = new LiftInputDataViewModel
            {
                Manufacturers = manufacturers,
                Cities = cities,
            };

            var createModel = new CreateLiftViewModel();

            var viewModel = new BigCreateLiftViewModel()
            {
                LiftInputDataViewModel = inputModel,
                CreateLiftViewModel = createModel,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]BigCreateLiftViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var currentNumber = (this.liftRepository.All().Count() + 1).ToString();

            var lift = new Lift
            {
                RegistrationNumber = "777АС" + currentNumber,
                LiftType = model.CreateLiftViewModel.LiftType,
                NumberOfStops = model.CreateLiftViewModel.NumberOfStops,
                Capacity = model.CreateLiftViewModel.Capacity,
                DoorType = model.CreateLiftViewModel.DoorType,
                ManufacturerId = model.CreateLiftViewModel.ManufacturerId,
                ProductionNumber = model.CreateLiftViewModel.ProductionNumber,
                CityId = model.CreateLiftViewModel.CityId,
                Address = model.CreateLiftViewModel.Address,
            };

            await this.liftRepository.AddAsync(lift);
            await this.liftRepository.SaveChangesAsync();

            return this.RedirectToAction("All", "Lifts");
        }

        public IActionResult All()
        {
            var lifts = this.liftService.GetAllLifts();

            var allLiftViewModel = new GetAllLiftsViewModel
            {
                Lifts = lifts,
            };

            var searchViewModel = new SearchLiftViewModel();

            var bigLiftViewModel = new BigLiftViewModel
            {
                GetAllLiftViewModel = allLiftViewModel,
                SearchLiftViewModel = searchViewModel,
            };

            return this.View(bigLiftViewModel);
        }

        public IActionResult Detail(string id)
        {
            var viewModel = this.liftService.GetCurrentLift(id);

            return this.View(viewModel);
        }

        public IActionResult Search(SearchLiftViewModel searchLiftViewModel)
        {
            var registrationNumber = searchLiftViewModel.RegistrationNumber;
            var manufaturer = searchLiftViewModel.Manufacturer;
            var cityOrAddress = searchLiftViewModel.City;

            var isRegistration = !string.IsNullOrEmpty(registrationNumber);
            var isManufacturer = !string.IsNullOrEmpty(manufaturer);
            var isCityOrAddress = !string.IsNullOrEmpty(cityOrAddress);

            ICollection<LiftViewModel> lifts = new List<LiftViewModel>();

            if (isRegistration && !isManufacturer && !isCityOrAddress)
            {
                lifts = this.liftService.SearchRegistrationCriteria(registrationNumber);
            }
            else if (isRegistration && isManufacturer && !isCityOrAddress)
            {
                lifts = this.liftService.SearchRegisAndManufCriteria(registrationNumber, manufaturer);
            }
            else if (isRegistration && !isManufacturer && isCityOrAddress)
            {
                lifts = this.liftService.SearchRegisAndCityCriteria(registrationNumber, cityOrAddress);
            }
            else if (!isRegistration && isManufacturer && !isCityOrAddress)
            {
                lifts = this.liftService.SearchManufacturerCriteria(manufaturer);
            }
            else if (!isRegistration && isManufacturer && isCityOrAddress)
            {
                lifts = this.liftService.SearchManufAndCityCriteria(manufaturer, cityOrAddress);
            }
            else if (!isRegistration && !isManufacturer && isCityOrAddress)
            {
                lifts = this.liftService.SearchCityCriteria(cityOrAddress);
            }
            else
            {
                lifts = this.liftService.GetAllSearchCriteria(registrationNumber, manufaturer, cityOrAddress);
            }

            var viewModel = new GetSearchLiftsViewModel()
            {
                Lifts = lifts,
            };

            return this.View(viewModel);
        }
    }
}
