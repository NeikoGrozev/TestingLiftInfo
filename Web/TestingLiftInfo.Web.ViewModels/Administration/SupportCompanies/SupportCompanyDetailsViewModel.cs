namespace TestingLiftInfo.Web.ViewModels.Administration.SupportCompanies
{
    using System.Collections.Generic;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;

    public class SupportCompanyDetailsViewModel : IMapFrom<SupportCompany>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Lift> Lifts { get; set; }
    }
}
