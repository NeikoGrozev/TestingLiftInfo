namespace TestingLiftInfo.Web.ViewModels.Administration.InspectTypes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;

    public class InspectTypeDetailViewModel : IMapFrom<InspectType>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Inspect> Inspects { get; set; }
    }
}
