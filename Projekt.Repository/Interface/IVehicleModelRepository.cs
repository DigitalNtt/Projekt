using System.Collections.Generic;
using System.Threading.Tasks;
using Projekt.Model.Interface;
using Projekt.Repository.Filters;

namespace Projekt.Repository.Interface
{
    public interface IVehicleModelRepository
    {
        Task<IEnumerable<IVehicleModel>> GetAsync(VehicleModelFilter filter = null);
        Task<IVehicleModel> GetAsync(int id);
        Task<int> UpdateAsync(IVehicleModel VehicleModel);
    }
}
