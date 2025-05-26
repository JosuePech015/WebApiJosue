using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace WebapiJosue.Context
{
    // Clase que representa el contexto de la base de datos para Entity Framework Core.
    // Hereda de DbContext, lo cual permite configurar y acceder a las tablas y relaciones de la base de datos.
    public class ApplicationDbContext : DbContext
    {
        // Constructor del contexto que recibe opciones de configuración (como cadena de conexión, proveedor, etc.)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        // Representación de la tabla 'Users' y 'Roles' en la base de datos
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Roles { get; set; }

        // Método sobrescrito para configurar el modelo y realizar inserciones iniciales en las tablas (datos semilla)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Inserta datos iniciales en la tabla 'Roles'
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PKRol = 1,
                    Name = "a" // Nombre del rol con clave primaria 1
                },
                new Rol
                {
                    PKRol = 2,
                    Name = "sa" // Nombre del rol con clave primaria 2
                });

            // Inserta datos iniciales en la tabla 'Users'
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    PKUser = 1,
                    Name = "David",
                    Username = "davi",
                    Password = "123",
                    FKRol = 2 // Asegúrate de que esta clave foránea corresponde a un Rol existente
                },
                new User
                {
                    PKUser = 2,
                    Name = "Jorge",
                    Username = "joge",
                    Password = "123",
                    FKRol = 1
                },
                new User
                {
                    PKUser = 3,
                    Name = "Yeriel",
                    Username = "cupi",
                    Password = "123",
                    FKRol = 1
                });
        }
    }
}
