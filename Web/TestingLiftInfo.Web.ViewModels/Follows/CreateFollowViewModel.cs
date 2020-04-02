namespace TestingLiftInfo.Web.ViewModels.Follows
{
    using System.ComponentModel.DataAnnotations;

    using TestingLiftInfo.Web.Infrastructure;

    public class CreateFollowViewModel
    {
        [Required]
        public string RegistrationNumber { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
