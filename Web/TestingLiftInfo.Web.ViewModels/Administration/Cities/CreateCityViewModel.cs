namespace TestingLiftInfo.Web.ViewModels.Administration.Cities
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCityViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
