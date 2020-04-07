namespace TestingLiftInfo.Web.ViewModels.Administration.Admin
{
    using System.ComponentModel.DataAnnotations;

    using TestingLiftInfo.Web.Infrastructure;

    public class AddAdminViewModel
    {
        [Required(ErrorMessage = "Email-ът е задължителен!!!")]
        [EmailAddress(ErrorMessage = "Email-ът не е валиден!!!")]
        public string Email { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
