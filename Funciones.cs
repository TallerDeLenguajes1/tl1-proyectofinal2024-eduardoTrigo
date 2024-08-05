using System.ComponentModel.DataAnnotations;
using EspacioDatos;
using EspacioPersonajes;
using EspacioTasks;

namespace EspacioFunciones
{
    class Funciones
    {
        //Funcion Para seleccionar tipo de Personaje.
        public static TipoPersonaje SeleccionarTipoPersonaje()
        {
            string[] tipo = Enum.GetNames(typeof(TipoPersonaje));
            Console.WriteLine("Elige un tipo de personaje");
            for (int i = 0; i < tipo.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {tipo[i]}");
            }

            int opcion;
            bool esValido = int.TryParse(Console.ReadLine(), out opcion) && opcion > 0 && opcion <= tipo.Length;
            while (!esValido)
            {
                Console.WriteLine("Opcion no valida, elije nuevamente");
                esValido = int.TryParse(Console.ReadLine(), out opcion) && opcion > 0 && opcion <= tipo.Length;

            }
            return (TipoPersonaje)Enum.Parse(typeof(TipoPersonaje), tipo[opcion - 1]);
        }

        //funcion para asignar Tipo de Oponentes.
        public static TipoPersonaje AsignarOponentes(TipoPersonaje tipo)
        {
            TipoPersonaje oponentes;
            if (tipo == TipoPersonaje.Plantas)
            {
                oponentes = TipoPersonaje.Zombies;
            }else
            {
                oponentes = TipoPersonaje.Plantas;
            }

            return oponentes;
        }

        //Funcion Para Seleccionar el Personaje
        public static async Task<string> ElegirNombrePersonaje(TipoPersonaje tipo)
        {
            string tipoPlayer;
            if (tipo == TipoPersonaje.Plantas)
            {
                tipoPlayer = "plants";
            }
            else
            {
                tipoPlayer = "zombies";
            }

            //Lista 10 Personajes traidos desde la api
            List<string> nombres = await Tasks.GetNombrePersonajes(tipoPlayer);
            for (int i = 0; i < Math.Min(10, nombres.Count); i++)
            {
                Console.WriteLine($"{i + 1}) {nombres[i]}");
            }

            int opcion;
            //Valida si la opcion ingresada es la correcta
            bool esValido = int.TryParse(Console.ReadLine(), out opcion) && opcion > 0 && opcion <= 10;
            while (!esValido)
            {
                Console.WriteLine("opcion No valida, elija nuevamente");
                esValido = int.TryParse(Console.ReadLine(), out opcion) && opcion > 0 && opcion <= 10;
            }
            return nombres[opcion - 1];
        }

        public static void MostrarDatosPersonaje(Personaje Player)
        {
            Console.WriteLine($"Nombre: {Player.Datos.Nombre}");
            Console.WriteLine($"Tipo: {Player.Datos.Tipo}");
            Console.WriteLine($"Edad: {Player.Datos.Edad}");
            Console.WriteLine($"---Caracteriesticas-----");
            Console.WriteLine($"   Velocidad: {Player.Caracteristicas.Velocidad}");
            Console.WriteLine($"   Destreza: {Player.Caracteristicas.Destreza}");
            Console.WriteLine($"   Fuerza: {Player.Caracteristicas.Fuerza}");
            Console.WriteLine($"   Nivel: {Player.Caracteristicas.Nivel}");
            Console.WriteLine($"   Armadura: {Player.Caracteristicas.Armadura}");
            Console.WriteLine($"   Salud: {Player.Caracteristicas.Salud}");
        }

    }
}