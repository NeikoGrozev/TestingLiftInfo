namespace TestingLiftInfo.Web.ViewModels.Administration.Lifts
{
    using System.Collections.Generic;

    public class GetAllLiftsViewModel
    {
        public IEnumerable<LiftViewModel> Lifts { get; set; }
    }
}
