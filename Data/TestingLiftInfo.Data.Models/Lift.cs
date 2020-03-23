﻿namespace TestingLiftInfo.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TestingLiftInfo.Data.Common.Models;
    using TestingLiftInfo.Data.Models.Enumerations;

    public class Lift : BaseDeletableModel<string>
    {
        public Lift()
        {
            this.Id = Guid.NewGuid().ToString();
        }

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


        public string ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public string CityId { get; set; }

        public virtual City City { get; set; }

        [Required]
        public string Address { get; set; }

        public string SupportCompanyId { get; set; }

        public virtual SupportCompany SupportCompany { get; set; }
    }
}
