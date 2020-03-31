namespace TestingLiftInfo.Services.Data
{
    using TestingLiftInfo.Web.ViewModels.Administration.Inspects;

    public interface IInspectsService
    {
        InspectDetailViewModel GetCurrentInspect(string id);
    }
}
