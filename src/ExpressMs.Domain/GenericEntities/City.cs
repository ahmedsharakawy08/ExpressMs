using ExpressMs.Recruitment;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace ExpressMs.GenericEntities
{
    public  class City:Entity<int>
    {
        public string Name { set; get; }

        public int GovernorateId { get; set; }
        [ForeignKey("GovernorateId")]
        public virtual Governorate Governorate { set; get; }
        public City(string name)
        {
            Name = name;
        }
        public City()
        {
        }
    }
}
