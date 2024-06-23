using EspacioDatos;
using EspacioCaracteristicas;
using EspacioPersonajes;
namespace EspacioFabicaDePersonajes
{

    public class FabricaPersonajes
    {
        List<Personaje> listasDePersonajes = new List<Personaje>();
        
        public Random random = new Random();

        public List<Personaje> ListasDePersonajes { get => listasDePersonajes; }

        public void GenerarOponentes(TipoPersonaje tipo){
            for (int i = 0; i < 8; i++)
            {
                CrearAdversario(tipo);
            }
        }

        public string GenerarNombreZombie()
        {
            string[] nombres = Enum.GetNames(typeof(NombresZombies));
            return nombres[random.Next(nombres.Length)];
        }

        public string GenerarNombreplanta()
        {
            string[] nombres = Enum.GetNames(typeof(NombresPlantas));
            return nombres[random.Next(nombres.Length)];
        }

        public void CrearAdversario(TipoPersonaje tipoOponentes)
        {
            TipoPersonaje tipo = tipoOponentes;
            string nombre;
            if (tipo == TipoPersonaje.Planta)
            {
                nombre = GenerarNombreplanta();
            }
            else
            {
                nombre = GenerarNombreZombie();
            }
            string apodo = "";
            DateTime fechaNac = CalcularFechaNac(tipo);
            Datos datosOponentes = new Datos(tipo, nombre, apodo, fechaNac);
            Caracteristicas caracteristicasOponentes = GenerarCaracteristicas(tipo);
            Personaje oponente = new Personaje(datosOponentes,caracteristicasOponentes);
            ListasDePersonajes.Add(oponente);
        }

        private DateTime CalcularFechaNac(TipoPersonaje tipo)
        {
            int min, max;
            DateTime fechaNac;
            if (tipo == TipoPersonaje.Planta)
            {
                min = DateTime.Now.Year - 10;
                max = DateTime.Now.Year - 35;
            }
            else
            {
                min = DateTime.Now.Year - 90;
                max = DateTime.Now.Year - 140;
            }
            fechaNac = new DateTime(random.Next(max, min), random.Next(1, 13), random.Next(1, 30));
            return fechaNac;
        }

        private Caracteristicas GenerarCaracteristicas(TipoPersonaje tipo)
        {
            int velocidad = random.Next(1, 10);
            int destreza = random.Next(1, 10);
            int fuerza = random.Next(1, 10);
            int nivel = random.Next(1, 10);
            int armadura = random.Next(1, 10);
            int salud = random.Next(1, 10);
            return new Caracteristicas(velocidad, destreza, fuerza, nivel, armadura, salud);
        }

    }
}