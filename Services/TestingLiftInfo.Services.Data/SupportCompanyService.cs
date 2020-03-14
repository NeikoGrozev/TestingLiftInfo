namespace TestingLiftInfo.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Web.ViewModels.Administration.SupportCompanies;

    public class SupportCompanyService : ISupportCompanyService
    {
        private readonly IDeletableEntityRepository<SupportCompany> repository;

        public SupportCompanyService(IDeletableEntityRepository<SupportCompany> repository)
        {
            this.repository = repository;
        }

        public GetAllCompanyViewModel GetAllCompanies()
        {
            var companies = this.repository.All().OrderBy(x => x.Name).ToList();
            var viewModel = new GetAllCompanyViewModel { SupportCompanies = companies };

            return viewModel;
        }
    }
}
