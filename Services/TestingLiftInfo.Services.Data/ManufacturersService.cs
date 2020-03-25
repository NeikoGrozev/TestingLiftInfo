namespace TestingLiftInfo.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;
    using TestingLiftInfo.Web.ViewModels.Administration.Manufacturers;

    public class ManufacturersService : IManufacturersService
    {
        private readonly IDeletableEntityRepository<Manufacturer> repository;

        public ManufacturersService(IDeletableEntityRepository<Manufacturer> repository)
        {
            this.repository = repository;
        }

        public ICollection<Manufacturer> GetAllManufacturers()
        {
            var manufacturers = this.repository
                 .All()
                 .OrderBy(x => x.Name)
                 .ToList();

            return manufacturers;
        }

        public ICollection<ManufacturerDetailViewModel> GetAllManufacturersForViewModel()
        {
            var manufacturers = this.repository
                .All()
                .OrderBy(x => x.Name)
                .To<ManufacturerDetailViewModel>()
                .ToList();

            return manufacturers;
        }
    }
}
