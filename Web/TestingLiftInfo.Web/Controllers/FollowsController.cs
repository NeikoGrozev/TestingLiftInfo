namespace TestingLiftInfo.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Data;
    using TestingLiftInfo.Web.ViewModels.Follows;

    [Authorize]
    public class FollowsController : BaseController
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IFollowsService followsService;
        private readonly ILiftsService liftsService;
        private readonly UserManager<ApplicationUser> userManager;

        public FollowsController(
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IFollowsService followsService,
            ILiftsService liftsService,
            UserManager<ApplicationUser> userManager)
        {
            this.userRepository = userRepository;
            this.followsService = followsService;
            this.liftsService = liftsService;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateFollowViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.userManager.GetUserId(this.User);

            var follows = this.followsService.GetAllFollowsForUser(userId);
            var lift = this.liftsService.GetLiftWithRegistrationNumber(model.RegistrationNumber);

            if (lift == null)
            {
                return this.View();
            }

            var isTrue = follows.Any(x => x.LiftId == lift.Id);

            if (follows.Count() >= 3 || isTrue)
            {
                return this.RedirectToAction("All");
            }

            this.followsService.AddFollow(lift.Id, userId);

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var userId = this.userManager.GetUserId(this.User);
            var lifts = this.followsService.GetAllFollowsForUserViewModel(userId);

            var viewModel = new AllFollowLiftsViewModel()
            {
                LiftDetailViewModels = lifts,
            };

            return this.View(viewModel);
        }
    }
}
