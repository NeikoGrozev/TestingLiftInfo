namespace TestingLiftInfo.Web.ViewModels.Administration.Lifts.Edit
{
    using System.Collections.Generic;

    using TestingLiftInfo.Data.Models;

    public class EditManufactureAndCityViewModel
    {
        public ICollection<Manufacturer> Manufacturers { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
