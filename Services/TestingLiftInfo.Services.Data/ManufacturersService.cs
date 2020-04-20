﻿namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;
    using TestingLiftInfo.Web.ViewModels.Administration.Manufacturers;

    public class ManufacturersService : IManufacturersService
    {
        private readonly IDeletableEntityRepository<Manufacturer> manufacturerRepository;

        public ManufacturersService(IDeletableEntityRepository<Manufacturer> manufacturerRepository)
        {
            this.manufacturerRepository = manufacturerRepository;
        }

        public async Task<bool> CreateAsync(string name)
        {
            var currentManufacturer = this.manufacturerRepository
                .All()
                .FirstOrDefault(x => x.Name == name);

            var isCreate = false;

            if (currentManufacturer == null)
            {
                var manufacturer = new Manufacturer { Name = name };

                await this.manufacturerRepository.AddAsync(manufacturer);
                await this.manufacturerRepository.SaveChangesAsync();

                isCreate = true;
            }

            return isCreate;
        }

        public ICollection<Manufacturer> GetAllManufacturers()
        {
            var manufacturers = this.manufacturerRepository
                 .All()
                 .OrderBy(x => x.Name)
                 .ToList();

            return manufacturers;
        }

        public ICollection<ManufacturerDetailViewModel> GetAllManufacturersForViewModel()
        {
            var manufacturers = this.manufacturerRepository
                .All()
                .OrderBy(x => x.Name)
                .To<ManufacturerDetailViewModel>()
                .ToList();

            return manufacturers;
        }
    }
}
