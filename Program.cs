using EspacioFabicaDePersonajes;
using EspacioPersonajes;
using EspacioDatos;
using EspacioCaracteristicas;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine("tipo de oponentes:");
Console.WriteLine("1)plantas:");
Console.WriteLine("2)zombies");
int opcion = int.Parse(Console.ReadLine());

FabricaPersonajes fabrica = new FabricaPersonajes();
List<Personaje> oponentes = new List<Personaje>();
switch (opcion)
{
    case 1:
        fabrica.GenerarOponentes(EspacioDatos.TipoPersonaje.Planta);
        oponentes = fabrica.ListasDePersonajes;
    break;
    case 2:
        fabrica.GenerarOponentes(EspacioDatos.TipoPersonaje.Zombie);
        oponentes = fabrica.ListasDePersonajes;
    break;
    default:
    break;
}

Console.WriteLine("----oponentes----");
foreach (var oponente in oponentes)
{
    Console.WriteLine($"Tipo: {oponente.Datos.Tipo}, Nombre: {oponente.Datos.Nombre}, Apodo: {oponente.Datos.Apodo}, Fecha Nac: {oponente.Datos.FechaNac.ToShortDateString()}, Edad: {oponente.Datos.Edad}");
    Console.WriteLine($"velocidad: {oponente.Caracteristicas.Velocidad}");
    Console.WriteLine($"Destreza: {oponente.Caracteristicas.Destreza}");
    Console.WriteLine($"Armadura: {oponente.Caracteristicas.Armadura}");
    Console.WriteLine($"Fuerza: {oponente.Caracteristicas.Fuerza}");
    Console.WriteLine($"Nivel: {oponente.Caracteristicas.Nivel}");
    Console.WriteLine($"Salud: {oponente.Caracteristicas.Salud}");
}
