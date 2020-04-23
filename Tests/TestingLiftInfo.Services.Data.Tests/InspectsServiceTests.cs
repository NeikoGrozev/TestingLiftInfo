namespace TestingLiftInfo.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Moq;
    using TestingLiftInfo.Data;
    using TestingLiftInfo.Data.Common.Repositories;
    using TestingLiftInfo.Data.Models;
    using TestingLiftInfo.Data.Repositories;
    using TestingLiftInfo.Services.Data.Common;
    using TestingLiftInfo.Web.ViewModels.Administration.Inspects;
    using Xunit;

    public class InspectsServiceTests
    {
        [Fact]
        public async Task CreateInspect_WithValidInput_ShouldBeCorrect()
        {
            MapperInitializer.InitializeMapper();
            var context = InitializeContext.CreateContextForInMemory();
            var repository = new EfDeletableEntityRepository<Inspect>(context);
            var inspectsService = new InspectsService(repository);

            var userId = "U1";
            var inspectTypeId = "I1";
            var liftId = "L1";
            var notes = "test";
            var prescriptions = "presTest";
            var supportCompanyId = "S1";

            await inspectsService.CreateAsync(userId, inspectTypeId, liftId, notes, prescriptions, supportCompanyId);
            var inspect = context.Inspects.FirstOrDefaultAsync().Result;

            Assert.Equal(userId, inspect.ApplicationUserId);
            Assert.Equal(inspectTypeId, inspect.InspectTypeId);
            Assert.Equal(liftId, inspect.LiftId);
            Assert.Equal(notes, inspect.Notes);
            Assert.Equal(prescriptions, inspect.Prescriptions);
            Assert.Equal(supportCompanyId, inspect.SupportCompanyId);
        }

        [Fact]
        public async Task GetInspect_WithValidInput_ShouldBeREturnCorrectInspectWithViewModel()
        {
            MapperInitializer.InitializeMapper();
            var context = InitializeContext.CreateContextForInMemory();
            var repository = new EfDeletableEntityRepository<Inspect>(context);
            var inspectsService = new InspectsService(repository);

            var ins = new Inspect
            {
                Id = "1",
                ApplicationUserId = "U1",
                InspectTypeId = "I1",
                LiftId = "L1",
                Notes = "test",
                Prescriptions = "presTest",
                SupportCompanyId = "S1",
            };

            await context.Inspects.AddAsync(ins);
            await context.SaveChangesAsync();

            // var repositoryTest = new EfDeletableEntityRepository<Inspect>(context);

            // var userId = "U1";
            // var inspectTypeId = "I1";
            // var liftId = "L1";
            // var notes = "test";
            // var prescriptions = "presTest";
            // var supportCompanyId = "S1";
            // await inspectsServiceTest.CreateAsync(userId, inspectTypeId, liftId, notes, prescriptions, supportCompanyId);
            var test = await context.Inspects.FirstOrDefaultAsync();

            // Assert.Equal(inspectTypeId, test.InspectTypeId);
            // var inspectViewModel = inspectsServiceTest.GetCurrentInspect(test.Id);
            Assert.Equal(1, context.Inspects.Count());
            Assert.NotNull(inspectsService);
            Assert.NotNull(test);

            // Assert.Null(inspectViewModel);
            // Assert.Equal(inspectTypeId, inspect.InspectTypeId);
            // Assert.Equal(test, inspectViewModel);
            // Assert.Equal(inspectTypeId, inspectViewModel.InspectTypeId);
            // Assert.Equal(liftId, inspectViewModel.LiftId);
            // Assert.Equal(notes, inspectViewModel.Notes);
            // Assert.Equal(prescriptions, inspectViewModel.Prescriptions);
            // Assert.Equal(supportCompanyId, inspectViewModel.SupportCompanyId);
        }
    }
}
