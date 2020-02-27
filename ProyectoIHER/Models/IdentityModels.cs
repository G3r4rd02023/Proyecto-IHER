using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProyectoIHER.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }

        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string FullName { get; set; }

        [Display(Name = "Direccion")]
        public string Address { get; set; }

        public virtual List<PreguntasUsuario> PreguntasUsuario { get; set; }
        public virtual List<Bitacora> Bitacoras { get; set; }
        public virtual List<Parametro> Parametros { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ProyectoIHER.Models.Preguntas> Preguntas { get; set; }

        public System.Data.Entity.DbSet<ProyectoIHER.Models.PreguntasUsuario> PreguntasUsuarios { get; set; }

        public System.Data.Entity.DbSet<ProyectoIHER.Models.Bitacora> Bitacoras { get; set; }

        public System.Data.Entity.DbSet<ProyectoIHER.Models.Objeto> Objetoes { get; set; }

        public System.Data.Entity.DbSet<ProyectoIHER.Models.Parametro> Parametroes { get; set; }

        public System.Data.Entity.DbSet<ProyectoIHER.Models.Estado> Estadoes { get; set; }

        public System.Data.Entity.DbSet<ProyectoIHER.Models.Rol> Rols { get; set; }

        public System.Data.Entity.DbSet<ProyectoIHER.Models.GestionUsuarios> GestionUsuarios { get; set; }
    }
}