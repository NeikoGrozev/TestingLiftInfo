namespace TestingLiftInfo.Web.ViewModels.Administration.Lifts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GetSearchLiftsViewModel
    {
        public IEnumerable<LiftViewModel> Lifts { get; set; }
    }
}
