using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoIHER.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }

        [Display(Name = "RTN")]
        [Required(ErrorMessage = "You must enter {0}")]
        public string ClienteRTN { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(30, ErrorMessage = "The field {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string  ClienteNombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(30, ErrorMessage = "The field {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string  ClienteApellido { get; set; }

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "You must enter {0}")]
        [DataType(DataType.MultilineText)]
        public string  Direccion { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "You must enter {0}")]
        public string Telefono { get; set; }

        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        [Display(Name = "Nacionalidad")]
        [Required(ErrorMessage = "You must enter {0}")]
        public int NacionalidadID { get; set; }


        public virtual Nacionalidad Nacionalidad { get; set; }





    }
}