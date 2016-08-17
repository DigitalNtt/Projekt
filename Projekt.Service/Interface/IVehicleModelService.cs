using Projekt.Model.Interface;
using Projekt.Repository.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projekt.Service.Interface
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<IVehicleModel>> GetAsync(VehicleModelFilter filter = null);

        Task<IEnumerable<IVehicleModel>> GetAsync();

        Task<IVehicleModel> GetAsync(int id);

        Task<int> AddAsync(IVehicleModel VehicleModel);

        Task<int> UpdateAsync(IVehicleModel vehicleModel);

        Task<int> DeleteAsync(int? id);
    }
}