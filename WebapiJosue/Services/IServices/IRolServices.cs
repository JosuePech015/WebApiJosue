using Domain.Entities;

namespace WebapiJosue.Services.IServices
{
    // Interfaz que define los servicios relacionados con la entidad Rol.
    public interface IRolServices
    {

        Task<List<Rol>> GetRols(); // Devuelve una lista de todos los objetos Rol en la base de datos
        Task<Rol> GetByIdRol(int id); // Devuelve un objeto Rol que coincida con el ID proporcionado
        Task<Rol> CreateRol(Rol i);  // Crea un nuevo rol en la base de datos y devuelve el objeto creado
        Task<Rol> EditRol(Rol i); // Actualiza un rol ya existente con los nuevos datos proporcionados
        Task<bool> DeleteRol(int id); // Elimina un rol de la base de datos según su ID y devuelve true si fue exitoso
    }
}
