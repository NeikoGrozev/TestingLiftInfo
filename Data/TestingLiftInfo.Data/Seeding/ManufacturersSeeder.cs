namespace TestingLiftInfo.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using TestingLiftInfo.Data.Models;

    public class ManufacturersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Manufacturers.Any())
            {
                var manufacturers = new List<Manufacturer>()
                {
                    new Manufacturer()
                    {
                        Name = "Otis",
                    },
                    new Manufacturer()
                    {
                        Name = "Schindler",
                    },
                    new Manufacturer()
                    {
                        Name = "Thyssenkrupp",
                    },
                    new Manufacturer()
                    {
                        Name = "Kone",
                    },
                    new Manufacturer()
                    {
                        Name = "Mitsubishi",
                    },
                    new Manufacturer()
                    {
                        Name = "Fuji",
                    },
                };

                await dbContext.AddRangeAsync(manufacturers);
            }
        }
    }
}
