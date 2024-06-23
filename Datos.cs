using EspacioPersonajes;
namespace EspacioDatos
{

    public enum TipoPersonaje
    {
        Planta,
        Zombie,
    }
    public enum NombresPlantas
    {
        Cactus,
        Girasol,
        Peashover,
        Carnivora,
        Nut,
    }

    public enum NombresZombies
    {
        Zombie,
        ZombieCono,
        ZombieBalde,
        ZombieSaltador,
        ZombieGigante
    }

    public class Datos
    {
        private TipoPersonaje tipo;
        private string? nombre;
        private string? apodo;
        private DateTime fechaNac;
        private int edad;

        public Datos(TipoPersonaje tipo, string nombre, string apodo, DateTime fechaNac)
        {
            this.tipo = tipo;
            this.nombre = nombre;
            this.apodo = apodo;
            this.fechaNac = fechaNac;
            edad = DateTime.Now.Year - fechaNac.Year;
            if (DateTime.Now.Month < fechaNac.Month || (DateTime.Now.Month == fechaNac.Month && DateTime.Now.Day < fechaNac.Day))
            {
                edad--;
            }
        }

        public TipoPersonaje Tipo { get => tipo; }
        public string? Nombre { get => nombre; }
        public string? Apodo { get => apodo; }
        public DateTime FechaNac { get => fechaNac; }
        public int Edad { get => edad; }
    }
}
