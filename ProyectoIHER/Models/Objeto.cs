using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoIHER.Models
{
    public class Objeto
    {
        [Key]
        public int ObjetoID { get; set; }

        [Display(Name = "Objeto")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(100, ErrorMessage = "The field {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string ObejtoName { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(100, ErrorMessage = "The field {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string Descripcion { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(15, ErrorMessage = "The field {0} must be between {1} and {2} characters", MinimumLength = 3)]
        public string TipoObjeto { get; set; }

        public virtual ICollection<Bitacora> Bitacoras { get; set; }

    }
}