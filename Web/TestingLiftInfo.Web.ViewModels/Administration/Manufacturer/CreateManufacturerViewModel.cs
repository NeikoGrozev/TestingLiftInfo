﻿namespace TestingLiftInfo.Web.ViewModels.Administration.Manufacturer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CreateManufacturerViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}