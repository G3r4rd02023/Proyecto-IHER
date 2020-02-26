using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoIHER.Models
{
    public class Parametro
    {
        [Key]
        public int ParametroID { get; set; }

        public string ParametroName { get; set; }

        public string Valor { get; set; }

        [Display(Name = "Usuario")]
        public string AspNetUserID { get; set; }

        [Display(Name = "Fecha Creacion")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        [Display(Name = "Fecha Modificacion")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime FechaModificacion { get; set; }

        public virtual ApplicationUser Usuario { get; set; }


    }
}