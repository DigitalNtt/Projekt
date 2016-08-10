using System.Collections.Generic;
using System.Threading.Tasks;
using Projekt.Model.Interface;
using Projekt.Repository.Filters;

namespace Projekt.Service.Interface
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<IVehicleMake>> GetAsync(VehicleMakeFilter filter = null);
        Task<IVehicleMake> GetAsync(int? id);
        Task<int> UpdateAsync(IVehicleMake vehicleMake);
    }
}
