namespace TestingLiftInfo.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using TestingLiftInfo.Common;
    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Data;
    using TestingLiftInfo.Web.ViewModels.Follows;

    [Authorize]
    public class FollowsController : BaseController
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<Follow> followRepository;
        private readonly IFollowsService followsService;
        private readonly ILiftsService liftsService;
        private readonly UserManager<ApplicationUser> userManager;

        public FollowsController(
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IDeletableEntityRepository<Follow> followRepository,
            IFollowsService followsService,
            ILiftsService liftsService,
            UserManager<ApplicationUser> userManager)
        {
            this.userRepository = userRepository;
            this.followRepository = followRepository;
            this.followsService = followsService;
            this.liftsService = liftsService;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFollowInputModel model)
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

            if (follows.Count() >= GlobalConstants.LimitFollowLifts || isTrue)
            {
                return this.RedirectToAction("All");
            }

            var follow = new Follow()
            {
                ApplicationUserId = userId,
                LiftId = lift.Id,
            };

            await this.followRepository.AddAsync(follow);
            await this.followRepository.SaveChangesAsync();

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var userId = this.userManager.GetUserId(this.User);
            var lifts = this.followsService.GetAllFollowsForUserViewModel(userId);

            var viewModel = new AllFollowLiftsViewModel()
            {
                Lifts = lifts,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var userId = this.userManager.GetUserId(this.User);

            var followLift = this.followRepository.All().FirstOrDefault(x => x.ApplicationUserId == userId && x.LiftId == id);

            this.followRepository.Delete(followLift);
            await this.followRepository.SaveChangesAsync();

            return this.RedirectToAction("All");
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.followsService.GetLiftWithId(id);

            return this.View(viewModel);
        }

        public IActionResult InspectDetails(string id)
        {
            var viewModel = this.followsService.GetInspectWithId(id);

            return this.View(viewModel);
        }
    }
}
