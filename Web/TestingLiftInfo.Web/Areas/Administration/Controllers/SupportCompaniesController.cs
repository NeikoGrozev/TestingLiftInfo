namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Create([FromForm]CreateSupportCompanyInputModel model)
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
