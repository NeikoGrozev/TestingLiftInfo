namespace TestingLiftInfo.Web.ViewModels.Administration.Manufacturers
{
    using System.Collections.Generic;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;

    public class ManufacturerDetailViewModel : IMapFrom<Manufacturer>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Lift> Lifts { get; set; }
    }
}
