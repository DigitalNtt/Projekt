using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projekt.ViewModels
{
    public class VehicleModelViewModel
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
        public virtual VehicleMakeViewModel VehicleMake { get; set; }
    }
}