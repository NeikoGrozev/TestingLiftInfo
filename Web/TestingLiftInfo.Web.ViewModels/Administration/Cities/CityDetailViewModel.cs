namespace TestingLiftInfo.Web.ViewModels.Administration.Cities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;

    public class CityDetailViewModel : IMapFrom<City>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Lift> Lifts { get; set; }
    }
}
