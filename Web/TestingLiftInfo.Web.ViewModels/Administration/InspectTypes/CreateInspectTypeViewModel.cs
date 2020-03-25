namespace TestingLiftInfo.Web.ViewModels.Administration.InspectTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;

    public class CreateInspectTypeViewModel : IMapFrom<InspectType>
    {
        [Required]
        public string Name { get; set; }
    }
}
