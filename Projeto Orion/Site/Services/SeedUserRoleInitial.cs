using Microsoft.AspNetCore.Identity;

namespace OrionTM_Web.Services
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial


    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedRoles()
        {
            
            if(!_roleManager.RoleExistsAsync("Usuario").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Usuario";
                role.NormalizedName = "USUARIO";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }


            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

        }

        public void SeedUsers()
        {
                        
                if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
                {

                    IdentityUser user = new IdentityUser();
                    user.UserName = "orion@admin";
                    user.Email = "orion@admin";
                    user.NormalizedUserName = "ORION@ADMIN";
                    user.NormalizedEmail = "ORION@ADMIN";
                    user.SecurityStamp = Guid.NewGuid().ToString();
                    user.EmailConfirmed = true;
                    user.LockoutEnabled = false;

                    IdentityResult result = _userManager.CreateAsync(user, "Orion#Admin1").Result;

                    if (result.Succeeded)
                    {
                        _userManager.AddToRoleAsync(user, "Admin").Wait();

                    }

                }
         }
    }
}
