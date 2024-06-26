using EspacioDatos;

namespace EspacioFunciones
{
    class Funciones
    {
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
            return (TipoPersonaje)Enum.Parse(typeof(TipoPersonaje),tipo[opcion - 1]);
        }

        public static string SeleccionarNombre(TipoPersonaje tipo)
        {
            string[] nombres;
            if (tipo == TipoPersonaje.Planta)
            {
                nombres = Enum.GetNames(typeof(NombresPlantas));
            }
            else
            {
                nombres = Enum.GetNames(typeof(NombresPlantas));
            }

            Console.WriteLine("Elije un personaje");
            for (int i = 0; i < nombres.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {nombres[i]}");
            }
            int opcion ;
            bool esValido = int.TryParse(Console.ReadLine(), out opcion) && opcion > 0 && opcion <= nombres.Length;
            while (!esValido)
            {
                Console.WriteLine("Opcion no valida, elige nuevamente el personaje");
                esValido = int.TryParse(Console.ReadLine(),out opcion) && opcion > 0 && opcion < nombres.Length;
            }
            return nombres[opcion - 1];
        }

    }
}