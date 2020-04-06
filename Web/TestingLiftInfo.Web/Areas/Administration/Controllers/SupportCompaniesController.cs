namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Data;
    using TestingLiftInfo.Web.ViewModels.Administration.SupportCompanies;

    public class SupportCompaniesController : AdministrationController
    {
        private readonly ISupportCompaniesService supportCompanyService;

        public SupportCompaniesController(ISupportCompaniesService service)
        {
            this.supportCompanyService = service;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateSupportCompanyViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.supportCompanyService.CreateAsync(model.Name);

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var companies = this.supportCompanyService.GetAllCompanies();
            var viewModel = new GetAllSupportCompaniesViewModel
            {
                SupportCompanies = companies,
            };

            return this.View(viewModel);
        }
    }
}
