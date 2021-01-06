namespace TestingLiftInfo.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> CreateAsync(string name)
        {
            var currentInspectType = this.inspectTypeRepository
                .All()
                .FirstOrDefault(x => x.Name == name);

            var isCreate = false;

            if (currentInspectType == null && !string.IsNullOrWhiteSpace(name))
            {
                var inspectType = new InspectType
                {
                    Name = name,
                };

                await this.inspectTypeRepository.AddAsync(inspectType);
                await this.inspectTypeRepository.SaveChangesAsync();

                isCreate = true;
            }

            return isCreate;
        }

        public async Task<ICollection<InspectType>> GetAllInspectTypes()
        {
            var inspectTypes = await this.inspectTypeRepository
                 .All()
                 .OrderBy(x => x.CreatedOn)
                 .ToListAsync();

            return inspectTypes;
        }

        public async Task<ICollection<InspectTypeDetailViewModel>> GetAllInspectTypesForViewModel()
        {
            var inspectTypes = await this.inspectTypeRepository
                .All()
                .OrderBy(x => x.CreatedOn)
                .To<InspectTypeDetailViewModel>()
                .ToListAsync();

            return inspectTypes;
        }

        public async Task<InspectTypeDetailViewModel> GetCurrentInspectType(string id)
        {
            var city = await this.inspectTypeRepository
                .All()
                .Where(x => x.Id == id)
                .To<InspectTypeDetailViewModel>()
                .FirstOrDefaultAsync();

            return city;
        }

        public async Task<bool> EditInspectType(string id, string name)
        {
            var inspectType = this.inspectTypeRepository.All().FirstOrDefault(x => x.Id == id);
            inspectType.Name = name;
            this.inspectTypeRepository.Update(inspectType);
            await this.inspectTypeRepository.SaveChangesAsync();

            return true;
        }
    }
}
