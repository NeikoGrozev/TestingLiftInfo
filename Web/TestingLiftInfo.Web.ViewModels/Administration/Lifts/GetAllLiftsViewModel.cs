namespace TestingLiftInfo.Web.ViewModels.Administration.Lifts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TestingLiftInfo.Data.Models;

    public class GetAllLiftViewModel
    {
        public IEnumerable<Lift> Lifts { get; set; }
    }
}
