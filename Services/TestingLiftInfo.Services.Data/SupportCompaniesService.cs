namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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

        public async Task CreateAsync(string name)
        {
            var currentCompany = this.repository
                .All()
                .FirstOrDefault(x => x.Name == name);

            if (currentCompany == null)
            {
                var company = new SupportCompany
                {
                    Name = name,
                };

                await this.repository.AddAsync(company);
                await this.repository.SaveChangesAsync();
            }
        }

        public ICollection<SupportCompany> GetAll()
        {
            var companies = this.repository
              .All()
              .OrderBy(x => x.Name)
              .ToList();

            return companies;
        }

        public ICollection<SupportCompanyDetailsViewModel> GetAllCompanies()
        {
            var companies = this.repository
                .All()
                .OrderBy(x => x.Name)
                .To<SupportCompanyDetailsViewModel>()
                .ToList();

            return companies;
        }
    }
}
