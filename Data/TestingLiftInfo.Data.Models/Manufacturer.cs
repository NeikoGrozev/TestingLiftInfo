namespace TestingLiftInfo.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TestingLiftInfo.Data.Common.Models;

    public class Manufacturer : BaseDeletableModel<string>
    {
        public Manufacturer()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Lifts = new HashSet<Lift>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Lift> Lifts { get; set; }
    }
}
