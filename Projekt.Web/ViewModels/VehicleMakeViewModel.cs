using System.Collections.Generic;

namespace Projekt.Web.ViewModels
{
    public class VehicleMakeViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public virtual ICollection<VehicleModelViewModel> VehicleModels { get; set; }
    }
}