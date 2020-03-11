namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using TestingLiftInfo.Common;
    using TestingLiftInfo.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
