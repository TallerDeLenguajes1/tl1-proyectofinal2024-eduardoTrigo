using EspacioFabicaDePersonajes;
using EspacioPersonajes;
using EspacioDatos;
using EspacioCaracteristicas;
using EspacioFunciones;
using EspacioBanners;
using EspacioJson;
using EspacioEnfrentamiento;
// See https://aka.ms/new-console-template for more information

TipoPersonaje tipoPlayer1;
string nombrePlayer1;

//Banner Inicial con validacinon de tecla Enter.
Banners.ShowBannerInicial();

//llamado de funcion para elegir el tipo de personaje y asignarlo a una variable.
tipoPlayer1 = Funciones.SeleccionarTipoPersonaje();

//llamado de funcion para elegir el personaje y asignarlo a una variable.
nombrePlayer1 = await Funciones.ElegirNombrePersonaje(tipoPlayer1);


FabricaPersonajes fabrica = new FabricaPersonajes();

//carga los datos de Player1
Personaje atacante = fabrica.CrearPlayer1(tipoPlayer1, nombrePlayer1);
Funciones.MostrarDatosPersonaje(atacante);


//genera los oponentes
TipoPersonaje tipoOponentes;
tipoOponentes = Funciones.AsignarOponentes(tipoPlayer1);
Console.WriteLine($"\nTe enfrentas a 6 {tipoOponentes}");

await fabrica.GenerarOponentes(tipoOponentes);

List<Personaje> oponentes = fabrica.ListasDePersonajes;


//guarda los personajes en un json
string archivoPersonajes = "personajes.json";
List<Personaje> jsonPersonajes = new List<Personaje> { atacante };     //primero guardo el player1
jsonPersonajes.AddRange(oponentes);                                 //despues guardo los oponentes


//verifica si el archivo .json existe y guardo(actualiza) los datos 
PersonajeJson.VerificaYguardaLosPersonajes(archivoPersonajes, jsonPersonajes);


//Lista los nombres para elegir uno o presionar enter para continuar
Funciones.ListarInicioOponentes(oponentes);


//primero verifica si el archivoPersonajes existe.
//luego Lee y mustra los archivos del personaje.json
PersonajeJson.MostrarPersonajesDesdeElJson(archivoPersonajes);


string archivoHistorial = "historial.json";
string archivoGanadores = "historialGanadores.json";
//Inicio de lucha contra todos
Enfrentamiento.LuchasContraTodos(atacante, oponentes, archivoHistorial, archivoGanadores);


//Banner Game Over
// Banners.ShowBannerGameOver();
