namespace TestingLiftInfo.Services.Data
{
    using System;
    using System.Threading.Tasks;

    public interface IChecksService
    {
        Task<DateTime?> GetValidInspect(string registrationNumber);
    }
}
