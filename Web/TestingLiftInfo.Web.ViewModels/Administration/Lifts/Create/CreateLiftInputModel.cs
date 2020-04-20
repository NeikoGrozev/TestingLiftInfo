namespace TestingLiftInfo.Web.ViewModels.Administration.Lifts
{
    using System.ComponentModel.DataAnnotations;

    using TestingLiftInfo.Data.Models.Enumerations;
    using TestingLiftInfo.Web.Infrastructure;

    public class CreateLiftInputModel
    {
        [Required]
        public LiftType LiftType { get; set; }

        [Required]
        public int NumberOfStops { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public DoorType DoorType { get; set; }

        [Required]
        public string ManufacturerId { get; set; }

        [Required]
        public string ProductionNumber { get; set; }

        [Required]
        public string CityId { get; set; }

        [Required]
        public string Address { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
