namespace TestingLiftInfo.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TestingLiftInfo.Data.Models;

    public class InspectTypesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.InspectTypes.Any())
            {
                var inspectTypes = new List<InspectType>()
                {
                    new InspectType()
                    {
                        Name = "Първоначален",
                    },
                    new InspectType()
                    {
                        Name = "Периодичен",
                    },
                    new InspectType()
                    {
                        Name = "След преустройство",
                    },
                    new InspectType()
                    {
                        Name = "След спиране за повече от 6 месеца",
                    },
                    new InspectType()
                    {
                        Name = "След замяна на основен компонент",
                    },
                    new InspectType()
                    {
                        Name = "След авария или злополука",
                    },
                    new InspectType()
                    {
                        Name = "Внезапен",
                    },
                    new InspectType()
                    {
                        Name = "Извънреден по желание на ползвателя",
                    },
                };

                await dbContext.AddRangeAsync(inspectTypes);
            }
        }
    }
}
