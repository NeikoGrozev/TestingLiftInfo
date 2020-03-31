namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Web.ViewModels.Administration.Lifts;

    public interface ILiftsService
    {
        ICollection<LiftViewModel> GetAllLifts();

        Lift GetLift(string id);

        LiftDetailViewModel GetCurrentLift(string id);

        ICollection<LiftViewModel> SearchRegistrationCriteria(string registationNumber);

        ICollection<LiftViewModel> SearchRegisAndManufCriteria(string registationNumber, string manufacturer);

        ICollection<LiftViewModel> SearchRegisAndCityCriteria(string registationNumber, string cityOrAddress);

        ICollection<LiftViewModel> SearchManufacturerCriteria(string manufacturer);

        ICollection<LiftViewModel> SearchManufAndCityCriteria(string manufacturer, string cityOrAddress);

        ICollection<LiftViewModel> SearchCityCriteria(string cityOrAddress);

        ICollection<LiftViewModel> GetAllSearchCriteria(string registationNumber, string manufacturer, string cityOrAddress);

        Task AddSupportCompany(string liftId, string supportCompanyId);
    }
}
