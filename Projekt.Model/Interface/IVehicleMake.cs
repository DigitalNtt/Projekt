using System.Collections.Generic;

namespace Projekt.Model.Interface
{
    public interface IVehicleMake
    {
        int id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        ICollection<IVehicleModel> VehicleModels { get; set; }
    }
}