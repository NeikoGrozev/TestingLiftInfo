namespace TestingLiftInfo.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TestingLiftInfo.Data.Common.Models;
    using TestingLiftInfo.Data.Models.Enumerations;

    public class Lift : BaseDeletableModel<string>
    {
        public Lift()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Inspects = new HashSet<Inspect>();
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

        [Required]
        public string ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        public string ProductionNumber { get; set; }

        [Required]
        public string CityId { get; set; }

        public virtual City City { get; set; }

        [Required]
        public string Address { get; set; }

        public string SupportCompanyId { get; set; }

        public virtual SupportCompany SupportCompany { get; set; }

        public virtual ICollection<Inspect> Inspects { get; set; }
    }
}
