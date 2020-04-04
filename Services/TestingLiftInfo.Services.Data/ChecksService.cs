namespace TestingLiftInfo.Services.Data
{
    using System;
    using System.Linq;

    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;
    using TestingLiftInfo.Web.ViewModels.Checks;

    public class ChecksService : IChecksService
    {
        private readonly IDeletableEntityRepository<Lift> liftRepository;

        public ChecksService(IDeletableEntityRepository<Lift> liftRepository)
        {
            this.liftRepository = liftRepository;
        }

        public DateTime? GetValidInspect(string registrationNumber)
        {
            var inspects = this.liftRepository
                .All()
                .Where(x => x.RegistrationNumber == registrationNumber)
                .To<CheckValidateInspectionViewModel>()
                .FirstOrDefault();

            DateTime? currentInspect = null;

            if (inspects != null)
            {
                currentInspect = inspects.Inspects
                .Select(x => x.CreatedOn)
                .FirstOrDefault()
                .AddDays(1);
            }

            return currentInspect;
        }
    }
}
