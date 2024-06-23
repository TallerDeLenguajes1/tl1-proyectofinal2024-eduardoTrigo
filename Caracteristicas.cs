using EspacioPersonajes;
namespace EspacioCaracteristicas
{

    public class Caracteristicas
    {
        private int velocidad;
        private int destreza;
        private int fuerza;
        private int nivel;
        private int armadura;
        private int salud;

        public Caracteristicas(int velocidad, int destreza, int fuerza, int nivel, int armadura, int salud)
        {
            this.velocidad = velocidad;
            this.destreza = fuerza;
            this.nivel = nivel;
            this.armadura = armadura;
            this.salud = salud;
        }

        public void RestarSalud(int danio)
        {
            salud -= danio;
            if (salud < 0)
            {
                salud = 0;
            }
        }

        public int Velocidad { get => velocidad; }
        public int Destreza { get => destreza; }
        public int Fuerza { get => fuerza; }
        public int Nivel { get => nivel; }
        public int Armadura { get => armadura; }
        public int Salud { get => salud; set => salud = value; }
    }
}