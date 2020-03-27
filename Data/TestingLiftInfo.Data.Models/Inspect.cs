namespace TestingLiftInfo.Data.Models
{
    using System;

    using TestingLiftInfo.Data.Common.Models;

    public class Inspect : BaseDeletableModel<string>
    {
        public Inspect()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string InspectTypeId { get; set; }

        public virtual InspectType InspectType { get; set; }

        public string LiftId { get; set; }

        public virtual Lift Lift { get; set; }

        public string SupportCompanyId { get; set; }

        public virtual SupportCompany SupportCompany { get; set; }

        public string Notes { get; set; }

        public string Prescriptions { get; set; }
    }
}
