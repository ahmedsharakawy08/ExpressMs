using ExpressMs.EntityFrameworkCore;
using ExpressMs.PayrollEntities;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ExpressMs.Payrolls
{
    public class EfCorePayrollPayslipRepository : EfCoreRepository<ExpressMsDbContext, PayrollPaySlip>, IPayrollPayslipRepository
    {
        public EfCorePayrollPayslipRepository(IDbContextProvider<ExpressMsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
