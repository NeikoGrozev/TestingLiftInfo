namespace TestingLiftInfo.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using TestingLiftInfo.Common;
    using TestingLiftInfo.Data;
    using TestingLiftInfo.Web.ViewModels.Administration.Admin;

    public class AdminController : AdministrationController
    {
        private readonly ApplicationDbContext dbContext;

        public AdminController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult AddAdmin()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmin(AddAdminViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var admin = this.dbContext.Roles
                .FirstOrDefault(x => x.Name == GlobalConstants.AdministratorRoleName);
            var user = this.dbContext.Users
                .FirstOrDefault(x => x.Email == model.Email);

            if (admin != null && user != null)
            {
                await this.dbContext.UserRoles
                    .AddAsync(new IdentityUserRole<string>
                    {
                        UserId = user.Id,
                        RoleId = admin.Id,
                    });

                await this.dbContext.SaveChangesAsync();

                return this.View("AdminCreateAdmin");
            }
            else if (user != null)
            {
                var isAdmin = this.dbContext.UserRoles
                    .FirstOrDefault(x => x.RoleId == admin.Id && x.UserId == user.Id);

                if (isAdmin == null)
                {
                    await this.dbContext.UserRoles
                        .AddAsync(new IdentityUserRole<string>
                        {
                            UserId = user.Id,
                            RoleId = admin.Id,
                        });

                    await this.dbContext.SaveChangesAsync();

                    return this.View("AdminCreateAdmin");
                }
            }

            return this.RedirectToAction("AddAdmin");
        }

        public IActionResult All()
        {
            var adminRole = this.dbContext.Roles
                .Where(x => x.Name == GlobalConstants.AdministratorRoleName)
                .FirstOrDefault();
            var user = this.dbContext.Users
                .OrderBy(x => x.Name)
                .Where(x => x.Roles.Any(y => y.RoleId == adminRole.Id) && x.Name != "Admin")
                .ToList();

            var viewModel = new GetAllAdminViewModel()
            {
                Users = user,
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var userRole = this.dbContext.UserRoles
                .FirstOrDefault(x => x.UserId == id);

            if (userRole != null)
            {
                var userTEst = this.dbContext.Users
                    .Where(x => x.Id == id)
                    .FirstOrDefault()
                    .Roles.Remove(userRole);

                this.dbContext.UserRoles.Remove(userRole);
                await this.dbContext.SaveChangesAsync();
            }

            return this.RedirectToAction("All");
        }
    }
}
