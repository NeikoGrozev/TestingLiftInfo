namespace TestingLiftInfo.Web.ViewModels.Administration.Manufacturers
{
    using System.Collections.Generic;

    public class GetAllManufacturerViewModel
    {
        public ICollection<ManufacturerDetailViewModel> Manufacturers { get; set; }
    }
}
