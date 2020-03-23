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
        public async Task<IActionResult> Create(/*string registrationNumber,*/
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
            var currentNumber = (this.liftRepository.All().Count() + 1).ToString();

            var lift = new Lift
            {
                RegistrationNumber = "777АС" + currentNumber,
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
            var city = searchLiftViewModel.City;

            var isRegistration = !string.IsNullOrEmpty(registrationNumber);
            var isManufacturer = !string.IsNullOrEmpty(manufaturer);
            var isCity = !string.IsNullOrEmpty(city);

            ICollection<LiftViewModel> lifts = new List<LiftViewModel>();

            if (isRegistration && !isManufacturer && !isCity)
            {
                lifts = this.liftService.SearchRegistrationCriteria(registrationNumber);
            }
            else if (isRegistration && isManufacturer && !isCity)
            {
                lifts = this.liftService.SearchRegisAndManufCriteria(registrationNumber, manufaturer);
            }
            else if (isRegistration && !isManufacturer && isCity)
            {
                lifts = this.liftService.SearchRegisAndCityCriteria(registrationNumber, city);
            }
            else if (!isRegistration && isManufacturer && !isCity)
            {
                lifts = this.liftService.SearchManufacturerCriteria(manufaturer);
            }
            else if (!isRegistration && isManufacturer && isCity)
            {
                lifts = this.liftService.SearchManufAndCityCriteria(manufaturer, city);
            }
            else if (!isRegistration && !isManufacturer && isCity)
            {
                lifts = this.liftService.SearchCityCriteria(city);
            }
            else
            {
                lifts = this.liftService.GetAllSearchCriteria(registrationNumber, manufaturer, city);
            }

            var viewModel = new GetSearchLiftsViewModel()
            {
                Lifts = lifts,
            };

            return this.View(viewModel);
        }
    }
}
