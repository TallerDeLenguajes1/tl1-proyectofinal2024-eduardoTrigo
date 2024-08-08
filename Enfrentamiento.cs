using System.Security.Cryptography.X509Certificates;
using EspacioPersonajes;

namespace EspacioEnfrentamiento
{
    public static class Enfrentamiento
    {
        public static void Lucha(Personaje player1, Personaje oponente)
        {
            Random random = new Random();
            while (player1.Caracteristicas.Salud > 0 && oponente.Caracteristicas.Salud > 0)
            {
                //turno ataque player1
                Ataque(player1,oponente);

                // verifica si el oponente ha sido derrotado
                if (oponente.Caracteristicas.Salud <= 0)
                {
                    Console.WriteLine($"{oponente.Datos.Nombre} ha sido Derrotado");
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
            //recorre la lista de oponentes
            foreach (var oponente in oponentes)
            {
                Console.WriteLine($"\n{player.Datos.Nombre} se enfrenta a {oponente.Datos.Nombre}");
                Lucha(player, oponente);
                if (player.Caracteristicas.Salud <= 0)
                {
                    Console.WriteLine($"{player.Datos.Nombre} ha sido derrotado. GAME OVER");
                    break;
                }
            }
            if (player.Caracteristicas.Salud > 0)
            {
                Console.WriteLine($"{player.Datos.Nombre} ha derrotado todos los oponentes . WINNER!");
            }
        }

        //metodo del ataque y el daño que provoca utilizado en la lucha
        public static void Ataque(Personaje atacante, Personaje defensor)
        {
            Random random = new Random();
            int ataque = atacante.Caracteristicas.Destreza * atacante.Caracteristicas.Nivel;
            int efectividadPlayer1 = random.Next(1, 101);
            int defensaOponente = defensor.Caracteristicas.Armadura * defensor.Caracteristicas.Velocidad;
            int danioProvocado = ((ataque * efectividadPlayer1) - defensaOponente) / 500;
            danioProvocado = Math.Max(0, danioProvocado);
            defensor.Caracteristicas.Salud -= danioProvocado;

            Console.WriteLine($"{atacante.Datos.Nombre} ataca a {defensor.Datos.Nombre} y provoca {danioProvocado} de daño");
            Console.WriteLine($"Salud de {defensor.Datos.Nombre} despues del ataque: {defensor.Caracteristicas.Salud}");
        }
    }
}