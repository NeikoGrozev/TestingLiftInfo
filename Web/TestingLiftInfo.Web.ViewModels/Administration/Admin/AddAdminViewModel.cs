namespace TestingLiftInfo.Web.ViewModels.Administration.Admin
{
    using System.ComponentModel.DataAnnotations;

    using TestingLiftInfo.Web.Infrastructure;

    public class AddAdminViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
