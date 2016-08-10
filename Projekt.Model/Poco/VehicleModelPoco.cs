using System.ComponentModel.DataAnnotations;
using Projekt.Model.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Model
{
    public class VehicleModelPoco : IVehicleModel
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(250)]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50)]
        public string Abrv { get; set; }

        [Display(Name = "Make")]
        public int MakeId { get; set; }

        [ForeignKey("MakeId")]
        public virtual IVehicleMake VehicleMake { get; set; }

    }
}
