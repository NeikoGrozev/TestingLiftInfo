namespace TestingLiftInfo.Web.ViewModels.Administration.Cities
{
    using System.ComponentModel.DataAnnotations;

    using TestingLiftInfo.Web.Infrastructure;

    public class CreateCityViewModel
    {
        [Required(ErrorMessage = "Името е задължително!!!")]
        [StringLength(50, ErrorMessage = "{0}то трябва да бъде дълго, най-малко {2} и максимум {1} символа.", MinimumLength = 3)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
