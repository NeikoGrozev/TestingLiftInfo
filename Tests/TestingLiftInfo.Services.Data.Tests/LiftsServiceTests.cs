namespace TestingLiftInfo.Services.Data.Tests
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Data.Models.Enumerations;
    using TestingLiftInfo.Data.Repositories;
    using TestingLiftInfo.Services.Data.Common;

    using Xunit;

    public class LiftsServiceTests
    {
        private ILiftsService liftsService;
        private EfDeletableEntityRepository<Lift> repository;

        [Fact]
        public async Task CreateLifte_WithValidInput_ShouldBeReturnTrue()
        {
            this.liftsService = this.InitializeCategoriesService();

            var isCreated = await CreateLiftAsync(this.liftsService);

            Assert.True(isCreated);
        }

        [Fact]
        public async Task CreateLifte_WithInvalidInput_ShouldBeReturnFalse()
        {
            this.liftsService = this.InitializeCategoriesService();
            var isCreated = await CreateLiftAsync(this.liftsService);

            Assert.True(isCreated);

            isCreated = await CreateLiftAsync(this.liftsService);

            Assert.False(isCreated);
        }

        [Fact]
        public async Task GetAllLifts_WithValidInput_ShouldBeReturnCorrectData()
        {
            this.liftsService = this.InitializeCategoriesService();

            await CreateLiftAsync(this.liftsService);
            await CreateLiftAsync(this.liftsService);
            await CreateLiftAsync(this.liftsService);

            var lifts = await this.liftsService.GetAllLifts(1, 2);

            Assert.NotNull(lifts);
        } // Triabva da se preraboti

        [Fact]
        public async Task GetCountAllActiveLifts_WithValidInput_ShouldBeReturnCorrectCount()
        {
            this.liftsService = this.InitializeCategoriesService();

            var count = this.liftsService.GetCountAllActiveLifts();

            Assert.Equal(0, count);

            await CreateLiftAsync(this.liftsService);

            count = this.liftsService.GetCountAllActiveLifts();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task GetLifts_WithValidInput_ShouldBeReturnCorrectCount()
        {
            this.liftsService = this.InitializeCategoriesService();

            await CreateLiftAsync(this.liftsService);
            var lift = this.repository.All().FirstOrDefaultAsync().Result;

            Assert.NotNull(lift);

            var getLift = this.liftsService.GetLift(lift.Id);

            Assert.NotNull(getLift);
            Assert.Equal(lift.Id, getLift.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("abc")]
        [InlineData("123")]
        [InlineData("...")]
        public async Task GetLifts_WithInvalidInput_ShouldBeReturnNull(string input)
        {
            this.liftsService = this.InitializeCategoriesService();

            await CreateLiftAsync(this.liftsService);
            var lift = this.repository.All().FirstOrDefaultAsync().Result;

            Assert.NotNull(lift);

            var getLift = this.liftsService.GetLift(input);

            Assert.Null(getLift);
        }

        [Fact]
        public async Task GetCurrentLift_WithValidInput_ShouldBeReturnCorrectData()
        {
            this.liftsService = this.InitializeCategoriesService();

            await CreateLiftAsync(this.liftsService);
            var lift = this.repository.All().FirstOrDefaultAsync().Result;

            Assert.NotNull(lift);

            var getCurrentLift = this.liftsService.GetCurrentLift(lift.Id).Result;

            Assert.Null(getCurrentLift);
        } // Triabva da se preraboti

        [Fact]
        public async Task AddSupportCompany__WithValidInput_ShouldBeReturnCorrectData()
        {
            this.liftsService = this.InitializeCategoriesService();

            await CreateLiftAsync(this.liftsService);
            var lift = this.repository.All().FirstOrDefaultAsync().Result;

            string supportCompanyId = "SP1";
            await this.liftsService.AddSupportCompany(lift.Id, supportCompanyId);

            Assert.Equal(supportCompanyId, lift.SupportCompanyId);
        }

        [Fact]
        public async Task GetLiftWithRegistrationNumber_WithValidInput_ShouldBeReturnCorrectLift()
        {
            this.liftsService = this.InitializeCategoriesService();

            await CreateLiftAsync(this.liftsService);
            var lift = this.repository.All().FirstOrDefaultAsync().Result;

            var currentLift = this.liftsService.GetLiftWithRegistrationNumber(lift.RegistrationNumber);

            Assert.Equal(lift.RegistrationNumber, currentLift.RegistrationNumber);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("123")]
        public async Task GetLiftWithRegistrationNumber_WithInvalidInput_ShouldBeReturnNull(string input)
        {
            this.liftsService = this.InitializeCategoriesService();

            await CreateLiftAsync(this.liftsService);
            var lift = this.repository.All().FirstOrDefaultAsync().Result;

            var currentLift = this.liftsService.GetLiftWithRegistrationNumber(input);

            Assert.Null(currentLift);
            Assert.True(lift != currentLift);
        }

        [Fact]
        public async Task DeleteLift_WithValidInput_ShouldBeDeleteLift()
        {
            this.liftsService = this.InitializeCategoriesService();

            await CreateLiftAsync(this.liftsService);
            var lift = this.repository.All().FirstOrDefaultAsync().Result;

            await this.liftsService.DeleteAsync(lift.Id);

            lift = this.repository.All().FirstOrDefaultAsync().Result;
            var deleteLift = this.repository.AllWithDeleted().FirstOrDefaultAsync().Result;

            Assert.Null(lift);
            Assert.NotNull(deleteLift);
            Assert.Equal(DateTime.UtcNow.ToShortDateString(), deleteLift.DeletedOn.Value.ToShortDateString());
        }

        private static async Task<bool> CreateLiftAsync(ILiftsService liftsService)
        {
            string userId = "U1";
            LiftType liftType = (LiftType)Enum.Parse(typeof(LiftType), "Пътнически");
            int numberOfStops = 4;
            int capacity = 450;
            DoorType doorType = (DoorType)Enum.Parse(typeof(DoorType), "АВ");
            string manufacturerId = "M1";
            string productionNumber = "123";
            string cityId = "C1";
            string address = "A1";
            string latitude = "42.9494";
            string longitude = "23.566";

            var isCreated = await liftsService.CreateAsync(userId, liftType, numberOfStops, capacity, doorType, manufacturerId, productionNumber, cityId, address, latitude, longitude);

            return isCreated;
        }

        private LiftsService InitializeCategoriesService()
        {
            MapperInitializer.InitializeMapper();
            var context = InitializeContext.CreateContextForInMemory();
            this.repository = new EfDeletableEntityRepository<Lift>(context);
            var service = new LiftsService(this.repository);

            return service;
        }
    }
}
