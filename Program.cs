using EspacioFabicaDePersonajes;
using EspacioPersonajes;
using EspacioDatos;
using EspacioCaracteristicas;
using EspacioFunciones;
using EspacioBanners;
using EspacioJson;
// See https://aka.ms/new-console-template for more information

TipoPersonaje tipoPlayer1;
string nombrePlayer1;

//Banner Inicial con validacinon de tecla Enter.
BannerPrinter.ShowBannerInicial();

//llamado de funcion para elegir el tipo de personaje y asignarlo a una variable.
tipoPlayer1 = Funciones.SeleccionarTipoPersonaje();

//llamado de funcion para elegir el personaje y asignarlo a una variable.
nombrePlayer1 = await Funciones.ElegirNombrePersonaje(tipoPlayer1);


FabricaPersonajes fabrica = new FabricaPersonajes();

//carga los datos de Player1
Personaje player1 = fabrica.CrearPlayer1(tipoPlayer1, nombrePlayer1);
Funciones.MostrarDatosPersonaje(player1);


//genera los oponentes
TipoPersonaje tipoOponentes;
tipoOponentes = Funciones.AsignarOponentes(tipoPlayer1);
Console.WriteLine($"\nTe enfrentas a 6 {tipoOponentes}");

await fabrica.GenerarOponentes(tipoOponentes);

List<Personaje> oponentes = fabrica.ListasDePersonajes;


//Recorre la lista y muestra cada oponente
// foreach (var oponente in oponentes)
// {

//     Console.WriteLine("oponentes:");
//     Funciones.MostrarDatosPersonaje(oponente);
// }

//guarda los personajes en un json
string archivoPersonajes = "personajes.json";
List<Personaje> jsonPersonajes = new List<Personaje> { player1 };     //primero guardo el player1
jsonPersonajes.AddRange(oponentes);                                 //despues guardo los oponentes

PersonajeJson.GuardarPersonajes(jsonPersonajes, archivoPersonajes);


//Lista los nombres para elegir uno o presionar enter para continuar
Funciones.ListarInicioOponentes(oponentes);


//Lee y mustra los archivos del personaje.json
if (PersonajeJson.Existe(archivoPersonajes))
{
    List<Personaje> personajesDelJson = PersonajeJson.LeerPersonajes(archivoPersonajes);
    Console.WriteLine("Personajes contenidos en el archivo JSON:");
    foreach (var personaje in personajesDelJson)
    {
        Funciones.MostrarDatosPersonaje(personaje);
    }
}

BannerPrinter.ShowBannerGameOver();
