using Projekt.Model.Interface;
using Projekt.Repository.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projekt.Repository.Interface
{
    public interface IVehicleModelRepository
    {
        Task<IEnumerable<IVehicleModel>> GetAsync(VehicleModelFilter filter = null);

        Task<IEnumerable<IVehicleModel>> GetAsync();

        Task<IVehicleModel> GetAsync(int id);

        Task<int> AddAsync(IVehicleModel VehicleModel);

        Task<int> UpdateAsync(IVehicleModel VehicleModel);

        Task<int> DeleteAsync(int? id);
    }
}