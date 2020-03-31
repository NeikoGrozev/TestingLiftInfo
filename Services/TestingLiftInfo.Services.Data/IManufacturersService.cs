namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Web.ViewModels.Administration.Manufacturers;

    public interface IManufacturersService
    {
        ICollection<Manufacturer> GetAllManufacturers();

        ICollection<ManufacturerDetailViewModel> GetAllManufacturersForViewModel();
    }
}
