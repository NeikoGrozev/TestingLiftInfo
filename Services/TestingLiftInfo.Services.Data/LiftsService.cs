namespace TestingLiftInfo.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;
    using TestingLiftInfo.Web.ViewModels.Administration.Lifts;

    public class LiftsService : ILiftsService
    {
        private readonly IDeletableEntityRepository<Lift> liftRepository;

        public LiftsService(IDeletableEntityRepository<Lift> liftRepository)
        {
            this.liftRepository = liftRepository;
        }

        public ICollection<LiftViewModel> GetAllLifts()
        {
            var lifts = this.liftRepository
                .All()
                .OrderBy(x => x.RegistrationNumber)
                .To<LiftViewModel>()
                .ToList();

            return lifts;
        }

        public LiftDetailViewModel GetCurrentLift(string id)
        {
            var lift = this.liftRepository
                .All()
                .Where(x => x.Id == id)
                .To<LiftDetailViewModel>()
                .FirstOrDefault();

            return lift;
        }

        public ICollection<LiftViewModel> SearchRegistrationCriteria(string registationNumber)
        {
            var lifts = this.liftRepository
                 .All()
                 .Where(x => x.RegistrationNumber.Contains(registationNumber))
                 .To<LiftViewModel>()
                 .OrderBy(x => x.RegistrationNumber)
                 .ToList();

            return lifts;
        }

        public ICollection<LiftViewModel> SearchRegisAndManufCriteria(string registationNumber, string manufacturer)
        {
            var lifts = this.liftRepository
                .All()
                .Where(x => x.RegistrationNumber.Contains(registationNumber) &&
                        x.Manufacturer.Name.Contains(manufacturer))
                .To<LiftViewModel>()
                .OrderBy(x => x.RegistrationNumber)
                .ToList();

            return lifts;
        }

        public ICollection<LiftViewModel> SearchRegisAndCityCriteria(string registationNumber, string city)
        {
            var lifts = this.liftRepository
               .All()
               .Where(x => x.RegistrationNumber.Contains(registationNumber) &&
                       x.City.Name.Contains(city))
               .To<LiftViewModel>()
               .OrderBy(x => x.RegistrationNumber)
               .ToList();

            return lifts;
        }

        public ICollection<LiftViewModel> SearchManufacturerCriteria(string manufacturer)
        {
            var lifts = this.liftRepository
                 .All()
                 .Where(x => x.Manufacturer.Name.Contains(manufacturer))
                 .To<LiftViewModel>()
                 .OrderBy(x => x.RegistrationNumber)
                 .ToList();

            return lifts;
        }

        public ICollection<LiftViewModel> SearchManufAndCityCriteria(string manufacturer, string city)
        {
            var lifts = this.liftRepository
                 .All()
                 .Where(x => x.Manufacturer.Name.Contains(manufacturer) &&
                         x.City.Name.Contains(city))
                 .To<LiftViewModel>()
                 .OrderBy(x => x.RegistrationNumber)
                 .ToList();

            return lifts;
        }

        public ICollection<LiftViewModel> SearchCityCriteria(string city)
        {
            var lifts = this.liftRepository
                .All()
                .Where(x => x.City.Name.Contains(city))
                .To<LiftViewModel>()
                .OrderBy(x => x.RegistrationNumber)
                .ToList();

            return lifts;
        }

        public ICollection<LiftViewModel> GetAllSearchCriteria(string registationNumber, string manufacturer, string city)
        {
            var lifts = this.liftRepository
                .All()
                .Where(x => x.RegistrationNumber.Contains(registationNumber) &&
                        x.Manufacturer.Name.Contains(manufacturer) &&
                        x.City.Name.Contains(city))
                .To<LiftViewModel>()
                .OrderBy(x => x.RegistrationNumber)
                .ToList();

            return lifts;
        }
    }
}
