namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Data;
    using TestingLiftInfo.Web.ViewModels.Administration.Inspects;

    public class InspectsController : AdministrationController
    {
        private readonly ISupportCompaniesService supportCompaniesService;
        private readonly IInspectTypesService inspectTypesService;
        private readonly ILiftsService liftsService;
        private readonly IInspectsService inspectsService;
        private readonly UserManager<ApplicationUser> userManager;

        public InspectsController(
            ISupportCompaniesService supportCompaniesService,
            IInspectTypesService inspectTypesService,
            ILiftsService liftsService,
            IInspectsService inspectsService,
            UserManager<ApplicationUser> userManager)
        {
            this.supportCompaniesService = supportCompaniesService;
            this.inspectTypesService = inspectTypesService;
            this.liftsService = liftsService;
            this.inspectsService = inspectsService;
            this.userManager = userManager;
        }

        public IActionResult Create(string id)
        {
            var inspectTypes = this.inspectTypesService.GetAllInspectTypes();
            var supportCompanies = this.supportCompaniesService.GetAll();
            var lift = this.liftsService.GetLift(id);

            var input = new InspectInputDataViewModel()
            {
                InspectTypes = inspectTypes,
                SupportCompanies = supportCompanies,
                Lift = lift,
            };

            var viewModel = new BiginspectViewModel()
            {
                InspectInputDataViewModel = input,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]BiginspectViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Create");
            }

            await this.liftsService.AddSupportCompany(model.CreateInspectViewModel.LiftId, model.CreateInspectViewModel.SupportCompanyId);

            var userId = this.userManager.GetUserId(this.User);

            await this.inspectsService.CreateAsync(
                 userId,
                 model.CreateInspectViewModel.InspectTypeId,
                 model.CreateInspectViewModel.LiftId,
                 model.CreateInspectViewModel.Notes,
                 model.CreateInspectViewModel.Prescriptions,
                 model.CreateInspectViewModel.SupportCompanyId);

            return this.RedirectToAction("All", "Lifts");
        }

        public IActionResult Detail(string id)
        {
            var viewModel = this.inspectsService.GetCurrentInspect(id);

            return this.View(viewModel);
        }
    }
}
