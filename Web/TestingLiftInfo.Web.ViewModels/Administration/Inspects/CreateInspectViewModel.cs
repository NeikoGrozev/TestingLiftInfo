namespace TestingLiftInfo.Web.ViewModels.Administration.Inspects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using TestingLiftInfo.Data.Models;

    public class CreateInspectViewModel
    {
        //public string Id { get; set; }

        [Required]
        public string InspectTypeId { get; set; }

        // public virtual InspectType InspectType { get; set; }

        [Required]
        public string LiftId { get; set; }

        //public virtual Lift Lift { get; set; }

        [Required]
        public string SupportCompanyId { get; set; }

        //public virtual SupportCompany SupportCompany { get; set; }

        [Required]
        public string Notes { get; set; }

        [Required]
        public string Prescriptions { get; set; }
    }
}
