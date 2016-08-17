using Projekt.Model.Interface;
using Projekt.Repository.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projekt.Repository.Interface
{
    public interface IVehicleMakeRepository
    {
        Task<IEnumerable<IVehicleMake>> GetAsync(VehicleMakeFilter filter = null);

        Task<IEnumerable<IVehicleMake>> GetAsync();

        Task<IVehicleMake> GetAsync(int id);

        Task<int> AddAsync(IVehicleMake VehicleMake);

        Task<int> UpdateAsync(IVehicleMake VehicleMake);

        Task<int> DeleteAsync(int? id);
    }
}