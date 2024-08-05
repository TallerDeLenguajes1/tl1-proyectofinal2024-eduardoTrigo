using EspacioCaracteristicas;
using EspacioDatos;

namespace EspacioPersonajes
{
    public class Personaje
    {
        Datos datos;
        Caracteristicas caracteristicas;

        public Personaje(Datos datos, Caracteristicas caracteristicas)
        {
            this.datos = datos;
            this.caracteristicas = caracteristicas;
        }

        public Datos Datos { get => datos; }
        public Caracteristicas Caracteristicas { get => caracteristicas; }
    }
}