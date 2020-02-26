using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoIHER.Models
{
    public class Bitacora
    {
        [Key]
        public int BitacoraID { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd} {0:hh:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "You must enter {0}")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Usuario")]
        public string AspNetUserID { get; set; }

        public int ObjetoID { get; set; }

        [Display(Name = "Accion")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(20, ErrorMessage = "The field {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string Accion { get; set; }

        [Display(Name = "Descripcion")]
        [DataType(DataType.MultilineText)]
        [StringLength(100, ErrorMessage = "The field {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string Descripcion { get; set; }

        public virtual ApplicationUser Usuario { get; set; }
        public virtual Objeto Objeto { get; set; }
    }
}