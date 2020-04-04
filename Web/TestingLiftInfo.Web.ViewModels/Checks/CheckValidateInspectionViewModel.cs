namespace TestingLiftInfo.Web.ViewModels.Checks
{
    using System.Collections.Generic;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;

    public class CheckValidateInspectionViewModel : IMapFrom<Lift>
    {
        public ICollection<Inspect> Inspects { get; set; }
    }
}
