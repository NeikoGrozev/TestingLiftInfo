namespace TestingLiftInfo.Web.ViewModels.Administration.Lifts
{
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Data.Models.Enumerations;
    using TestingLiftInfo.Web.ViewModels.Administration.Cities;
    using TestingLiftInfo.Web.ViewModels.Administration.Manufacturers;
    using TestingLiftInfo.Web.ViewModels.Administration.SupportCompanies;

    public class CreateLiftViewModel
    {
        [Required]
        public LiftType LiftType { get; set; }

        [Required]
        public int NumberOfStops { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public DoorType DoorType { get; set; }

        [Required]
        public string RegistrationNumber { get; set; }

        [Required]
        public ICollection<Manufacturer> Manufacturers { get; set; }

        [Required]
        public ICollection<City> Cities { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public ICollection<SupportCompany> SupportCompanies { get; set; }
    }
}
