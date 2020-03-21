namespace TestingLiftInfo.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Web.ViewModels.Administration.Manufacturer;

    public interface IManufacturerService
    {
        ICollection<Manufacturer> GEtAllManufacturers();
    }
}
