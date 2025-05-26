using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Para decoradores como [ForeignKey]
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    // Esta clase representa la entidad de un usuario del sistema.
    public class User
    {
        [Key]
        public int PKUser { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [ForeignKey("Roles")]

        // Clave foránea que hace referencia a la tabla de roles.
        // El atributo [ForeignKey("Roles")] indica que esta propiedad se relaciona con la propiedad de navegación 'Roles'.
        public int? FKRol { get; set; }

        // Propiedad de navegación que representa el rol asociado al usuario.
        // Permite acceder a los datos del rol relacionado a través de la entidad 'Rol'.
        public Rol Roles { get; set; }
    }
}
