using ExpressMs.GenericEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ExpressMs.Settings
{
    public class GovernorateCitiesAppService : ExpressMsAppService
    {
        private readonly IRepository<City> _cityRepo;
        private readonly IRepository<Governorate> _governorateRepo;
        public GovernorateCitiesAppService(IRepository<City> cityRepo, IRepository<Governorate> governorateRepo)
        {
            _cityRepo = cityRepo;
            _governorateRepo = governorateRepo;
        }
        public async Task<List<Governorate>> GetGovernorates()
        {
            var data = await _governorateRepo.GetListAsync();
            return data;
        }
        public async Task<List<City>> GetCities()
        {
            var data = await _cityRepo.GetListAsync();
            return data;
        }
    }
}
