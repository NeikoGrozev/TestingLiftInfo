namespace TestingLiftInfo.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Web.ViewModels.Administration.InspectTypes;

    public interface IInspectTypesService
    {
        ICollection<InspectType> GetAllInspectTypes();

        ICollection<InspectTypeDetailViewModel> GetAllInspectTypesForViewModel();
    }
}
