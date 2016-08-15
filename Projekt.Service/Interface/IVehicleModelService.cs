using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Model.Interface;
using Projekt.Repository.Filters;


namespace Projekt.Service.Interface
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<IVehicleModel>> GetAsync(VehicleModelFilter filter = null);
        Task<IVehicleModel> GetAsync(Guid id);
        Task<int> UpdateAsync(IVehicleModel vehicleModel);
    }
}
