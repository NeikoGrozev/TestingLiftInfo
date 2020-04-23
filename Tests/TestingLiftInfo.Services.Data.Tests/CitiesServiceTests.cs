namespace TestingLiftInfo.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using TestingLiftInfo.Data;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Data.Repositories;
    using TestingLiftInfo.Services.Data;
    using TestingLiftInfo.Services.Data.Common;

    using Xunit;

    public class CitiesServiceTests
    {
        private ApplicationDbContext context;
        private ICitiesService citiesService;

        [Fact]
        public async Task CreateCity_WithValidInput_ShouldBeReturnCorrectBool()
        {
            this.context = InitializeContext.CreateContextForInMemory();
            this.citiesService = InitializeCategoriesService(this.context);

            string cityName = "Бургас";

            var isCreate = await this.citiesService.CreateAsync(cityName);

            Assert.True(isCreate);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        public async Task CreateCity_WithNotValidInput_ShouldBeReturnFalse(string input)
        {
            this.context = InitializeContext.CreateContextForInMemory();
            this.citiesService = InitializeCategoriesService(this.context);

            string cityName = input;

            var isCreate = await this.citiesService.CreateAsync(cityName);

            Assert.False(isCreate);
        }

        [Fact]
        public async Task GetAllCities_WithValidInput_ShouldBeReturnCorrectAllCities()
        {
            this.context = InitializeContext.CreateContextForInMemory();
            this.citiesService = InitializeCategoriesService(this.context);

            string cityNameOne = "Бургас";
            string cityNameTwo = "Пловдив";

            await this.citiesService.CreateAsync(cityNameOne);
            await this.citiesService.CreateAsync(cityNameTwo);

            var cities = await this.citiesService.GetAllCity();

            Assert.Equal(2, cities.Count);
            Assert.Equal(cityNameTwo, cities.Skip(1).Take(1).FirstOrDefault().Name);
        }

        [Fact]
        public async Task GetAllCities_WithValidInput_ShouldBeReturnCorrectAllCitiesForViewModel()
        {
            this.context = InitializeContext.CreateContextForInMemory();
            this.citiesService = InitializeCategoriesService(this.context);

            string cityName = "София";
            await this.citiesService.CreateAsync(cityName);

            var cities = await this.citiesService.GetAllCityForViewModel();

            Assert.Equal(1, cities.Count);
            Assert.Equal(cityName, cities.FirstOrDefault().Name);
        }

        private static CitiesService InitializeCategoriesService(ApplicationDbContext context)
        {
            MapperInitializer.InitializeMapper();

            var repository = new EfDeletableEntityRepository<City>(context);
            var service = new CitiesService(repository);

            return service;
        }
    }
}
