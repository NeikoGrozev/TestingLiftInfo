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

        ICollection<LiftViewModel> SearchIsDeletedCriteria(bool isDeleted);

        ICollection<LiftViewModel> SearchRegistrationCriteria(string registationNumber, bool isDeleted);

        ICollection<LiftViewModel> SearchRegisAndManufCriteria(string registationNumber, string manufacturer, bool isDeleted);

        ICollection<LiftViewModel> SearchRegisAndCityCriteria(string registationNumber, string cityOrAddress, bool isDeleted);

        ICollection<LiftViewModel> SearchManufacturerCriteria(string manufacturer, bool isDeleted);

        ICollection<LiftViewModel> SearchManufAndCityCriteria(string manufacturer, string cityOrAddress, bool isDeleted);

        ICollection<LiftViewModel> SearchCityCriteria(string cityOrAddress, bool isDeleted);

        ICollection<LiftViewModel> GetAllSearchCriteria(string registationNumber, string manufacturer, string cityOrAddress, bool isDeleted);

        Task AddSupportCompany(string liftId, string supportCompanyId);

        Lift GetLiftWithRegistrationNumber(string regNumber);
    }
}
