using EspacioFabicaDePersonajes;
using EspacioPersonajes;
using EspacioDatos;
using EspacioCaracteristicas;
using EspacioFunciones;
using EspacioBanners;
// See https://aka.ms/new-console-template for more information

TipoPersonaje tipoPlayer1;
string nombrePlayer1;

//Banner Inicial con validacinon de tecla Enter.
BannerPrinter.ShowBannerInicial();

//llamado de funcion para elegir el tipo de personaje y asignarlo a una variable.
tipoPlayer1 = Funciones.SeleccionarTipoPersonaje();

//llamado de funcion para elegir el personaje y asignarlo a una variable.
nombrePlayer1 =await Funciones.ElegirNombrePersonaje(tipoPlayer1);


FabricaPersonajes fabrica = new FabricaPersonajes();

//carga los datos de Player1
Personaje player1 = fabrica.CrearPlayer1(tipoPlayer1, nombrePlayer1);
Funciones.MostrarDatosPersonaje(player1);


//genera los oponentes
TipoPersonaje tipoOponentes;
tipoOponentes = Funciones.AsignarOponentes(tipoPlayer1);
Console.WriteLine($"tipo de oponentes: {tipoOponentes}");

await fabrica.GenerarOponentes(tipoOponentes);

List<Personaje> oponentes = fabrica.ListasDePersonajes;

foreach (var oponente in oponentes)
{
    
    Console.WriteLine("oponentes:");
    Funciones.MostrarDatosPersonaje(oponente);
}

//


// fabrica.GenerarOponentes(tipoOponentes);

// List<Personaje> oponentes = fabrica.ListasDePersonajes;

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

// Console.WriteLine("----Tus Oponentes----");
// foreach (var oponente in oponentes)
// {
//     Console.WriteLine($"Tipo: {oponente.Datos.Tipo}, Nombre: {oponente.Datos.Nombre}, Apodo: {oponente.Datos.Apodo}, Fecha Nac: {oponente.Datos.FechaNac.ToShortDateString()}, Edad: {oponente.Datos.Edad}");
//     Console.WriteLine($"velocidad: {oponente.Caracteristicas.Velocidad}");
//     Console.WriteLine($"Destreza: {oponente.Caracteristicas.Destreza}");
//     Console.WriteLine($"Armadura: {oponente.Caracteristicas.Armadura}");
//     Console.WriteLine($"Fuerza: {oponente.Caracteristicas.Fuerza}");
//     Console.WriteLine($"Nivel: {oponente.Caracteristicas.Nivel}");
//     Console.WriteLine($"Salud: {oponente.Caracteristicas.Salud}\n");
// }
