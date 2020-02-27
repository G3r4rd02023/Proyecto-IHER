using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoIHER.Models
{
    public class GestionUsuarios
    {
        [Key]
        public int GestionUsuarioID { get; set; }

        [Display(Name = "Nombre Completo")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(30, ErrorMessage = "The field {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string NombreUsuario { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(30, ErrorMessage = "The field {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string UserName { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "You must enter {0}")]
        public string Telefono { get; set; }

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "You must enter {0}")]
        [DataType(DataType.MultilineText)]
        public string Direccion { get; set; }

        [Display(Name = "Rol")]
        public string RolID { get; set; }

        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaVencimiento { get; set; }

        [Display(Name = "Estado")]
        public int EstadoID { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual Rol Rol { get; set; }

    }
}