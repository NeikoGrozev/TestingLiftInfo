namespace TestingLiftInfo.Web.ViewModels.Administration.InspectTypes
{
    using System.Collections.Generic;

    public class GetAllInspectTypeViewModel
    {
        public ICollection<InspectTypeDetailViewModel> InspectTypes { get; set; }
    }
}
