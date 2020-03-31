namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Web.ViewModels.Administration.SupportCompanies;

    public interface ISupportCompaniesService
    {
        ICollection<SupportCompany> GetAll();

        ICollection<SupportCompanyDetailsViewModel> GetAllCompanies();
    }
}
