using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Se usa para decoradores como [Key]
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    // Definición de la clase 'Rol' dentro del espacio de nombres Domain.Entities.
    // Representa una entidad de rol, que puede estar asociada a un usuario o permiso dentro del sistema.
    public class Rol
    {
        // Esto indica que 'PKRol' es el identificador único en la base de datos
        [Key]
        public int PKRol { get; set; }
        public string Name { get; set; }
    }
}
