using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Uow;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;
using ExpressMs.Recruitment;
using Microsoft.EntityFrameworkCore;

namespace ExpressMs.EntityFrameworkCore;

[DependsOn(
    typeof(ExpressMsDomainModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpOpenIddictEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule)
    )]
public class ExpressMsEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        ExpressMsEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ExpressMsDbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also ExpressMsMigrationsDbContextFactory for EF Core tooling. */
            options.UseSqlServer();
        });
        Configure<AbpEntityOptions>(options =>
        {
            options.Entity<RecruitmentApplication>(orderOptions =>
            {
                orderOptions.DefaultWithDetailsFunc = query => query
                .Include(o => o.ApplicationAddressData)
                .Include(x => x.ApplicationEducations)
                .Include(x => x.ApplicationRefrence)
                .Include(x => x.ApplicationTrainings)
                .Include(x => x.ApplicationWorkExperieces)
                .Include(x => x.ComputerLanguageSkills)
                .Include(x => x.CompanyRelations)
                .Include(x => x.ApplicationDepartmentEvaluation)
                .Include(x => x.ApplicationPersonalEvaluation)
                .Include(x => x.InsuranceData)
                .Include(x => x.SalaryDetails)
                .Include(x=>x.Positions)
                .Include(x => x.PersonalEmergencyPeople)
                .Include(x => x.ApplicationPersonalEvaluation);
            });
            options.Entity<Department>(orderOptions =>
            {
                orderOptions.DefaultWithDetailsFunc = query => query
                .Include(o => o.Poitions);

            });
            options.Entity<Position>(orderOptions =>
            {
                orderOptions.DefaultWithDetailsFunc = query => query
                .Include(o => o.Department);

            });
        });
    }
}
