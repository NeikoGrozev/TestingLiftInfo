namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using TestingLiftInfo.Common;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Data;
    using TestingLiftInfo.Web.ViewModels.Administration.Lifts;

    public class LiftsController : AdministrationController
    {
        private readonly ILiftsService liftService;
        private readonly ICitiesService cityService;
        private readonly IManufacturersService manufacturerService;
        private readonly UserManager<ApplicationUser> userManager;

        public LiftsController(
            ILiftsService liftService,
            ICitiesService cityService,
            IManufacturersService manufacturerService,
            UserManager<ApplicationUser> userManager)
        {
            this.liftService = liftService;
            this.cityService = cityService;
            this.manufacturerService = manufacturerService;
            this.userManager = userManager;
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

            var userId = this.userManager.GetUserId(this.User);

            await this.liftService.CreateAsync(
                userId,
                model.CreateLiftViewModel.LiftType,
                model.CreateLiftViewModel.NumberOfStops,
                model.CreateLiftViewModel.Capacity,
                model.CreateLiftViewModel.DoorType,
                model.CreateLiftViewModel.ManufacturerId,
                model.CreateLiftViewModel.ProductionNumber,
                model.CreateLiftViewModel.CityId,
                model.CreateLiftViewModel.Address);

            return this.RedirectToAction("All", "Lifts");
        }

        public IActionResult All(int page = 1)
        {
            var numberOfPrintLifts = GlobalConstants.NumberOfPrintLifts;

            var lifts = this.liftService.GetAllLifts(page, numberOfPrintLifts);

            var count = this.liftService.GetCountAllActiveLifts();
            var pagesCount = (int)Math.Ceiling((double)count / numberOfPrintLifts);

            if (pagesCount == 0)
            {
                pagesCount = 1;
            }

            var allLiftViewModel = new GetAllLiftsViewModel
            {
                Lifts = lifts,
                PagesCount = pagesCount,
                CurrentPage = page,
                CountAllLifts = count,
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
            await this.liftService.DeleteAsync(id);

            return this.RedirectToAction("All");
        }
    }
}
