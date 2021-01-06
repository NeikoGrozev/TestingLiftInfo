namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TestingLiftInfo.Common;
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
        public async Task<IActionResult> Create([FromForm] CreateInspectTypeInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            if (GlobalConstants.Editors.Contains(this.User.Identity.Name))
            {
                var isCreate = await this.inspectTypesService.CreateAsync(model.Name);

                if (isCreate)
                {
                    this.TempData["CreateInspectType"] = $"Типът пеглед {model.Name} е добавен към списъка!";
                }
            }

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

        public async Task<IActionResult> Detail(string id)
        {
            var inspectType = await this.inspectTypesService.GetCurrentInspectType(id);

            var viewModel = new EditInspectTypeViewModel
            {
                InspectTypeDetail = inspectType,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] EditInspectTypeViewModel model)
        {
            var isCreate = false;

            if (GlobalConstants.Editors.Contains(this.User.Identity.Name))
            {
                isCreate = await this.inspectTypesService.EditInspectType(model.Id, model.Name);
            }

            if (isCreate)
            {
                this.TempData["EditInspectType"] = $"Типът преглед {model.Name} е редактиран!";
            }

            return this.RedirectToAction("All");
        }
    }
}
