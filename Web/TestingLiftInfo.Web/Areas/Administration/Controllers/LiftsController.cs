namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Data;
    using TestingLiftInfo.Web.ViewModels.Administration.Lifts;

    public class LiftsController : AdministrationController
    {
        private readonly ILiftsService liftService;
        private readonly ICitiesService cityService;
        private readonly IManufacturersService manufacturerService;
        private readonly IDeletableEntityRepository<Lift> liftRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public LiftsController(
            ILiftsService liftService,
            ICitiesService cityService,
            IManufacturersService manufacturerService,
            IDeletableEntityRepository<Lift> liftRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.liftService = liftService;
            this.cityService = cityService;
            this.manufacturerService = manufacturerService;
            this.liftRepository = liftRepository;
            this.userRepository = userRepository;
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

            var currentNumber = (this.liftRepository.AllWithDeleted().Count() + 1).ToString();
            var user = this.User.Identity;
            var currentUser = this.userRepository.All().FirstOrDefault(x => x.Email == user.Name);

            var lift = new Lift
            {
                ApplicationUserId = currentUser.Id,
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
            var isDeleted = searchLiftViewModel.IsDeleted;

            var isRegistration = !string.IsNullOrEmpty(registrationNumber);
            var isManufacturer = !string.IsNullOrEmpty(manufaturer);
            var isCityOrAddress = !string.IsNullOrEmpty(cityOrAddress);

            ICollection<LiftViewModel> searchLifts = new List<LiftViewModel>();

            if (isRegistration && !isManufacturer && !isCityOrAddress)
            {
                searchLifts = this.liftService.SearchRegistrationCriteria(registrationNumber, isDeleted);
            }
            else if (isRegistration && isManufacturer && !isCityOrAddress)
            {
                searchLifts = this.liftService.SearchRegisAndManufCriteria(registrationNumber, manufaturer, isDeleted);
            }
            else if (isRegistration && !isManufacturer && isCityOrAddress)
            {
                searchLifts = this.liftService.SearchRegisAndCityCriteria(registrationNumber, cityOrAddress, isDeleted);
            }
            else if (!isRegistration && isManufacturer && !isCityOrAddress)
            {
                searchLifts = this.liftService.SearchManufacturerCriteria(manufaturer, isDeleted);
            }
            else if (!isRegistration && isManufacturer && isCityOrAddress)
            {
                searchLifts = this.liftService.SearchManufAndCityCriteria(manufaturer, cityOrAddress, isDeleted);
            }
            else if (!isRegistration && !isManufacturer && isCityOrAddress)
            {
                searchLifts = this.liftService.SearchCityCriteria(cityOrAddress, isDeleted);
            }
            else if (!isRegistration && !isManufacturer && !isCityOrAddress && isDeleted == true)
            {
                searchLifts = this.liftService.SearchIsDeletedCriteria(isDeleted);
            }
            else if (!isRegistration && !isManufacturer && !isCityOrAddress && isDeleted == false)
            {
                return this.RedirectToAction("All");
            }
            else
            {
                searchLifts = this.liftService.GetAllSearchCriteria(registrationNumber, manufaturer, cityOrAddress, isDeleted);
            }

            var viewModel = new GetSearchLiftsViewModel()
            {
                Lifts = searchLifts,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var lift = this.liftService.GetLift(id);

            this.liftRepository.Delete(lift);
            await this.liftRepository.SaveChangesAsync();

            return this.RedirectToAction("All");
        }
    }
}
