namespace TestingLiftInfo.Web.ViewModels.Administration.SupportCompanies
{
    using System.ComponentModel.DataAnnotations;

    using TestingLiftInfo.Web.Infrastructure;

    public class CreateSupportCompanyViewModel
    {
        [Required]
        public string Name { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
