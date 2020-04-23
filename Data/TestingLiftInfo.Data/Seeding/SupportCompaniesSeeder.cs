namespace TestingLiftInfo.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TestingLiftInfo.Data.Models;

    public class SupportCompaniesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.SupportCompanies.Any())
            {
                var supportCompanies = new List<SupportCompany>()
                {
                    new SupportCompany()
                    {
                        Name = @"""Лифт БГ"" ЕООД",
                    },
                };

                await dbContext.AddRangeAsync(supportCompanies);
            }
        }
    }
}
