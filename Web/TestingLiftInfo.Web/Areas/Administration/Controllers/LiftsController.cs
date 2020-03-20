namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TestingLiftInfo.Data.Models.Enumerations;
    using TestingLiftInfo.Services.Data;
    using TestingLiftInfo.Web.ViewModels.Administration.Lifts;

    public class LiftsController : AdministrationController
    {
        private readonly ILiftsService liftService;
        private readonly ICityService cityService;

        public LiftsController(ILiftsService liftService, ICityService cityService)
        {
            this.liftService = liftService;
            this.cityService = cityService;
        }

        public IActionResult Create()
        {
            var cities = this.cityService.GetAllCity();
            var viewModel = new CreateLiftViewModel
            {
               
                Cities = cities,

            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LiftType liftType, int numberOfStops, string name)
        {
            return this.View();
        }

        public IActionResult All()
        {
            //var lifts = this.liftService.GetAllLifts();

            return this.View();
        }
    }
}
