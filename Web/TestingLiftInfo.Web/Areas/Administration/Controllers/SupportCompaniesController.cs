namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TestingLiftInfo.Common;
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
        public async Task<IActionResult> Create([FromForm] CreateSupportCompanyInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var isCreate = await this.supportCompanyService.CreateAsync(model.Name);

            if (isCreate)
            {
                this.TempData["CreateSupportCompany"] = $"Поддържащата фирма {model.Name} е добавена към списъка!";
            }

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            var companies = await this.supportCompanyService.GetAllCompanies();
            var viewModel = new GetAllSupportCompaniesViewModel
            {
                SupportCompanies = companies,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var company = await this.supportCompanyService.GetCurrentSupportCompany(id);

            var viewModel = new EditSupportCompanyViewModel
            {
                SupportCompanyDetails = company,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] EditSupportCompanyViewModel model)
        {
            var isCreate = false;

            if (GlobalConstants.Editors.Contains(this.User.Identity.Name))
            {
                isCreate = await this.supportCompanyService.EditSupportCompany(model.Id, model.Name);
            }

            if (isCreate)
            {
                this.TempData["EditSupportCompany"] = $"Поддържащата фирма {model.Name} е редактирана!";
            }

            return this.RedirectToAction("All");
        }
    }
}
