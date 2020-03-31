namespace TestingLiftInfo.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TestingLiftInfo.Data.Models;

    public class CitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Cities.Any())
            {
                var cities = new List<City>()
                {
                    new City()
                    {
                        Name = "София",
                    },
                    new City()
                    {
                        Name = "Пловдив",
                    },
                    new City()
                    {
                        Name = "Варна",
                    },
                    new City()
                    {
                        Name = "Бургас",
                    },
                    new City()
                    {
                        Name = "Русе",
                    },
                    new City()
                    {
                        Name = "Стара Загора",
                    },
                };

                await dbContext.AddRangeAsync(cities);
            }
        }
    }
}
