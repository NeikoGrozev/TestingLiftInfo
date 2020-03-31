namespace TestingLiftInfo.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TestingLiftInfo.Data.Common.Models;

    public class InspectType : BaseDeletableModel<string>
    {
        public InspectType()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Inspects = new HashSet<Inspect>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Inspect> Inspects { get; set; }
    }
}
