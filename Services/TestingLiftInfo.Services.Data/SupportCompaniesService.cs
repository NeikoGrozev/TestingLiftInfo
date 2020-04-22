namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;
    using TestingLiftInfo.Web.ViewModels.Administration.SupportCompanies;

    public class SupportCompaniesService : ISupportCompaniesService
    {
        private readonly IDeletableEntityRepository<SupportCompany> repository;

        public SupportCompaniesService(IDeletableEntityRepository<SupportCompany> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> CreateAsync(string name)
        {
            var currentCompany = this.repository
                .All()
                .FirstOrDefault(x => x.Name == name);

            var isCreate = false;

            if (currentCompany == null && !string.IsNullOrWhiteSpace(name))
            {
                var company = new SupportCompany
                {
                    Name = name,
                };

                await this.repository.AddAsync(company);
                await this.repository.SaveChangesAsync();

                isCreate = true;
            }

            return isCreate;
        }

        public async Task<ICollection<SupportCompany>> GetAll()
        {
            var companies = await this.repository
              .All()
              .OrderBy(x => x.Name)
              .ToListAsync();

            return companies;
        }

        public async Task<ICollection<SupportCompanyDetailsViewModel>> GetAllCompanies()
        {
            var companies = await this.repository
                .All()
                .OrderBy(x => x.Name)
                .To<SupportCompanyDetailsViewModel>()
                .ToListAsync();

            return companies;
        }
    }
}
