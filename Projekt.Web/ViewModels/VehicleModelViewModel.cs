namespace Projekt.Web.ViewModels
{
    public class VehicleModelViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int MakeId { get; set; }
        public virtual VehicleMakeViewModel VehicleMake { get; set; }
    }
}