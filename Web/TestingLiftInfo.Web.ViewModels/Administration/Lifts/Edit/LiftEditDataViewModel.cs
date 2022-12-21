namespace TestingLiftInfo.Web.ViewModels.Administration.Lifts
{
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Data.Models.Enumerations;
    using TestingLiftInfo.Services.Mapping;

    public class LiftEditDataViewModel : IMapFrom<Lift>
    {
        public string Id { get; set; }

        public string ApplicationUserFirstName { get; set; }

        public string ApplicationUserLastName { get; set; }

        public LiftType LiftType { get; set; }

        public int LiftTypeNumber { get; set; }

        public int NumberOfStops { get; set; }

        public int Capacity { get; set; }

        public DoorType DoorType { get; set; }

        public int DoorTypeNumber { get; set; }

        public string RegistrationNumber { get; set; }

        public string ManufacturerId { get; set; }

        public string ManufacturerName { get; set; }

        public string ProductionNumber { get; set; }

        public string CityId { get; set; }

        public string CityName { get; set; }

        public string Address { get; set; }

        public string SupportCompanyId { get; set; }

        public string SupportCompanyName { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}
