namespace TestingLiftInfo.Web.ViewModels.Administration.SupportCompanies
{
    using System.Collections.Generic;

    using TestingLiftInfo.Data.Models;

    public class GetAllCompanyViewModel
    {
        public IEnumerable<SupportCompany> SupportCompanies { get; set; }
    }
}
