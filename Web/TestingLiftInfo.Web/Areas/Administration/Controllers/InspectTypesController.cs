﻿namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Services.Data;
    using TestingLiftInfo.Web.ViewModels.Administration.InspectTypes;

    public class InspectTypesController : AdministrationController
    {
        private readonly IDeletableEntityRepository<InspectType> inspectTypeRepository;
        private readonly IInspectTypesService inspectTypesService;

        public InspectTypesController(
            IDeletableEntityRepository<InspectType> inspectTypeRepository,
            IInspectTypesService inspectTypesService)
        {
            this.inspectTypeRepository = inspectTypeRepository;
            this.inspectTypesService = inspectTypesService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateInspectTypeViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var currentInspectType = this.inspectTypeRepository.All().FirstOrDefault(x => x.Name == model.Name);

            if (currentInspectType == null)
            {
                var inspectType = new InspectType
                {
                    Name = model.Name,
                };

                await this.inspectTypeRepository.AddAsync(inspectType);
                await this.inspectTypeRepository.SaveChangesAsync();
            }

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var inspectTypes = this.inspectTypesService.GetAllInspectTypesForViewModel();

            var viewModel = new GetAllInspectTypeViewModel
            {
                InspectTypes = inspectTypes,
            };

            return this.View(viewModel);
        }
    }
}