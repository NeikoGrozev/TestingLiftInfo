namespace TestingLiftInfo.Web.ViewModels.Administration.Lifts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public string ManufacturerId { get; set; }

        [Required]
        public string ProductionNumber { get; set; }

        [Required]
        public string CityId { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
