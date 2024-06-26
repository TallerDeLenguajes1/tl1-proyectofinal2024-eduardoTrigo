using EspacioFabicaDePersonajes;
using EspacioPersonajes;
using EspacioDatos;
using EspacioCaracteristicas;
using EspacioFunciones;
// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
Console.WriteLine("Plantas vs Zombies");

TipoPersonaje tipoPlayer1;
string nombrePlayer1;

tipoPlayer1 = Funciones.SeleccionarTipoPersonaje();
nombrePlayer1 = Funciones.SeleccionarNombre(tipoPlayer1);

FabricaPersonajes fabrica = new FabricaPersonajes();
Personaje player1 = fabrica.CrearPlayer1(tipoPlayer1, nombrePlayer1);
Console.WriteLine($"Tipo: {player1.Datos.Tipo}, Nombre: {player1.Datos.Nombre}, Apodo: {player1.Datos.Apodo}, Fecha Nac: {player1.Datos.FechaNac.ToShortDateString()}, Edad: {player1.Datos.Edad}\n");


Console.WriteLine("tipo de oponentes:");
TipoPersonaje tipoOponentes;
if (tipoPlayer1 == TipoPersonaje.Planta)
{
    tipoOponentes = TipoPersonaje.Zombie;
}else
{
    tipoOponentes = TipoPersonaje.Planta;
}

fabrica.GenerarOponentes(tipoOponentes);

List<Personaje> oponentes = fabrica.ListasDePersonajes;

// switch (tipoPlayer1)
// {
//     case TipoPersonaje.Zombie:
//         fabrica.GenerarOponentes(EspacioDatos.TipoPersonaje.Planta);
//         oponentes = fabrica.ListasDePersonajes;
//         break;
//     case TipoPersonaje.Planta:
//         fabrica.GenerarOponentes(EspacioDatos.TipoPersonaje.Zombie);
//         oponentes = fabrica.ListasDePersonajes;
//         break;
//     default:
//         break;
// }

Console.WriteLine("----Tus Oponentes----");
foreach (var oponente in oponentes)
{
    Console.WriteLine($"Tipo: {oponente.Datos.Tipo}, Nombre: {oponente.Datos.Nombre}, Apodo: {oponente.Datos.Apodo}, Fecha Nac: {oponente.Datos.FechaNac.ToShortDateString()}, Edad: {oponente.Datos.Edad}");
    Console.WriteLine($"velocidad: {oponente.Caracteristicas.Velocidad}");
    Console.WriteLine($"Destreza: {oponente.Caracteristicas.Destreza}");
    Console.WriteLine($"Armadura: {oponente.Caracteristicas.Armadura}");
    Console.WriteLine($"Fuerza: {oponente.Caracteristicas.Fuerza}");
    Console.WriteLine($"Nivel: {oponente.Caracteristicas.Nivel}");
    Console.WriteLine($"Salud: {oponente.Caracteristicas.Salud}\n");
}
