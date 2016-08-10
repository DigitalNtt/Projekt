using System;
using Projekt.Repository.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;
using Projekt.Model.Interface;

namespace Projekt.Repository.Interface
{
    public interface IVehicleMakeRepository
    {
        Task<IEnumerable<IVehicleMake>> GetAsync(VehicleMakeFilter filter = null);
        Task<IVehicleMake> GetAsync(int? id);
        Task<int> UpdateAsync(IVehicleMake VehicleMake);
    }
}
