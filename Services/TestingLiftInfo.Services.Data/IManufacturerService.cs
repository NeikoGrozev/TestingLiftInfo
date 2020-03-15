namespace TestingLiftInfo.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TestingLiftInfo.Web.ViewModels.Administration.Manufacturer;

    public interface IManufacturerService
    {
        GetAllManufacturerViewModel GEtAllManufacturers();
    }
}
