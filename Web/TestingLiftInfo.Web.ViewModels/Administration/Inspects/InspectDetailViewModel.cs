namespace TestingLiftInfo.Web.ViewModels.Administration.Inspects
{
    using System;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;

    public class InspectDetailViewModel : IMapFrom<Inspect>
    {
        public string Id { get; set; }

        public string ApplicationUserFirstName { get; set; }

        public string ApplicationUserLastName { get; set; }

        public string InspectTypeId { get; set; }

        public virtual InspectType InspectType { get; set; }

        public string LiftId { get; set; }

        public virtual Lift Lift { get; set; }

        public string SupportCompanyId { get; set; }

        public virtual SupportCompany SupportCompany { get; set; }

        public string Notes { get; set; }

        public string Prescriptions { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
