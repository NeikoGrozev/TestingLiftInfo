namespace TestingLiftInfo.Web.ViewModels.Administration.Admin
{
    using System.ComponentModel.DataAnnotations;

    public class AddAdminViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
