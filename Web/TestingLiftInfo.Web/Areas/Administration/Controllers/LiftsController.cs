﻿namespace TestingLiftInfo.Web.Areas.Administration.Controllers
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
    using TestingLiftInfo.Web.ViewModels.Administration.Lifts.Edit;

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

        public async Task<IActionResult> Create()
        {
            var manufacturers = await this.manufacturerService.GetAllManufacturers();
            var cities = await this.cityService.GetAllCity();
            var inputModel = new LiftInputDataViewModel
            {
                Manufacturers = manufacturers,
                Cities = cities,
            };

            var createModel = new CreateLiftInputModel();

            var viewModel = new BigCreateLiftViewModel()
            {
                LiftInputDataViewModel = inputModel,
                CreateLiftInputModel = createModel,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] BigCreateLiftViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.userManager.GetUserId(this.User);

            var isCreate = await this.liftService.CreateAsync(
                 userId,
                 model.CreateLiftInputModel.LiftType,
                 model.CreateLiftInputModel.NumberOfStops,
                 model.CreateLiftInputModel.Capacity,
                 model.CreateLiftInputModel.DoorType,
                 model.CreateLiftInputModel.ManufacturerId,
                 model.CreateLiftInputModel.ProductionNumber,
                 model.CreateLiftInputModel.CityId,
                 model.CreateLiftInputModel.Address,
                 model.CreateLiftInputModel.Latitude,
                 model.CreateLiftInputModel.Longitude);

            if (isCreate)
            {
                this.TempData["CreateLift"] = $"Асансьорът е добавен към списъка!";
            }

            return this.RedirectToAction("All", "Lifts");
        }

        public async Task<IActionResult> All(int page = 1)
        {
            var numberOfPrintLifts = GlobalConstants.NumberOfPrintLifts;

            var lifts = await this.liftService.GetAllLifts(page, numberOfPrintLifts);

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

        public async Task<IActionResult> Detail(string id)
        {
            var viewModel = await this.liftService.GetCurrentLift(id);

            return this.View(viewModel);
        }

        public async Task<IActionResult> Search(SearchLiftViewModel searchLiftViewModel)
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
                searchLifts = await this.liftService.SearchRegistrationCriteria(registrationNumber, isDeleted);
            }
            else if (isRegistration && isManufacturer && !isCityOrAddress)
            {
                searchLifts = await this.liftService.SearchRegisAndManufCriteria(registrationNumber, manufaturer, isDeleted);
            }
            else if (isRegistration && !isManufacturer && isCityOrAddress)
            {
                searchLifts = await this.liftService.SearchRegisAndCityCriteria(registrationNumber, cityOrAddress, isDeleted);
            }
            else if (!isRegistration && isManufacturer && !isCityOrAddress)
            {
                searchLifts = await this.liftService.SearchManufacturerCriteria(manufaturer, isDeleted);
            }
            else if (!isRegistration && isManufacturer && isCityOrAddress)
            {
                searchLifts = await this.liftService.SearchManufAndCityCriteria(manufaturer, cityOrAddress, isDeleted);
            }
            else if (!isRegistration && !isManufacturer && isCityOrAddress)
            {
                searchLifts = await this.liftService.SearchCityCriteria(cityOrAddress, isDeleted);
            }
            else if (!isRegistration && !isManufacturer && !isCityOrAddress && isDeleted == true)
            {
                searchLifts = await this.liftService.SearchIsDeletedCriteria(isDeleted);
            }
            else if (!isRegistration && !isManufacturer && !isCityOrAddress && isDeleted == false)
            {
                return this.RedirectToAction("All");
            }
            else
            {
                searchLifts = await this.liftService.GetAllSearchCriteria(registrationNumber, manufaturer, cityOrAddress, isDeleted);
            }

            var viewModel = new GetSearchLiftsViewModel()
            {
                Lifts = searchLifts,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var manufacturers = await this.manufacturerService.GetAllManufacturers();
            var cities = await this.cityService.GetAllCity();
            var inputModel = new EditManufactureAndCityViewModel
            {
                Manufacturers = manufacturers,
                Cities = cities,
            };

            var liftEditDataViewModel = await this.liftService.GetCurrentLiftForEdit(id);
            var editLiftModel = new EditLiftViewModel();

            var viewModel = new BigEditLiftViewModel
            {
                EditManufactureAndCityViewModel = inputModel,
                LiftEditDataViewModel = liftEditDataViewModel,
                EditLiftViewModel = editLiftModel,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] BigEditLiftViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.userManager.GetUserId(this.User);

            var isCreate = await this.liftService.EditLift(
                userId,
                model.EditLiftViewModel.Id,
                model.EditLiftViewModel.LiftType,
                model.EditLiftViewModel.NumberOfStops,
                model.EditLiftViewModel.Capacity,
                model.EditLiftViewModel.DoorType,
                model.EditLiftViewModel.ManufacturerId,
                model.EditLiftViewModel.ProductionNumber,
                model.EditLiftViewModel.CityId,
                model.EditLiftViewModel.Address,
                model.EditLiftViewModel.Latitude,
                model.EditLiftViewModel.Longitude);

            if (isCreate)
            {
                this.TempData["CreateLift"] = $"Асансьорът е редактиран!";
            }

            return this.RedirectToAction("All", "Lifts");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await this.liftService.DeleteAsync(id);

            return this.RedirectToAction("All");
        }
    }
}
