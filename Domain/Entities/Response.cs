using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    // Clase genérica que representa una respuesta estándar con estado, mensaje y datos (tipo T)
    public class Response<T>
    {    
        public Response() { } // Constructor vacío, permite crear una instancia sin inicializar propiedades

        public Response(T data, string message = null) // Constructor que inicializa una respuesta exitosa con datos y un mensaje opcional
        {
            Succeded = true; // Indica que la operación fue exitosa
            Message = message; // Mensaje informativo de la operación
            Result = data; // Resultado de tipo genérico T
        }

        public Response(string message) // Constructor que inicializa una respuesta fallida con solo un mensaje
        {
            Succeded = false; // Indica que la operación no fue exitosa
            Message = message; // Mensaje de error o advertencia
        }

        // Propiedad que indica si la operación fue exitosa (true) o fallida (false)
        public bool Succeded { get; set; }

        // Propiedad que contiene un mensaje asociado a la respuesta (éxito o error)
        public string Message { get; set; }

        // Propiedad que contiene el resultado de tipo genérico T
        public T Result { get; set; }
    }
}
