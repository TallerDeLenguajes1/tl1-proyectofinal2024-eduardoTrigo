using System.Text.Json;
using EspacioFunciones;
using EspacioPersonajes;

namespace EspacioJson
{
    public static class PersonajeJson
    {
        //metodo para guardar la lista de pesonajes en un json
        public static void GuardarPersonajes(List<Personaje> personajes, string nombreArchivo)
        {
            string? jsonString = JsonSerializer.Serialize(personajes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(nombreArchivo, jsonString);
        }

        //metodo para leer el Json de personajes
        public static List<Personaje> LeerPersonajes(string nombreArchivo)
        {
            if (!File.Exists(nombreArchivo))
            {
                return new List<Personaje>();
            }

            string jsonString = File.ReadAllText(nombreArchivo);
            List<Personaje>? personajes = JsonSerializer.Deserialize<List<Personaje>>(jsonString);
            return personajes;
        }

        //metodo de validacion si existe el json
        public static bool Existe(string nombreArchivo)
        {
            return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
        }

        //metodo para verificar si existe el archivo json - si existe limpia y guarda nuevos datos. 
        public static void VerificaYguardaLosPersonajes(string nombreArchivo, List<Personaje> nuevosPersonajes)
        {
            if (Existe(nombreArchivo))
            {
                //borra si el archivo existe
                File.Delete(nombreArchivo);
            }

            //guarda los personajes
            GuardarPersonajes(nuevosPersonajes, nombreArchivo);
        }

        public static void MostrarPersonajesDesdeElJson(string archivoPersonajes)
        {
            if (Existe(archivoPersonajes))
            {
                List<Personaje> personajesDelJson = LeerPersonajes(archivoPersonajes);
                Console.WriteLine("Personajes contenidos en el archivo JSON:");
                foreach (var personaje in personajesDelJson)
                {
                    Funciones.MostrarDatosPersonaje(personaje);
                }
            }
        }
    }



}
