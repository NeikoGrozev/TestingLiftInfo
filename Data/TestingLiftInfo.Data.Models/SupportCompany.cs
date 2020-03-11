namespace TestingLiftInfo.Data.Models
{
    using System;
    using System.Collections.Generic;

    using TestingLiftInfo.Data.Common.Models;

    public class SupportCompany : BaseDeletableModel<string>
    {
        public SupportCompany()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Lifts = new HashSet<Lift>();
            this.Inspects = new HashSet<Inspect>();
        }

        public string Name { get; set; }

        public virtual ICollection<Lift> Lifts { get; set; }

        public virtual ICollection<Inspect> Inspects { get; set; }
    }
}
