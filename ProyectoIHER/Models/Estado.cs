using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoIHER.Models
{
    public class Estado
    {
        [Key]
        public int EstadoID { get; set; }

        [Display(Name = "Estado")]
        public string EstadoName { get; set; }

        public string CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string ModificadoPor { get; set; }

        public DateTime FechaModificacion { get; set; }

        public virtual ICollection<GestionUsuarios> GestionUsuarios { get; set; }
    }
}