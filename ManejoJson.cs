using System.Text.Json;
using EspacioDatos;
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

        //metodo para leer el Json de personajes y carga en la lista
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


        //extrae del personajes.json los datos y los coloca en la lista para recorrela y mostrarlo por pantalla
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

        //metodo que guarda los datos en el archivo json historial
        public static void GuardarHistorialEnfrentamiento(List<HistorialEnfrentamiento> historial, string nombreArchivo)
        {
            string? jsonHistorial = JsonSerializer.Serialize(historial, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(nombreArchivo, jsonHistorial);
        }

        //metodo para leer el Json de historial y carga en la lista
        public static List<HistorialEnfrentamiento> LeerHistorial(string nombreArchivo)
        {
            if (!File.Exists(nombreArchivo))
            {
                return new List<HistorialEnfrentamiento>();
            }

            string jsonHistorial = File.ReadAllText(nombreArchivo);
            List<HistorialEnfrentamiento>? historial = JsonSerializer.Deserialize<List<HistorialEnfrentamiento>>(jsonHistorial);
            return historial;
        }

        //metodo para guardar los gandores en un Json
        public static void GuardarGanadores(List<string> ganadores, string nombreArchivo)
        {
            string jsonGanadores = JsonSerializer.Serialize(ganadores, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(nombreArchivo, jsonGanadores);
        }

        //metodo que lee el json del historial y carga en una lista de string
        public static List<string> LeerGanadores(string nombreArchivo){
            if(!File.Exists(nombreArchivo)){
                return new List<string>();
            }

            string jsonGanadores = File.ReadAllText(nombreArchivo);
            List<string>? Ganadores = JsonSerializer.Deserialize<List<string>>(jsonGanadores);
            return Ganadores;
        }
    }
}
