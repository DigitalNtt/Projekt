using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projekt.DAL.Models
{
    public class VehicleModel
    {
        [Key]
        public Int32 id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(250)]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50)]
        public string Abrv { get; set; }

        [Display(Name = "Make")]
        public Int32 MakeId { get; set; }

        [ForeignKey("MakeId")]
        public virtual VehicleMake VehicleMake { get; set; }

    }
}