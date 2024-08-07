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
            string[] tipo = Enum.GetNames(typeof(TipoPersonaje));//trae los tipos de personajes desde un enum
            Console.WriteLine("Elige un tipo de personaje");
            for (int i = 0; i < tipo.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {tipo[i]}");
            }

            int opcion;
            bool esValido = int.TryParse(Console.ReadLine(), out opcion) && opcion > 0 && opcion <= tipo.Length;// verifica si el valor ingresado es valido
            while (!esValido)  // si lo ingresado no es valido pide nuevamente que ingrese un numero
            {
                Console.WriteLine("Opcion no valida, elije nuevamente");
                esValido = int.TryParse(Console.ReadLine(), out opcion) && opcion > 0 && opcion <= tipo.Length;

            }
            return (TipoPersonaje)Enum.Parse(typeof(TipoPersonaje), tipo[opcion - 1]);
        }

        //funcion para asignar Tipo de Oponentes contrario a la eleccion de tipo de personaje.
        public static TipoPersonaje AsignarOponentes(TipoPersonaje tipo)
        {
            TipoPersonaje oponentes;
            if (tipo == TipoPersonaje.Plantas)
            {
                oponentes = TipoPersonaje.Zombies;
            }
            else
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

        public static void ListarInicioOponentes(List<Personaje> lista)
        {
            bool continuar = false;
            int opcion;
            do
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {lista[i].Datos.Nombre}");
                }

                Console.WriteLine("\n-Presione ENTER para continuar con la lucha contra el oponente número 1");
                Console.WriteLine("-O elija el número del oponente para mostrar sus datos y características:\n");

                var teclaPresionada = Console.ReadKey(intercept: true); // No me muestra por pantalla lo tipeado

                if (teclaPresionada.Key == ConsoleKey.Enter)
                {
                    continuar = true;
                }
                else if (int.TryParse(teclaPresionada.KeyChar.ToString(), out opcion) && opcion > 0 && opcion <= lista.Count)
                {
                    Personaje opcionOponente = lista[opcion - 1];
                    Funciones.MostrarDatosPersonaje(opcionOponente);
                }
                else
                {
                    Console.WriteLine("\nOpcion no valida. Intentalo de nuevo.!!!");
                }

            } while (!continuar);
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