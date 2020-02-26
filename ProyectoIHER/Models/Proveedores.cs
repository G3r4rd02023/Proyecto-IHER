using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoIHER.Models
{
    public class Proveedores
    {
        [Key]
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        [Display (Name = "Direcion")]
        [Required]
        public string Direccion { get; set; }



    }
}