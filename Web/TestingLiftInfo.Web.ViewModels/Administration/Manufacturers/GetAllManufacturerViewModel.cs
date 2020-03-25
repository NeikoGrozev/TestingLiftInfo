namespace TestingLiftInfo.Web.ViewModels.Administration.Manufacturers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;

    public class GetAllManufacturerViewModel
    {
        public ICollection<ManufacturerDetailViewModel> Manufacturers { get; set; }
    }
}
