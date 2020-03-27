namespace TestingLiftInfo.Web.ViewModels.Administration.Inspects
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TestingLiftInfo.Data.Models;

    public class InspectInputDataViewModel
    {
        public Lift Lift { get; set; }

        public ICollection<InspectType> InspectTypes { get; set; }

        public ICollection<SupportCompany> SupportCompanies { get; set; }
    }
}
