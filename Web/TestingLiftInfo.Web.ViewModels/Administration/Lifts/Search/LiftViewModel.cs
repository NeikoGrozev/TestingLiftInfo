namespace TestingLiftInfo.Web.ViewModels.Administration.Lifts
{
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Data.Models.Enumerations;
    using TestingLiftInfo.Services.Mapping;

    public class LiftViewModel : IMapFrom<Lift>
    {
        public string Id { get; set; }

        public LiftType LiftType { get; set; }

        public int NumberOfStops { get; set; }

        public int Capacity { get; set; }

        public DoorType DoorType { get; set; }

        public string RegistrationNumber { get; set; }

        public string ManufacturerId { get; set; }

        public string ManufacturerName { get; set; }

        public string CityId { get; set; }

        public string CityName { get; set; }

        public string Address { get; set; }

        public string SupportCompanyId { get; set; }

        public string SupportCompanyName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
