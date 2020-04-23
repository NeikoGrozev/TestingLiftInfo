namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Data;
    using TestingLiftInfo.Web.ViewModels.Administration.InspectTypes;

    public class InspectTypesController : AdministrationController
    {
        private readonly IInspectTypesService inspectTypesService;

        public InspectTypesController(IInspectTypesService inspectTypesService)
        {
            this.inspectTypesService = inspectTypesService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateInspectTypeInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.inspectTypesService.CreateAsync(model.Name);

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            var inspectTypes = await this.inspectTypesService
                .GetAllInspectTypesForViewModel();

            var viewModel = new GetAllInspectTypeViewModel
            {
                InspectTypes = inspectTypes,
            };

            return this.View(viewModel);
        }
    }
}
