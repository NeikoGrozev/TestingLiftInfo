namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

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
        private readonly IDeletableEntityRepository<Inspect> inspectsRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public InspectsController(
            ISupportCompaniesService supportCompaniesService,
            IInspectTypesService inspectTypesService,
            ILiftsService liftsService,
            IInspectsService inspectsService,
            IDeletableEntityRepository<Inspect> inspectsRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.supportCompaniesService = supportCompaniesService;
            this.inspectTypesService = inspectTypesService;
            this.liftsService = liftsService;
            this.inspectsService = inspectsService;
            this.inspectsRepository = inspectsRepository;
            this.userRepository = userRepository;
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
                return this.View(model);
            }

            await this.liftsService.AddSupportCompany(model.CreateInspectViewModel.LiftId, model.CreateInspectViewModel.SupportCompanyId);

            var user = this.User.Identity;
            var currentUser = this.userRepository.All().FirstOrDefault(x => x.Email == user.Name);

            var inspect = new Inspect()
            {
                ApplicationUserId = currentUser.Id,
                InspectTypeId = model.CreateInspectViewModel.InspectTypeId,
                LiftId = model.CreateInspectViewModel.LiftId,
                Notes = model.CreateInspectViewModel.Notes,
                Prescriptions = model.CreateInspectViewModel.Prescriptions,
                SupportCompanyId = model.CreateInspectViewModel.SupportCompanyId,
            };

            await this.inspectsRepository.AddAsync(inspect);
            await this.inspectsRepository.SaveChangesAsync();

            return this.RedirectToAction("All", "Lifts");
        }

        public IActionResult Detail(string id)
        {
            var viewModel = this.inspectsService.GetCurrentInspect(id);

            return this.View(viewModel);
        }
    }
}
