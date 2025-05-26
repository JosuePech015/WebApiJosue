using Microsoft.AspNetCore.Mvc;
using WebapiJosue.Services.IServices;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.DTO;

namespace WebapiJosue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        // Campo privado que representa el servicio de usuarios
        private readonly IUserServices _userServices;

        // Constructor que recibe el servicio por inyección de dependencias
        // Esto permite usar los métodos definidos en IUserServices en todo el controlador
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        // ---------------------- GET: Obtener todos los usuarios ----------------------
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            // Llama al servicio para obtener todos los usuarios desde la base de datos
            var users = await _userServices.GetUsers();

            // Retorna la lista de usuarios con estado 200 OK
            return Ok(users);
        }

        // ---------------------- GET: Obtener un usuario por ID ----------------------
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            // Llama al servicio para obtener un usuario por ID
            var user = await _userServices.GetByIdUser(id);

            // Si no se encuentra, retorna 404 Not Found
            if (user == null)
                return NotFound($"No se encontró un usuario con ID {id}.");

            // Retorna el usuario encontrado con estado 200 OK
            return Ok(user);
        }

        // ---------------------- POST: Crear un nuevo usuario ----------------------
        [HttpPost("crear")]
        public async Task<IActionResult> PostUser([FromBody] UserRequest request)
        {
            // Verifica si el modelo recibido es válido
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Llama al servicio para crear el usuario
            var createdUser = await _userServices.CreateUser(request);

            // Retorna el nuevo usuario creado con estado 201 Created y la ruta del nuevo recurso
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.PKUser }, createdUser);
        }

        // ---------------------- PUT: Actualizar un usuario existente ----------------------
        [HttpPut("editar/{id:int}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] UserRequest request)
        {
            // Verifica que el ID en la URL coincida con el del cuerpo del request
            if (id != request.PKUser)
                return BadRequest("El ID en la URL no coincide con el ID del cuerpo.");

            // Llama al servicio para editar el usuario
            var updatedUser = await _userServices.EditUser(request);

            // Si no se pudo actualizar (usuario no encontrado), retorna 404 Not Found
            if (updatedUser == null)
                return NotFound($"No se pudo actualizar el usuario con ID {id}.");

            // Retorna el usuario actualizado con estado 200 OK
            return Ok(updatedUser);
        }

        // ---------------------- DELETE: Eliminar un usuario por ID ----------------------
        [HttpDelete("eliminar/{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            // Llama al servicio para eliminar el usuario por ID
            var deleted = await _userServices.DeleteUser(id);

            // Si no se eliminó (usuario no encontrado), retorna 404 Not Found
            if (!deleted)
                return NotFound($"No se encontró el usuario con ID {id} para eliminar.");

            // Retorna mensaje de éxito con estado 200 OK
            return Ok(new { message = $"Usuario con ID {id} eliminado correctamente." });
        }
    }
}
