namespace TestingLiftInfo.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Data.Repositories;
    using TestingLiftInfo.Services.Data.Common;

    using Xunit;

    public class ManufacturersServiceTests
    {
        private IManufacturersService manufacturerService;

        [Fact]
        public async Task CreateManufacturer_WithValidInput_ShouldBeReturnCorrectBool()
        {
            this.manufacturerService = InitializeCategoriesService();

            string manufacturerName = @"""Изамет"" ООД";

            var isCreate = await this.manufacturerService.CreateAsync(manufacturerName);

            Assert.True(isCreate);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        public async Task CreateManufacturer_WithNotValidInput_ShouldBeReturnFalse(string input)
        {
            this.manufacturerService = InitializeCategoriesService();

            string manufacturerName = input;

            var isCreate = await this.manufacturerService.CreateAsync(manufacturerName);

            Assert.False(isCreate);
        }

        [Fact]
        public async Task GetAllManufacturers_WithValidInput_ShouldBeReturnCorrectAllCities()
        {
            this.manufacturerService = InitializeCategoriesService();

            string manufacturerNameOne = @"""Изамет"" ООД";
            string manufacturerNameTwo = @"""Лифт Груп Аспект"" ООД";

            await this.manufacturerService.CreateAsync(manufacturerNameOne);
            await this.manufacturerService.CreateAsync(manufacturerNameTwo);

            var manufacturers = await this.manufacturerService.GetAllManufacturers();

            Assert.Equal(2, manufacturers.Count);
            Assert.Equal(manufacturerNameOne, manufacturers.FirstOrDefault().Name);
            Assert.Equal(manufacturerNameTwo, manufacturers.Skip(1).Take(1).FirstOrDefault().Name);
        }

        [Fact]
        public async Task GetAllManufacturer_WithValidInput_ShouldBeReturnCorrectAllManufacturersForViewModel()
        {
            this.manufacturerService = InitializeCategoriesService();

            string manufacturerName = @"""Изамет"" ООД";
            var result = await this.manufacturerService.CreateAsync(manufacturerName);

            var manufacturers = await this.manufacturerService.GetAllManufacturersForViewModel();

            Assert.Equal(1, manufacturers.Count);
            Assert.Equal(manufacturerName, manufacturers.FirstOrDefault().Name);
        }

        private static ManufacturersService InitializeCategoriesService()
        {
            MapperInitializer.InitializeMapper();
            var context = InitializeContext.CreateContextForInMemory();
            var repository = new EfDeletableEntityRepository<Manufacturer>(context);
            var service = new ManufacturersService(repository);

            return service;
        }
    }
}
