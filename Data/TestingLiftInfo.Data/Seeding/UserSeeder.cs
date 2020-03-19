namespace TestingLiftInfo.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    internal class UserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Users.Count() == 1 && !dbContext.UserRoles.Any())
            {
                var admin = dbContext.Roles.FirstOrDefault(x => x.Name == "Administrator");
                var user = dbContext.Users.FirstOrDefault(x => x.Email == "admin@gmail.com");

                await dbContext.UserRoles.AddAsync(new IdentityUserRole<string> { UserId = user.Id, RoleId = admin.Id });
            }
        }
    }
}
