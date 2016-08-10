using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Model.Interface;
using Projekt.Repository.Filters;
using Projekt.Service.Interface;
using Projekt.Repository.Interface;

namespace Projekt.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        protected IVehicleMakeRepository Repository { get; private set; }
        public VehicleMakeService(IVehicleMakeRepository repository)
        {
            this.Repository = repository;
        }
        public virtual Task<IEnumerable<IVehicleMake>> GetAsync(VehicleMakeFilter filter = null)
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
        public Task<IVehicleMake> GetAsync(int? id)
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
        public async Task<int> UpdateAsync(IVehicleMake vehicleMake)
        {
            try
            {
                return await Repository.UpdateAsync(vehicleMake);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
