namespace TestingLiftInfo.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;
    using TestingLiftInfo.Web.ViewModels.Administration.Inspects;

    public class InspectsService : IInspectsService
    {
        private readonly IDeletableEntityRepository<Inspect> inspectRepository;

        public InspectsService(IDeletableEntityRepository<Inspect> inspectRepository)
        {
            this.inspectRepository = inspectRepository;
        }

        public async Task CreateAsync(string userId, string inspectTypeId, string liftId, string notes, string prescriptions, string supportCompanyId)
        {
            var inspect = new Inspect()
            {
                ApplicationUserId = userId,
                InspectTypeId = inspectTypeId,
                LiftId = liftId,
                Notes = notes,
                Prescriptions = prescriptions,
                SupportCompanyId = supportCompanyId,
            };

            await this.inspectRepository.AddAsync(inspect);
            await this.inspectRepository.SaveChangesAsync();
        }

        public InspectDetailViewModel GetCurrentInspect(string id)
        {
            var inspect = this.inspectRepository
                .AllWithDeleted()
                .Where(x => x.Id == id)
                .To<InspectDetailViewModel>()
                .FirstOrDefault();

            return inspect;
        }
    }
}
