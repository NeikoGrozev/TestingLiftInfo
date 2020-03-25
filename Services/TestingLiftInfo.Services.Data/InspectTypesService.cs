﻿namespace TestingLiftInfo.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Mapping;
    using TestingLiftInfo.Web.ViewModels.Administration.InspectTypes;

    public class InspectTypesService : IInspectTypesService
    {
        private readonly IDeletableEntityRepository<InspectType> inspectTypeRepository;

        public InspectTypesService(IDeletableEntityRepository<InspectType> inspectTypeRepository)
        {
            this.inspectTypeRepository = inspectTypeRepository;
        }

        public ICollection<CreateInspectTypeViewModel> GetAllManufacturersForViewModel()
        {
            var manufacturers = this.inspectTypeRepository
                .All()
                .OrderBy(x => x.Name)
                .To<CreateInspectTypeViewModel>()
                .ToList();

            return manufacturers;
        }
    }
}
