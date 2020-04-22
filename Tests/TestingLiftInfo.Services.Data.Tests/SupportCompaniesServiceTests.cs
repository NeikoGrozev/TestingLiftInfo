namespace TestingLiftInfo.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Data.Repositories;
    using TestingLiftInfo.Services.Data.Common;

    using Xunit;

    public class SupportCompaniesServiceTests
    {
        private ISupportCompaniesService supportCompaniesService;

        [Fact]
        public async Task CreateSupportCompanies_WithValidInput_ShouldBeReturnCorrectBool()
        {
            this.supportCompaniesService = InitializeCategoriesService();

            string manufacturerName = @"""Експрес лифт сервиз"" ООД";

            var isCreate = await this.supportCompaniesService.CreateAsync(manufacturerName);

            Assert.True(isCreate);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        public async Task CreateSupportCompanies_WithNotValidInput_ShouldBeReturnFalse(string input)
        {
            this.supportCompaniesService = InitializeCategoriesService();

            string supportCompanyName = input;

            var isCreate = await this.supportCompaniesService.CreateAsync(supportCompanyName);

            Assert.False(isCreate);
        }

        [Fact]
        public async Task GetAllSupportCompanies_WithValidInput_ShouldBeReturnCorrectAllSupportCompanies()
        {
            this.supportCompaniesService = InitializeCategoriesService();

            string supportCompanyNameOne = @"""Експрес лифт сервиз"" ООД";
            string supportCompanyNameTwo = @"""Глобал лифт сервиз"" ООД";

            await this.supportCompaniesService.CreateAsync(supportCompanyNameOne);
            await this.supportCompaniesService.CreateAsync(supportCompanyNameTwo);

            var manufacturers = await this.supportCompaniesService.GetAll();

            Assert.Equal(2, manufacturers.Count);
            Assert.Equal(supportCompanyNameTwo, manufacturers.FirstOrDefault().Name);
            Assert.Equal(supportCompanyNameOne, manufacturers.Skip(1).Take(1).FirstOrDefault().Name);
        }

        [Fact]
        public async Task GetAllSupportCompanies_WithValidInput_ShouldBeReturnCorrectAllManufacturersForViewModel()
        {
            this.supportCompaniesService = InitializeCategoriesService();

            string supportCompany = @"""Експрес лифт сервиз"" ООД";
            var result = await this.supportCompaniesService.CreateAsync(supportCompany);

            var supportCompanies = await this.supportCompaniesService.GetAllCompanies();

            Assert.Equal(1, supportCompanies.Count);
            Assert.Equal(supportCompany, supportCompanies.FirstOrDefault().Name);
        }

        private static SupportCompaniesService InitializeCategoriesService()
        {
            MapperInitializer.InitializeMapper();
            var context = InitializeContext.CreateContextForInMemory();
            var repository = new EfDeletableEntityRepository<SupportCompany>(context);
            var service = new SupportCompaniesService(repository);

            return service;
        }
    }
}
