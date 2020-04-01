namespace TestingLiftInfo.Web.ViewModels.Administration.InspectTypes
{
    using System.ComponentModel.DataAnnotations;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;
    using TestingLiftInfo.Web.Infrastructure;

    public class CreateInspectTypeViewModel : IMapFrom<InspectType>
    {
        [Required]
        public string Name { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
