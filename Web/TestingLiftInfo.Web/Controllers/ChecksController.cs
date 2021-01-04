namespace TestingLiftInfo.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using TestingLiftInfo.Services.Data;
    using TestingLiftInfo.Web.ViewModels.Checks;

    public class ChecksController : BaseController
    {
        private readonly IChecksService checksService;

        public ChecksController(IChecksService checksService)
        {
            this.checksService = checksService;
        }

        [HttpPost]
        public async Task<IActionResult> ValidInspect(InputCheckViewModel model)
        {
            if (model.RegistrationNumber == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            var date = await this.checksService.GetValidInspect(model.RegistrationNumber);

            var viewModel = new CheckOutputViewModel()
            {
                RegistrationNumber = model.RegistrationNumber,
                Date = date,
            };

            return this.View(viewModel);
        }
    }
}
