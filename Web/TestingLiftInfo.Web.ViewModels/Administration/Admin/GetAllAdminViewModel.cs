namespace TestingLiftInfo.Web.ViewModels.Administration.Admin
{
    using System.Collections.Generic;

    using TestingLiftInfo.Data.Models;

    public class GetAllAdminViewModel
    {
        public ICollection<ApplicationUser> Users { get; set; }
    }
}
