namespace TestingLiftInfo.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TestingLiftInfo.Data.Common.Models;

    public class Inspect : BaseDeletableModel<string>
    {
        public Inspect()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string InspectTypeId { get; set; }

        public virtual InspectType InspectType { get; set; }

        [Required]
        public string LiftId { get; set; }

        public virtual Lift Lift { get; set; }

        [Required]
        public string SupportCompanyId { get; set; }

        public virtual SupportCompany SupportCompany { get; set; }

        [Required]
        public string Notes { get; set; }

        [Required]
        public string Prescriptions { get; set; }
    }
}
