using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoIHER.Models
{
    public class Rol
    {
        [Key]
        public int RolID { get; set; }

        [Display(Name = "Rol")]
        public string RolName { get; set; }

        public virtual ICollection<GestionUsuarios> GestionUsuarios { get; set; }
    }
}