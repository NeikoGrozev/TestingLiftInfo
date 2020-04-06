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

        [Required(ErrorMessage = "Полето е задължително!!!")]
        [StringLength(1000, ErrorMessage = "{0}те трябва да бъдът дълги, най-малко {2} и максимум {1} символа.", MinimumLength = 5)]
        [Display(Name = "Забележки")]
        public string Notes { get; set; }

        [Required(ErrorMessage = "Полето е задължително!!!")]
        [StringLength(1000, ErrorMessage = "{0}та трябва да бъдът дълги, най-малко {2} и максимум {1} символа.", MinimumLength = 5)]
        [Display(Name = "Предписания")]
        public string Prescriptions { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
