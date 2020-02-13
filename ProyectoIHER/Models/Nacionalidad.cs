using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoIHER.Models
{
    public class Nacionalidad
    {
        [Key]
        public int NacionalidadID { get; set; }

        [Display(Name = "Nacionalidad")]
        [Required(ErrorMessage = "You must enter {0}")]
        public string Descripcion { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}