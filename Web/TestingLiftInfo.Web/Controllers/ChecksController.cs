namespace TestingLiftInfo.Web.Controllers
{
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
        public IActionResult ValidInspect(InputCheckViewModel model)
        {
            var date = this.checksService.GetValidInspect(model.RegistrationNumber);

            var viewModel = new CheckOutputViewModel()
            {
                RegistrationNumber = model.RegistrationNumber,
                Date = date,
            };

            return this.View(viewModel);
        }
    }
}
