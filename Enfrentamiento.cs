using System.Security.Cryptography.X509Certificates;
using EspacioBanners;
using EspacioPersonajes;

namespace EspacioEnfrentamiento
{
    public static class Enfrentamiento
    {
        public static void Lucha(Personaje player1, Personaje oponente, int enfrentamiento)
        {
            Random random = new Random();
            Console.WriteLine($"\nENFRENTAMIENTO {enfrentamiento} : {player1.Datos.Nombre} VS {oponente.Datos.Nombre}");

            while (player1.Caracteristicas.Salud > 0 && oponente.Caracteristicas.Salud > 0)
            {
                //turno ataque player1
                Ataque(player1, oponente);

                // verifica si el oponente ha sido derrotado
                if (oponente.Caracteristicas.Salud <= 0)
                {
                    Console.WriteLine($"{oponente.Datos.Nombre} ha sido Derrotado");
                    player1.Caracteristicas.Salud = 100;
                    AplicarMejora(player1);
                    break;
                }

                //Turno del oponente
                Ataque(oponente, player1);

                //Verificar si el jugador ha sido derrotado
                if (player1.Caracteristicas.Salud <= 0)
                {
                    Console.WriteLine($"{player1.Datos.Nombre} ha sido derrotado por {oponente.Datos.Nombre}!");
                    break;
                }
            }
        }

        public static void LuchasContraTodos(Personaje player, List<Personaje> oponentes)
        {
            int numeroEnfrentamiento = 1;  // contador de enfrentamiento
            //recorre la lista de oponentes
            foreach (var oponente in oponentes)
            {
                // Console.WriteLine($"\n{player.Datos.Nombre} se enfrenta a {oponente.Datos.Nombre}");

                Lucha(player, oponente, numeroEnfrentamiento);
                numeroEnfrentamiento++;
                if (player.Caracteristicas.Salud <= 0)
                {
                    Banners.ShowBannerGameOver();
                    break;
                }

                //pide al usuario que precione Enter para continuar
                Console.WriteLine("\nPresione ENTER para el siguente enfrentamiento");
                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    Console.WriteLine("\nPresione ENTER para el siguente enfrentamiento");
                }
            }
            if (player.Caracteristicas.Salud > 0)
            {
                Console.WriteLine($"{player.Datos.Nombre} ha derrotado todos los oponentes .");
                Banners.Winner();
            }
        }

        //metodo del ataque y el daño que provoca utilizado en la lucha
        public static void Ataque(Personaje atacante, Personaje defensor)
        {
            Random random = new Random();
            int ataque = atacante.Caracteristicas.Destreza * atacante.Caracteristicas.Nivel;
            int efectividadPlayer1 = random.Next(21, 121); //cambio en valores de (1,101) a (51,151) para mejorar los resultados de la formula
            int defensaOponente = defensor.Caracteristicas.Armadura * defensor.Caracteristicas.Velocidad;
            int danioProvocado = ((ataque * efectividadPlayer1) - defensaOponente) / 25; //cambio en valores de 500 a 300 para mejorar los resultados de la formula
            danioProvocado = Math.Max(0, danioProvocado); // Asegurarse de que el daño nunca sea 0
            defensor.Caracteristicas.Salud -= danioProvocado;

            Console.WriteLine($"{atacante.Datos.Nombre} ataca a {defensor.Datos.Nombre} y provoca {danioProvocado} de daño");
            Console.WriteLine($"Salud de {defensor.Datos.Nombre} despues del ataque: {defensor.Caracteristicas.Salud}");
        }

        public static void AplicarMejora(Personaje player)
        {
            Random random = new Random();
            int mejora = random.Next(1, 4);

            switch (mejora)
            {
                case 1:
                    player.Caracteristicas.Salud += 10;
                    Console.WriteLine($"{player.Datos.Nombre} gana +10 de Salud");
                    break;
                case 2:
                    player.Caracteristicas.Armadura += 5;
                    Console.WriteLine($"{player.Datos.Nombre} gana +10 de Salud");
                    break;
                case 3:
                    player.Caracteristicas.Armadura += 5;
                    Console.WriteLine($"{player.Datos.Nombre} gana +10 de Salud");
                    break;
            }
        }
    }
}