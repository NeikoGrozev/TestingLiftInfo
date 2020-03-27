namespace TestingLiftInfo.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TestingLiftInfo.Web.ViewModels.Administration.Inspects;

    public interface IInspectsService
    {
        InspectDetailViewModel GetCurrentInspect(string id);
    }
}
