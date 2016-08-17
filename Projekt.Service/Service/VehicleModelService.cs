using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Service.Interface;
using Projekt.Repository.Repositories;
using Projekt.Repository.Interface;
using Projekt.Model.Interface;
using Projekt.Repository.Filters;
using Ninject;

namespace Projekt.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        protected IVehicleModelRepository Repository { get; private set; }

        [Inject]
        public VehicleModelService(IVehicleModelRepository repository)
        {
            this.Repository = repository;
        }
        public virtual Task<IEnumerable<IVehicleModel>> GetAsync()
        {
            try
            {
                return Repository.GetAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public virtual Task<IEnumerable<IVehicleModel>> GetAsync(VehicleModelFilter filter = null)
        {
            try
            {
                return Repository.GetAsync(filter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Task<IVehicleModel> GetAsync(int id)
        {
            try
            {
                return Repository.GetAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<int> AddAsync(IVehicleModel vehicleModel)
        {
            try
            {
                return await Repository.AddAsync(vehicleModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<int> UpdateAsync(IVehicleModel vehicleModel)
        {
            try
            {
                return await Repository.UpdateAsync(vehicleModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> DeleteAsync(int? id)
        {
            try
            {
                return await Repository.DeleteAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
