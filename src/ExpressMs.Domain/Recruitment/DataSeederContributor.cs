using ExpressMs.GenericEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExpressMs.Recruitment
{
    public class DataSeederContributor:IDataSeedContributor,ITransientDependency
    {
        private readonly IRepository<Governorate> _governorateRepo;
        private readonly IRepository<City> _cityRepository;
        public DataSeederContributor(IRepository<Governorate> governorateRepo, IRepository<City> cityRepository)
        {
            _governorateRepo = governorateRepo;
            _cityRepository = cityRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            await _governorateRepo.DeleteAsync(obj => obj.GovernorateNameEn != "");
            await _governorateRepo.DeleteAsync(obj => obj.GovernorateNameEn != "");
            var governorates = new List<Governorate>() { new Governorate("القاهرة", "Cairo") };
            var cities = new List<City>() { new City ("15 مايو") };
            await  _governorateRepo.InsertManyAsync(governorates);
            await _cityRepository.InsertManyAsync(cities);
        }
    }
}
