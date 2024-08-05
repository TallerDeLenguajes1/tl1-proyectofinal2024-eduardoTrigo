using EspacioDatos;
using EspacioCaracteristicas;
using EspacioPersonajes;
using EspacioTasks;
namespace EspacioFabicaDePersonajes
{

    public class FabricaPersonajes
    {   //declaracion de la lista de personajes que se cargara con los oponentes.
        List<Personaje> listasDePersonajes = new List<Personaje>();
        
        public Random random = new Random();

        public List<Personaje> ListasDePersonajes { get => listasDePersonajes; }

        //genera 8 oponentes de diferente tipo al elejido por el usuario
        // public void GenerarOponentes(TipoPersonaje tipo)
        // {
        //     for (int i = 0; i < 8; i++)
        //     {
        //         CrearAdversario(tipo);
        //     }
        // }

        //metodo que genera el nombre aleatorio del zombie
        // public string GenerarNombreZombie()
        // {
        //     string[] nombres = Enum.GetNames(typeof(NombresZombies));
        //     return nombres[random.Next(nombres.Length)];
        // }

        // //metodo que genera el nombre aleatorio de la planta
        // public string GenerarNombre()
        // {
        //     string[] nombres = Enum.GetNames(typeof(NombresPlantas));
        //     return nombres[random.Next(nombres.Length)];
        // }

        public Personaje CrearPlayer1(TipoPersonaje tipo, string nombre){
            string apodo = "";
            DateTime fechaNac = CalcularFechaNac(tipo);
            Datos datosPlayer1 = new Datos(tipo,nombre,apodo,fechaNac);
            Caracteristicas caracteristicasPlayer1 = GenerarCaracteristicas(tipo);
            return new Personaje(datosPlayer1, caracteristicasPlayer1);
        }

        public async Task GenerarOponentes(TipoPersonaje tipo){
            string tipoOponente;
            if (tipo == TipoPersonaje.Plantas)
            {
                tipoOponente = "plants";
            }
            else
            {
                tipoOponente = "zombies";
            }
            List<string> nombresOponentes = await Tasks.GetNombrePersonajes(tipoOponente);
            for (int i = 0; i < 6; i++)
            {
                string nombre = nombresOponentes[random.Next(nombresOponentes.Count)];
                Personaje oponente = CrearPlayer1(tipo,nombre);
                ListasDePersonajes.Add(oponente);
            }
        }

        // metodo que crea cada adversario
        // public void CrearAdversario(TipoPersonaje tipoOponentes)
        // {
        //     TipoPersonaje tipo = tipoOponentes;
        //     string nombre;
        //     if (tipo == TipoPersonaje.Plantas)
        //     {
        //         nombre = GenerarNombreplanta();
        //     }
        //     else
        //     {
        //         nombre = GenerarNombreZombie();
        //     }
        //     string apodo = "";
        //     DateTime fechaNac = CalcularFechaNac(tipo);
        //     Datos datosOponentes = new Datos(tipo, nombre, apodo, fechaNac);
        //     Caracteristicas caracteristicasOponentes = GenerarCaracteristicas(tipo);
        //     Personaje oponente = new Personaje(datosOponentes,caracteristicasOponentes);
        //     ListasDePersonajes.Add(oponente);
        // }

        // metodo que genera la fecha de nacimiento a partir del tipo de personaje
        private DateTime CalcularFechaNac(TipoPersonaje tipo)
        {
            int min, max;
            DateTime fechaNac;
            if (tipo == TipoPersonaje.Plantas)
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

        //genera las caracteristicas aleatorias (funciona pero en progreso)
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