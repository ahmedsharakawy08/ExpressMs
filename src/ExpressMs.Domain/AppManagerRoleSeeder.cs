using System;
using System.Threading.Tasks;
using ExpressMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Uow;
using IdentityRole = Volo.Abp.Identity.IdentityRole;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace Mercury.Identity
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IIdentityDataSeeder))]
    public class AppManagerRoleSeeder : ITransientDependency,IIdentityDataSeeder//: IdentityDataSeeder
    {
        private readonly IPermissionDataSeeder _permissionDataSeeder;

        protected IGuidGenerator GuidGenerator { get; }
        protected IIdentityRoleRepository RoleRepository { get; }
        protected IIdentityUserRepository UserRepository { get; }
        protected ILookupNormalizer LookupNormalizer { get; }
        protected IdentityUserManager UserManager { get; }
        protected IdentityRoleManager RoleManager { get; }
        protected ICurrentTenant CurrentTenant { get; }
        protected IOptions<IdentityOptions> IdentityOptions { get; }
        public AppManagerRoleSeeder(
            IGuidGenerator guidGenerator,
            IIdentityRoleRepository roleRepository,
            IIdentityUserRepository userRepository,
            ILookupNormalizer lookupNormalizer,
            IdentityUserManager userManager,
            IdentityRoleManager roleManager,
            ICurrentTenant currentTenant,
            IOptions<IdentityOptions> identityOptions)
        {
            GuidGenerator = guidGenerator;
            RoleRepository = roleRepository;
            UserRepository = userRepository;
            LookupNormalizer = lookupNormalizer;
            UserManager = userManager;
            RoleManager = roleManager;
            CurrentTenant = currentTenant;
            IdentityOptions = identityOptions;
        }

        [UnitOfWork]


      public virtual async Task<IdentityDataSeedResult> SeedAsync(string adminEmail, string adminPassword, Guid? tenantId = null, string? adminUserName = null)
        {

            using (CurrentTenant.Change(tenantId))
            {
                Check.NotNullOrWhiteSpace(adminEmail, nameof(adminEmail));
                Check.NotNullOrWhiteSpace(adminPassword, nameof(adminPassword));
                var result = new IdentityDataSeedResult();

                await IdentityOptions.SetAsync();

                //"admin" user
                 adminUserName = "admin";
                var adminUser = await UserRepository.FindByNormalizedUserNameAsync(
                    LookupNormalizer.NormalizeName(adminUserName)
                );

                if (adminUser == null)
                {
                    adminUser = new IdentityUser(GuidGenerator.Create(), adminUserName, adminEmail, tenantId)
                    {
                        Name = adminUserName
                    };
                    (await UserManager.CreateAsync(adminUser, adminPassword, validatePassword: false)).CheckErrors();
                    result.CreatedAdminUser = true;
                }

                //"admin" role
                const string adminRoleName = "admin";
                const string AppManagerRole = ExpressMsConsts.AppManagerRole;
                result.CreatedAdminRole = await EnsureStaticIdentityRoleCreatedAndAssigned(adminRoleName, tenantId, adminUser);
                await EnsureStaticIdentityRoleCreatedAndAssigned(AppManagerRole, tenantId, adminUser);
               
                return result;
            }
        }


        public async Task<bool> EnsureStaticIdentityRoleCreatedAndAssigned(string roleName, Guid? tenantId, IdentityUser user)
        {
            var role =
               await RoleRepository.FindByNormalizedNameAsync(LookupNormalizer.NormalizeName(roleName));
            bool exists = role != null;
            if (!exists)
            {
                role = new IdentityRole(GuidGenerator.Create(), roleName, tenantId)
                {
                    IsStatic = true,
                    IsPublic = true
                };

                (await RoleManager.CreateAsync(role)).CheckErrors();
                (await UserManager.AddToRoleAsync(user, roleName)).CheckErrors();
            }

            return exists;
        }


    }
}
