using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    // Clase DTO (Data Transfer Object) para representar los datos que se transfieren relacionados con un usuario
    public class UserRequest
    {
        // Propiedad que representa la clave primaria del usuario
        public int PKUser { get; set; }
        public string Name { get; set; } // Propiedad para el nombre de usuario
        public string Username { get; set; } // Propiedad para el nombre de usuario (usado para inicio de sesión u otras identificaciones)
        public string Password { get; set; } // Propiedad para la contraseña del usuario
        public int? FKRol { get; set; } // Propiedad que representa la clave foránea al rol del usuario (nullable en caso de que no tenga rol asignado)
    }
}
