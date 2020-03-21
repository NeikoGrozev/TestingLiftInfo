namespace TestingLiftInfo.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Web.ViewModels.Administration.Manufacturer;

    public class ManufacturerService : IManufacturerService
    {
        private readonly IDeletableEntityRepository<Manufacturer> repository;

        public ManufacturerService(IDeletableEntityRepository<Manufacturer> repository)
        {
            this.repository = repository;
        }

        public ICollection<Manufacturer> GEtAllManufacturers()
        {
            var manufacturers = this.repository.All().OrderBy(x => x.Name).ToList();

            return manufacturers;
        }
    }
}
