namespace TestingLiftInfo.Web.ViewModels.Administration.Lifts
{
    using System.Collections.Generic;

    public class GetAllLiftsViewModel
    {
        public IEnumerable<LiftViewModel> Lifts { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public int CountAllLifts { get; set; }
    }
}
