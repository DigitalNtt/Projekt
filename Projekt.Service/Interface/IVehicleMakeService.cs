using System.Collections.Generic;
using System.Threading.Tasks;
using Projekt.Model.Interface;
using Projekt.Repository.Filters;
using System;

namespace Projekt.Service.Interface
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<IVehicleMake>> GetAsync(VehicleMakeFilter filter = null);
        Task<IVehicleMake> GetAsync(Guid id);
        Task<int> UpdateAsync(IVehicleMake vehicleMake);
    }
}
