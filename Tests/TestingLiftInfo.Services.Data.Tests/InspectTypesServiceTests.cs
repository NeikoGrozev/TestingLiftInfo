namespace TestingLiftInfo.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Data.Repositories;
    using TestingLiftInfo.Services.Data.Common;

    using Xunit;

    public class InspectTypesServiceTests
    {
        private IInspectTypesService inspectTypeService;

        [Fact]
        public async Task CreateInspectType_WithValidInput_ShouldBeReturnCorrectBool()
        {
            this.inspectTypeService = InitializeCategoriesService();

            string inspectTypeName = "Първоначален";

            await this.inspectTypeService.CreateAsync(inspectTypeName);
            var inspectTypes = await this.inspectTypeService.GetAllInspectTypes();

            Assert.Equal(1,inspectTypes.Count);
            Assert.Equal(inspectTypeName, inspectTypes.FirstOrDefault().Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        public async Task CreateInspectType_WithNotValidInput_ShouldBeReturnFalse(string input)
        {
            this.inspectTypeService = InitializeCategoriesService();

            string inspectTypeName = input;

            await this.inspectTypeService.CreateAsync(inspectTypeName);

            var inspectTypes = await this.inspectTypeService.GetAllInspectTypes();

            Assert.Equal(0, inspectTypes.Count);
        }

        [Fact]
        public async Task GetAllInspectTypes_WithValidInput_ShouldBeReturnCorrectAllCities()
        {
            this.inspectTypeService = InitializeCategoriesService();

            string inspectTypeNameOne = "Пъровначален";
            string inspectTypeNameTwo = "Периодичен";

            await this.inspectTypeService.CreateAsync(inspectTypeNameOne);
            await this.inspectTypeService.CreateAsync(inspectTypeNameTwo);

            var inspectTypes = await this.inspectTypeService.GetAllInspectTypes();

            Assert.Equal(2, inspectTypes.Count);
            Assert.Equal(inspectTypeNameOne, inspectTypes.FirstOrDefault().Name);
            Assert.Equal(inspectTypeNameTwo, inspectTypes.Skip(1).Take(1).FirstOrDefault().Name);
        }

        [Fact]
        public async Task GetAllInspectTypes_WithValidInput_ShouldBeReturnCorrectAllManufacturersForViewModel()
        {
            this.inspectTypeService = InitializeCategoriesService();

            string inspectTypeName = "Пъровначален";
            await this.inspectTypeService.CreateAsync(inspectTypeName);

            var manufacturers = await this.inspectTypeService.GetAllInspectTypesForViewModel();

            Assert.Equal(1, manufacturers.Count);
            Assert.Equal(inspectTypeName, manufacturers.FirstOrDefault().Name);
        }

        private static InspectTypesService InitializeCategoriesService()
        {
            MapperInitializer.InitializeMapper();
            var context = InitializeContext.CreateContextForInMemory();
            var repository = new EfDeletableEntityRepository<InspectType>(context);
            var service = new InspectTypesService(repository);

            return service;
        }
    }
}
