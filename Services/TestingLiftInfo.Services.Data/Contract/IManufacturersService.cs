namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Web.ViewModels.Administration.Manufacturers;

    public interface IManufacturersService
    {
        Task<bool> CreateAsync(string name);

        ICollection<Manufacturer> GetAllManufacturers();

        ICollection<ManufacturerDetailViewModel> GetAllManufacturersForViewModel();
    }
}
