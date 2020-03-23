namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.CodeAnalysis.Operations;
    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Data;
    using TestingLiftInfo.Web.ViewModels.Administration.SupportCompanies;

    public class SupportCompanyController : AdministrationController
    {
        private readonly IDeletableEntityRepository<SupportCompany> repository;
        private readonly ISupportCompanyService service;

        public SupportCompanyController(IDeletableEntityRepository<SupportCompany> repository, ISupportCompanyService service)
        {
            this.repository = repository;
            this.service = service;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            var currentCompany = this.repository.All().FirstOrDefault(x => x.Name == name);

            if (currentCompany == null)
            {
                var company = new SupportCompany { Name = name };

                await this.repository.AddAsync(company);
                await this.repository.SaveChangesAsync();
            }

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var companies = this.service.GetAllCompanies();
            var viewModel = new GetAllCompanyViewModel { SupportCompanies = companies };

            return this.View(viewModel);
        }
    }
}
