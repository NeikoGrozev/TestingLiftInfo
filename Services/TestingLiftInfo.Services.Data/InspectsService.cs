namespace TestingLiftInfo.Services.Data
{
    using System.Linq;

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
