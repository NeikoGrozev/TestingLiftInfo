namespace TestingLiftInfo.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;

    using TestingLiftInfo.Web.ViewModels;

    public class HomeController : BaseController
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            return this.View();
        }

        //TODO:Triabva da go premahna
        public IActionResult Privacy()
        {
            return this.View();
        }

        public IActionResult HttpError(int statusCode)
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
