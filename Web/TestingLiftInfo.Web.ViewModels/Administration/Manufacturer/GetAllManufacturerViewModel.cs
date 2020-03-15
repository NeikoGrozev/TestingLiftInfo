namespace TestingLiftInfo.Web.ViewModels.Administration.Manufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TestingLiftInfo.Data.Models;

    public class GetAllManufacturerViewModel
    {
        public IEnumerable<Manufacturer> Manufacturers { get; set; }
    }
}
