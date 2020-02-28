using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoIHER.Models
{
    public class PreguntasUsuario
    {
        [Key]
        public int PreguntasUsuarioID { get; set; }

        [Display(Name = "Respuesta")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(100, ErrorMessage = "The field {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string Respuesta { get; set; }

        public int PreguntaID { get; set; }

        [Display(Name = "Usuario")]
        public string AspNetUserID { get; set; }

        public string CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string ModificadoPor { get; set; }

        public DateTime FechaModificacion { get; set; }

        public virtual Preguntas Preguntas { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
    }
}