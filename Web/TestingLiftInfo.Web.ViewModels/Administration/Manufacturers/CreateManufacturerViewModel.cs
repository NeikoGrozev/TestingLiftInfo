namespace TestingLiftInfo.Web.ViewModels.Administration.Manufacturers
{
    using System.ComponentModel.DataAnnotations;

    using TestingLiftInfo.Web.Infrastructure;

    public class CreateManufacturerViewModel
    {
        [Required]
        public string Name { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
