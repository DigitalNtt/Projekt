using Projekt.Model.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Model
{
    public class VehicleMakePoco : IVehicleMake
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(250)]
        [Display(Name = "Make")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50)]
        public string Abrv { get; set; }

        public virtual ICollection<IVehicleModel> VehicleModels { get; set; }
    }
}