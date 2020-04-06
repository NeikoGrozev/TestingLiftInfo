namespace TestingLiftInfo.Services.Data
{
    using System.Threading.Tasks;
    using TestingLiftInfo.Web.ViewModels.Administration.Inspects;

    public interface IInspectsService
    {
        Task CreateAsync(
            string userId,
            string inspectTypeId,
            string liftId,
            string notes,
            string prescriptions,
            string supportCompanyId);

        InspectDetailViewModel GetCurrentInspect(string id);
    }
}
