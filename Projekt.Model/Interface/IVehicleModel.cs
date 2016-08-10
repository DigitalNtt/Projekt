namespace Projekt.Model.Interface
{
    public interface IVehicleModel
    {
        int id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        int MakeId { get; set; }
        IVehicleMake VehicleMake { get; set; }
    }
}
