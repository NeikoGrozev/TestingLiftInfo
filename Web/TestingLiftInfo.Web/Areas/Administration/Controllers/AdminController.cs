namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using TestingLiftInfo.Services.Data;
    using TestingLiftInfo.Web.ViewModels.Administration.Dashboard;

    public class AdminController : AdministrationController
    {
        private readonly ISettingsService settingsService;

        public AdminController(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { SettingsCount = this.settingsService.GetCount(), };
            return this.View(viewModel);
        }
    }
}
