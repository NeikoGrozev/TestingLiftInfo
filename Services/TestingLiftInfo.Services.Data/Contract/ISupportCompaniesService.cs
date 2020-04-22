namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Web.ViewModels.Administration.SupportCompanies;

    public interface ISupportCompaniesService
    {
        Task<bool> CreateAsync(string name);

        Task<ICollection<SupportCompany>> GetAll();

        Task<ICollection<SupportCompanyDetailsViewModel>> GetAllCompanies();
    }
}
