﻿namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Data.Models.Enumerations;
    using TestingLiftInfo.Web.ViewModels.Administration.Lifts;

    public interface ILiftsService
    {
        Task<bool> CreateAsync(string userId, LiftType liftType, int numberOfStops, int capacity, DoorType doorType, string manufacturerId, string productionNumber, string cityId, string address, string latitude, string longitude);

        Task<ICollection<LiftViewModel>> GetAllLifts(int page, int numberOfPrintLifts);

        int GetCountAllActiveLifts();

        Lift GetLift(string id);

        Task<LiftDetailViewModel> GetCurrentLift(string id);

        Task<LiftEditDataViewModel> GetCurrentLiftForEdit(string id);

        Task<ICollection<LiftViewModel>> SearchIsDeletedCriteria(bool isDeleted);

        Task<ICollection<LiftViewModel>> SearchRegistrationCriteria(string registationNumber, bool isDeleted);

        Task<ICollection<LiftViewModel>> SearchRegisAndManufCriteria(string registationNumber, string manufacturer, bool isDeleted);

        Task<ICollection<LiftViewModel>> SearchRegisAndCityCriteria(string registationNumber, string cityOrAddress, bool isDeleted);

        Task<ICollection<LiftViewModel>> SearchManufacturerCriteria(string manufacturer, bool isDeleted);

        Task<ICollection<LiftViewModel>> SearchManufAndCityCriteria(string manufacturer, string cityOrAddress, bool isDeleted);

        Task<ICollection<LiftViewModel>> SearchCityCriteria(string cityOrAddress, bool isDeleted);

        Task<ICollection<LiftViewModel>> GetAllSearchCriteria(string registationNumber, string manufacturer, string cityOrAddress, bool isDeleted);

        Task AddSupportCompany(string liftId, string supportCompanyId);

        Lift GetLiftWithRegistrationNumber(string regNumber);

        Task<bool> EditLift(string userId, string id, LiftType liftType, int numberOfStops, int capacity, DoorType doorType, string manufacturerId, string productionNumber, string cityId, string address, string latitude, string longitude);

        Task DeleteAsync(string id);
    }
}
