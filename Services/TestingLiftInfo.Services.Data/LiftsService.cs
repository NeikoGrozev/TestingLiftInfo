namespace TestingLiftInfo.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Data.Models.Enumerations;
    using TestingLiftInfo.Services.Mapping;
    using TestingLiftInfo.Web.ViewModels.Administration.Lifts;

    public class LiftsService : ILiftsService
    {
        private readonly IDeletableEntityRepository<Lift> liftRepository;

        public LiftsService(IDeletableEntityRepository<Lift> liftRepository)
        {
            this.liftRepository = liftRepository;
        }

        public async Task<bool> CreateAsync(string userId, LiftType liftType, int numberOfStops, int capacity, DoorType doorType, string manufacturerId, string productionNumber, string cityId, string address, string latitude, string longitude)
        {
            var currentLift = this.liftRepository.All().FirstOrDefault(x => x.ProductionNumber == productionNumber);

            var isCreate = false;

            if (currentLift == null)
            {
                var currentNumber = (this.liftRepository.AllWithDeleted().Count() + 1).ToString();

                var lift = new Lift
                {
                    ApplicationUserId = userId,
                    RegistrationNumber = "777АС" + currentNumber,
                    LiftType = liftType,
                    NumberOfStops = numberOfStops,
                    Capacity = capacity,
                    DoorType = doorType,
                    ManufacturerId = manufacturerId,
                    ProductionNumber = productionNumber,
                    CityId = cityId,
                    Address = address,
                    Latitude = latitude,
                    Longitude = longitude,
                };

                await this.liftRepository.AddAsync(lift);
                await this.liftRepository.SaveChangesAsync();

                isCreate = true;
            }

            return isCreate;
        }

        public async Task<ICollection<LiftViewModel>> GetAllLifts(int page, int numberOfPrintLifts)
        {
            var lifts = await this.liftRepository
                .All()
                .To<LiftViewModel>()
                .OrderBy(x => x.CreatedOn)
                .Skip((page - 1) * numberOfPrintLifts)
                .Take(numberOfPrintLifts)
                .ToListAsync();

            return lifts;
        }

        public int GetCountAllActiveLifts()
        {
            var count = this.liftRepository.All().Count();

            return count;
        }

        public Lift GetLift(string id)
        {
            var lift = this.liftRepository
                 .All()
                 .Where(x => x.Id == id)
                 .FirstOrDefault();

            return lift;
        }

        public async Task<LiftDetailViewModel> GetCurrentLift(string id)
        {
            var lift = await this.liftRepository
                .AllWithDeleted()
                .Where(x => x.Id == id)
                .To<LiftDetailViewModel>()
                .FirstOrDefaultAsync();

            return lift;
        }

        public async Task<LiftEditDataViewModel> GetCurrentLiftForEdit(string id)
        {
            var lift = await this.liftRepository
                .AllWithDeleted()
                .Where(x => x.Id == id)
                .To<LiftEditDataViewModel>()
                .FirstOrDefaultAsync();

            int liftTypeNumber = (int)Enum.Parse(lift.LiftType.GetType(), lift.LiftType.ToString());
            lift.LiftTypeNumber = liftTypeNumber;

            int doorTypeNumber = (int)Enum.Parse(lift.DoorType.GetType(), lift.DoorType.ToString());
            lift.DoorTypeNumber = doorTypeNumber;

            return lift;
        }

        public async Task<ICollection<LiftViewModel>> SearchIsDeletedCriteria(bool isDeleted)
        {
            var lifts = await this.liftRepository
                .AllWithDeleted()
                .Where(x => x.IsDeleted == isDeleted)
                .To<LiftViewModel>()
                .OrderBy(x => x.CreatedOn)
                .ToListAsync();

            return lifts;
        }

        public async Task<ICollection<LiftViewModel>> SearchRegistrationCriteria(string registationNumber, bool isDeleted)
        {
            var lifts = await this.liftRepository
                 .AllWithDeleted()
                 .Where(x => x.RegistrationNumber.Contains(registationNumber) &&
                            x.IsDeleted == isDeleted)
                 .To<LiftViewModel>()
                 .OrderBy(x => x.CreatedOn)
                 .ToListAsync();

            return lifts;
        }

        public async Task<ICollection<LiftViewModel>> SearchRegisAndManufCriteria(string registationNumber, string manufacturer, bool isDeleted)
        {
            var lifts = await this.liftRepository
                .AllWithDeleted()
                .Where(x => x.RegistrationNumber.Contains(registationNumber) &&
                        x.Manufacturer.Name.Contains(manufacturer) &&
                        x.IsDeleted == isDeleted)
                .To<LiftViewModel>()
                .OrderBy(x => x.CreatedOn)
                .ToListAsync();

            return lifts;
        }

        public async Task<ICollection<LiftViewModel>> SearchRegisAndCityCriteria(string registationNumber, string cityOrAddress, bool isDeleted)
        {
            var lifts = await this.liftRepository
               .AllWithDeleted()
               .Where(x => x.RegistrationNumber.Contains(registationNumber) &&
                       (x.City.Name.Contains(cityOrAddress) || x.Address.Contains(cityOrAddress)) &&
                       x.IsDeleted == isDeleted)
               .To<LiftViewModel>()
               .OrderBy(x => x.CreatedOn)
               .ToListAsync();

            return lifts;
        }

        public async Task<ICollection<LiftViewModel>> SearchManufacturerCriteria(string manufacturer, bool isDeleted)
        {
            var lifts = await this.liftRepository
                 .AllWithDeleted()
                 .Where(x => x.Manufacturer.Name.Contains(manufacturer) &&
                         x.IsDeleted == isDeleted)
                 .To<LiftViewModel>()
                 .OrderBy(x => x.CreatedOn)
                 .ToListAsync();

            return lifts;
        }

        public async Task<ICollection<LiftViewModel>> SearchManufAndCityCriteria(string manufacturer, string cityOrAddress, bool isDeleted)
        {
            var lifts = await this.liftRepository
                 .AllWithDeleted()
                 .Where(x => x.Manufacturer.Name.Contains(manufacturer) &&
                          (x.City.Name.Contains(cityOrAddress) || x.Address.Contains(cityOrAddress)) &&
                          x.IsDeleted == isDeleted)
                 .To<LiftViewModel>()
                 .OrderBy(x => x.CreatedOn)
                 .ToListAsync();

            return lifts;
        }

        public async Task<ICollection<LiftViewModel>> SearchCityCriteria(string cityOrAddress, bool isDeleted)
        {
            var lifts = await this.liftRepository
                .AllWithDeleted()
                .Where(x => (x.City.Name.Contains(cityOrAddress) || x.Address.Contains(cityOrAddress)) &&
                         x.IsDeleted == isDeleted)
                .To<LiftViewModel>()
                .OrderBy(x => x.CreatedOn)
                .ToListAsync();

            return lifts;
        }

        public async Task<ICollection<LiftViewModel>> GetAllSearchCriteria(string registationNumber, string manufacturer, string cityOrAddress, bool isDeleted)
        {
            var lifts = await this.liftRepository
                .AllWithDeleted()
                .Where(x => x.RegistrationNumber.Contains(registationNumber) &&
                        x.Manufacturer.Name.Contains(manufacturer) &&
                         (x.City.Name.Contains(cityOrAddress) || x.Address.Contains(cityOrAddress)) &&
                         x.IsDeleted == isDeleted)
                .To<LiftViewModel>()
                .OrderBy(x => x.CreatedOn)
                .ToListAsync();

            return lifts;
        }

        public async Task AddSupportCompany(string liftId, string supportCompanyId)
        {
            var lift = this.liftRepository.All().Where(x => x.Id == liftId).FirstOrDefault();
            lift.SupportCompanyId = supportCompanyId;

            await this.liftRepository.SaveChangesAsync();
        }

        public Lift GetLiftWithRegistrationNumber(string regNumber)
        {
            var lift = this.liftRepository
                .All()
                .FirstOrDefault(x => x.RegistrationNumber == regNumber);

            return lift;
        }

        public async Task<bool> EditLift(string userId, string id, LiftType liftType, int numberOfStops, int capacity, DoorType doorType, string manufacturerId, string productionNumber, string cityId, string address, string latitude, string longitude)
        {
            var lift = this.liftRepository.All().FirstOrDefault(x => x.Id == id);
            lift.ApplicationUserId = userId;
            lift.LiftType = liftType;
            lift.NumberOfStops = numberOfStops;
            lift.Capacity = capacity;
            lift.DoorType = doorType;
            lift.ManufacturerId = manufacturerId;
            lift.ProductionNumber = productionNumber;
            lift.CityId = cityId;
            lift.Address = address;
            lift.Latitude = latitude;
            lift.Longitude = longitude;

            this.liftRepository.Update(lift);
            await this.liftRepository.SaveChangesAsync();

            return true;
        }

        public async Task DeleteAsync(string id)
        {
            var lift = this.GetLift(id);

            this.liftRepository.Delete(lift);
            await this.liftRepository.SaveChangesAsync();
        }
    }
}
