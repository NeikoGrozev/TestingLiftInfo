﻿namespace TestingLiftInfo.Web.ViewModels.Administration.Cities
{
    using System.Collections.Generic;

    using TestingLiftInfo.Data.Models;

    public class GetAllCityViewModel
    {
        public ICollection<CityDetailViewModel> Cities { get; set; }
    }
}
