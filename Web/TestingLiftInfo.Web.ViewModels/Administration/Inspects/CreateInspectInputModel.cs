namespace TestingLiftInfo.Web.ViewModels.Administration.Inspects
{
    using System.ComponentModel.DataAnnotations;

    using TestingLiftInfo.Web.Infrastructure;

    public class CreateInspectInputModel
    {
        [Required]
        public string InspectTypeId { get; set; }

        [Required]
        public string LiftId { get; set; }

        [Required]
        public string SupportCompanyId { get; set; }

        [Required(ErrorMessage = "Полето е задължително!!!")]
        [Display(Name = "Забележки")]
        public string Notes { get; set; }

        [Required(ErrorMessage = "Полето е задължително!!!")]
        [Display(Name = "Предписания")]
        public string Prescriptions { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
