using ExpressMs.GenericEntities;
using ExpressMs.PayrollEntities;
using ExpressMs.Recruitment;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace ExpressMs.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class ExpressMsDbContext :
    AbpDbContext<ExpressMsDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<PayrollPaySlip>PayrollPaySlip { get; set; }
    public DbSet<RecruitmentApplication> RecruitmentApplication { get; set; }
    public DbSet<Position> Position { get; set; }
    public DbSet<Department> Department { get; set; }
    public DbSet<ApplicationWorkExperiece> ApplicationWorkExperiece { set; get; }
    public DbSet<RecruitmentApplicationEducation> RecruitmentApplicationEducation { set; get; }
    public DbSet<ApplicationTraining> ApplicationTraining { set; get; }
    public DbSet<ComputerLanguageSkills> ComputerLanguageSkills { set; get; }
    public DbSet<ApplicationRefrence> ApplicationRefrence { set; get; }
    public DbSet<CompanyRelations> CompanyRelations { set; get; }
    public DbSet<ApplicationAddressData> ApplicationAddressData { set; get; }
    public DbSet<Governorate> Governorate { set; get; }
    public DbSet<City> City { set; get; }
    public DbSet<ApplicationPersonalEvaluation> ApplicationPersonalEvaluation { set; get; }
    public DbSet<ApplicationDepartmentEvaluation> ApplicationDepartmentEvaluation { set; get; }
    public DbSet<SalaryDetails> SalaryDetails { set; get; }
    public DbSet<InsuranceData> InsuranceData { set; get; }
    








    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }
    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public ExpressMsDbContext(DbContextOptions<ExpressMsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(ExpressMsConsts.DbTablePrefix + "YourEntities", ExpressMsConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        builder.Entity<PayrollPaySlip>(b =>
        {
            b.ToTable(ExpressMsConsts.DbTablePrefix + "PayrollPaySlips", ExpressMsConsts.DbSchema);            
        });
        builder.Entity<Position>(b =>
        {
            b.ToTable(ExpressMsConsts.DbTablePrefix + "Positions", ExpressMsConsts.DbSchema);
        });
        builder.Entity<Department>(b =>
        {
            b.ToTable(ExpressMsConsts.DbTablePrefix + "Departments", ExpressMsConsts.DbSchema);
        });
        builder.Entity<RecruitmentApplication>(b =>
        {
            b.ToTable(ExpressMsConsts.DbTablePrefix + "RecruitmentApplications", ExpressMsConsts.DbSchema);
        });
        builder.Entity<ApplicationWorkExperiece>(b =>
        {
            b.ToTable(ExpressMsConsts.DbTablePrefix + "ApplicationWorkExperieces", ExpressMsConsts.DbSchema);
        });
        builder.Entity<RecruitmentApplicationEducation>(b =>
        {
            b.ToTable(ExpressMsConsts.DbTablePrefix + "RecruitmentApplicationEducations", ExpressMsConsts.DbSchema);
        });
        builder.Entity<ApplicationTraining>(b =>
        {
            b.ToTable(ExpressMsConsts.DbTablePrefix + "ApplicationTrainings", ExpressMsConsts.DbSchema);
        });
        builder.Entity<ComputerLanguageSkills>(b =>
        {
            b.ToTable(ExpressMsConsts.DbTablePrefix + "ComputerLanguageSkills", ExpressMsConsts.DbSchema);
        });
        builder.Entity<ApplicationRefrence>(b =>
        {
            b.ToTable(ExpressMsConsts.DbTablePrefix + "ApplicationRefrences", ExpressMsConsts.DbSchema);
        });
        builder.Entity<CompanyRelations>(b =>
        {
            b.ToTable(ExpressMsConsts.DbTablePrefix + "CompanyRelations", ExpressMsConsts.DbSchema);
        });
        builder.Entity<ApplicationAddressData>(b =>
        {
            b.ToTable(ExpressMsConsts.DbTablePrefix + "ApplicationAddressData", ExpressMsConsts.DbSchema);
        });
        builder.Entity<Governorate>(b =>
        {
            b.ToTable(ExpressMsConsts.DbTablePrefix + "Governorates", ExpressMsConsts.DbSchema);
        });
        builder.Entity<City>(b =>
        {
            b.ToTable(ExpressMsConsts.DbTablePrefix + "Cities", ExpressMsConsts.DbSchema);
        });
        builder.Entity<ApplicationDepartmentEvaluation>(b =>
        {
            b.ToTable(ExpressMsConsts.DbTablePrefix + "ApplicationDepartmentEvaluations", ExpressMsConsts.DbSchema);
        });
        builder.Entity<ApplicationPersonalEvaluation>(b =>
        {
            b.ToTable(ExpressMsConsts.DbTablePrefix + "ApplicationPersonalEvaluations", ExpressMsConsts.DbSchema);
        });

        builder.Entity<SalaryDetails>(b =>
        {
            b.ToTable(ExpressMsConsts.DbTablePrefix + "SalaryDetails", ExpressMsConsts.DbSchema);
        });
        builder.Entity<InsuranceData>(b =>
        {
            b.ToTable(ExpressMsConsts.DbTablePrefix + "InsuranceData", ExpressMsConsts.DbSchema);
        });
        builder.Entity<RecruitmentApplication>(b =>
        {
            b.ToTable("ExRecruitmentApplications");
            b.ConfigureByConvention();

            //Define the relation
           // b.HasMany(x => x.ApplicationEducations).WithOne(x => x.RecruitmentApplication).HasForeignKey(x => x.ApplicationId);
           //b.HasMany(x => x.ApplicationRefrence);
            b.HasMany(x => x.ApplicationTrainings).WithOne(x=>x.RecruitmentApplication).HasForeignKey(x=>x.ApplicationId);
          //  b.HasMany(x => x.CompanyRelations);
            //b.HasMany(x => x.ComputerLanguageSkills);
            //b.HasOne(x => x.ApplicationAddressData);
            //b.HasMany(x => x.ApplicationWorkExperieces);

        });

    }
}
