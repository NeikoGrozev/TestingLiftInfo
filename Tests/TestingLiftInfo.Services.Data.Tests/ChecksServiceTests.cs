namespace TestingLiftInfo.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Data.Models.Enumerations;
    using TestingLiftInfo.Data.Repositories;
    using TestingLiftInfo.Services.Data.Common;

    using Xunit;

    public class ChecksServiceTests
    {
        [Fact]
        public async Task CheckInspectionLifts_WithValidInput_ShouldBeReturnCorrectDate()
        {
            MapperInitializer.InitializeMapper();
            var context = InitializeContext.CreateContextForInMemory();
            var repository = new EfDeletableEntityRepository<Lift>(context);
            var checkService = new ChecksService(repository);

            var lift = new Lift
            {
                Id = "1",
                ApplicationUserId = "A1",
                LiftType = (LiftType)Enum.Parse(typeof(LiftType), "Пътнически"),
                NumberOfStops = 6,
                Capacity = 630,
                DoorType = (DoorType)Enum.Parse(typeof(DoorType), "АВ"),
                RegistrationNumber = "123",
                ManufacturerId = "M1",
                ProductionNumber = "P123",
                Address = "Address",
                Inspects = new List<Inspect>()
                {
                    new Inspect
                    {
                        ApplicationUserId = "A1",
                        InspectTypeId = "Периодичен",
                        LiftId = "1",
                        SupportCompanyId = "S1",
                        Notes = "Test",
                        Prescriptions = "Test",
                        CreatedOn = DateTime.UtcNow.AddDays(-10),
                    },
                },
            };

            await context.Lifts.AddAsync(lift);
            await context.SaveChangesAsync();

            var findLift = context.Inspects.FirstOrDefault();

            Assert.NotNull(findLift);

            var date = await checkService.GetValidInspect("123");

            Assert.NotNull(date);
            Assert.True(DateTime.UtcNow > date);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("123456")]
        [InlineData(".")]
        [InlineData("abc")]
        public async Task CheckInspectionLifts_WithInvalidInput_ShouldBeReturnNull(string input)
        {
            MapperInitializer.InitializeMapper();
            var context = InitializeContext.CreateContextForInMemory();
            var repository = new EfDeletableEntityRepository<Lift>(context);
            var checkService = new ChecksService(repository);

            var lift = new Lift
            {
                Id = "1",
                ApplicationUserId = "A1",
                LiftType = (LiftType)Enum.Parse(typeof(LiftType), "Пътнически"),
                NumberOfStops = 6,
                Capacity = 630,
                DoorType = (DoorType)Enum.Parse(typeof(DoorType), "АВ"),
                RegistrationNumber = "123",
                ManufacturerId = "M1",
                ProductionNumber = "P123",
                Address = "Address",
                Inspects = new List<Inspect>()
                {
                    new Inspect
                    {
                        ApplicationUserId = "A1",
                        InspectTypeId = "Периодичен",
                        LiftId = "1",
                        SupportCompanyId = "S1",
                        Notes = "Test",
                        Prescriptions = "Test",
                        CreatedOn = DateTime.UtcNow.AddDays(-10),
                    },
                },
            };

            await context.Lifts.AddAsync(lift);
            await context.SaveChangesAsync();

            var date = await checkService.GetValidInspect(input);

            Assert.Null(date);
        }
    }
}
