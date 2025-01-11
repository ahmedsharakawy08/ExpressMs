using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;

namespace ExpressMs.Vacations
{
    public class VacationRecords : Entity<Guid>
    {
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser Users { set; get; }
        public double Annual { get; set; }
        public double Casual {  get; set; }

    }
}
