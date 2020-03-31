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
        private readonly IDeletableEntityRepository<SupportCompany> repository;
        private readonly ISupportCompaniesService service;

        public SupportCompaniesController(IDeletableEntityRepository<SupportCompany> repository, ISupportCompaniesService service)
        {
            this.repository = repository;
            this.service = service;
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

            var currentCompany = this.repository.All().FirstOrDefault(x => x.Name == model.Name);

            if (currentCompany == null)
            {
                var company = new SupportCompany { Name = model.Name };

                await this.repository.AddAsync(company);
                await this.repository.SaveChangesAsync();
            }

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var companies = this.service.GetAllCompanies();
            var viewModel = new GetAllSupportCompaniesViewModel
            {
                SupportCompanies = companies,
            };

            return this.View(viewModel);
        }
    }
}
