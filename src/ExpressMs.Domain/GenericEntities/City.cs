using Volo.Abp.Domain.Entities;

namespace ExpressMs.GenericEntities
{
    public  class City:Entity<int>
    {
        public string Name { set; get; }
        public City(string name)
        {
            Name = name;
        }
    }
}
