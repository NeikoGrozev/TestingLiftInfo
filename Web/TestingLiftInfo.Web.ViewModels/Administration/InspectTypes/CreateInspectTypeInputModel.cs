namespace TestingLiftInfo.Web.ViewModels.Administration.InspectTypes
{
    using System.ComponentModel.DataAnnotations;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;
    using TestingLiftInfo.Web.Infrastructure;

    public class CreateInspectTypeInputModel : IMapFrom<InspectType>
    {
        [Required(ErrorMessage = "Типът е задължителен!!!")]
        [StringLength(100, ErrorMessage = "{0}ът трябва да бъде дълъг, най-малко {2} и максимум {1} символа.", MinimumLength = 3)]
        [Display(Name = "Тип")]
        public string Name { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
