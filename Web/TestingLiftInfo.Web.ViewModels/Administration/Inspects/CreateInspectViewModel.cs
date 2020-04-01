namespace TestingLiftInfo.Web.ViewModels.Administration.Inspects
{
    using System.ComponentModel.DataAnnotations;

    using TestingLiftInfo.Web.Infrastructure;

    public class CreateInspectViewModel
    {
        [Required]
        public string InspectTypeId { get; set; }

        [Required]
        public string LiftId { get; set; }

        [Required]
        public string SupportCompanyId { get; set; }

        [Required]
        public string Notes { get; set; }

        [Required]
        public string Prescriptions { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
