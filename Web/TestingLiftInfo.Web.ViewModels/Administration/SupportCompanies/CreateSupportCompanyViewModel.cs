namespace TestingLiftInfo.Web.ViewModels.Administration.SupportCompanies
{
    using System.ComponentModel.DataAnnotations;

    public class CreateSupportCompanyViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
