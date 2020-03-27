namespace TestingLiftInfo.Web.ViewModels.Administration.Lifts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;

    public class GetAllLiftsViewModel
    {
        public IEnumerable<LiftViewModel> Lifts { get; set; }
    }
}
