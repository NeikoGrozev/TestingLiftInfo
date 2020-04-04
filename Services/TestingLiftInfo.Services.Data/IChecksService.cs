namespace TestingLiftInfo.Services.Data
{
    using System;

    public interface IChecksService
    {
        DateTime? GetValidInspect(string registrationNumber);
    }
}
