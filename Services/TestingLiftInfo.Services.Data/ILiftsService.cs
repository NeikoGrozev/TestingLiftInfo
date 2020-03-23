namespace TestingLiftInfo.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Web.ViewModels.Administration.Lifts;

    public interface ILiftsService
    {
        ICollection<LiftViewModel> GetAllLifts();

        LiftDetailViewModel GetCurrentLift(string id);

        ICollection<LiftViewModel> SearchRegistrationCriteria(string registationNumber);

        ICollection<LiftViewModel> SearchRegisAndManufCriteria(string registationNumber, string manufacturer);

        ICollection<LiftViewModel> SearchRegisAndCityCriteria(string registationNumber, string city);

        ICollection<LiftViewModel> SearchManufacturerCriteria(string manufacturer);

        ICollection<LiftViewModel> SearchManufAndCityCriteria(string manufacturer, string city);

        ICollection<LiftViewModel> SearchCityCriteria(string city);

        ICollection<LiftViewModel> GetAllSearchCriteria(string registationNumber, string manufacturer, string city);
    }
}
