using Ninject;
using Projekt.Model.Interface;
using Projekt.Repository.Filters;
using Projekt.Repository.Interface;
using Projekt.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projekt.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        protected IVehicleMakeRepository Repository { get; private set; }

        [Inject]
        public VehicleMakeService(IVehicleMakeRepository repository)
        {
            this.Repository = repository;
        }

        public virtual Task<IEnumerable<IVehicleMake>> GetAsync()
        {

                return Repository.GetAsync();

        }

        public virtual Task<IEnumerable<IVehicleMake>> GetAsync(VehicleMakeFilter filter = null)
        {

                return Repository.GetAsync(filter);
            
        }

        public Task<IVehicleMake> GetAsync(int id)
        {

                return Repository.GetAsync(id);

        }

        public async Task<int> AddAsync(IVehicleMake vehicleMake)
        {

                return await Repository.AddAsync(vehicleMake);

        }

        public async Task<int> UpdateAsync(IVehicleMake vehicleMake)
        {

                return await Repository.UpdateAsync(vehicleMake);

        }

        public async Task<int> DeleteAsync(int? id)
        {

                return await Repository.DeleteAsync(id);

        }
    }
}