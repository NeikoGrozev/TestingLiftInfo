namespace TestingLiftInfo.Web.ViewModels.Administration.Lifts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TestingLiftInfo.Data.Models;

    public class LiftInputDataViewModel
    {
        public ICollection<Manufacturer> Manufacturers { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
