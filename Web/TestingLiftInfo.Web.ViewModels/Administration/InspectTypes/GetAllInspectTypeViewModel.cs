namespace TestingLiftInfo.Web.ViewModels.Administration.InspectTypes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GetAllInspectTypeViewModel
    {
        public ICollection<InspectTypeDetailViewModel> InspectTypes { get; set; }
    }
}
