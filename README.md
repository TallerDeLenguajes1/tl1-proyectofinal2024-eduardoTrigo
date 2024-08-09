# Plantas vs Zombies: Juego de Lucha por Turnos

## Descripción

"Plantas vs Zombies" es un juego de lucha por turnos en C# en el que los jugadores eligen un personaje y luchan contra oponentes generados aleatoriamente. El juego sigue un sistema de combate por turnos y guarda el historial de enfrentamientos y los ganadores en archivos JSON.

## Requisitos

- .NET Core o .NET Framework
- Visual Studio o cualquier IDE compatible con C#

## Estructura del Código

El código se organiza en varias clases y espacios de nombres para mantener una estructura modular y clara. A continuación se describen las principales partes del código:

### `Program.cs`

- **Funcionalidad Principal**: Controla el flujo del programa, incluyendo la selección de personajes, la generación de oponentes, y la gestión del historial y ganadores.
- **Flujo de Ejecución**:
  1. Muestra un banner inicial.
  2. Permite al usuario seleccionar el tipo de personaje.
  3. Permite al usuario elegir el nombre del personaje.
  4. Crea y muestra los datos del personaje principal.
  5. Genera oponentes aleatorios y los guarda en un archivo JSON.
  6. Inicia el combate y gestiona el historial de enfrentamientos y la lista de ganadores.
  7. Muestra un menú final con opciones para revisar los archivos JSON.

### `EspacioFabicaDePersonajes`

- **FabricaPersonajes**: Crea instancias de personajes según el tipo seleccionado.

### `EspacioPersonajes`

- **Personaje**: Define las características y datos de los personajes en el juego.

### `EspacioDatos`

- **Caracteristicas**: Define las características del personaje como salud, armadura, etc.

### `EspacioFunciones`

- **Funciones**: Contiene métodos auxiliares para la selección y visualización de personajes.

### `EspacioBanners`

- **Banners**: Muestra mensajes y banners en la consola para mejorar la experiencia del usuario.

### `EspacioJson`

- **PersonajeJson**: Maneja la lectura y escritura de datos en archivos JSON, incluyendo personajes, historial de enfrentamientos y ganadores.

## Archivos JSON

- **`personajes.json`**: Guarda los datos de todos los personajes (jugador y oponentes).
- **`historial.json`**: Guarda el historial de enfrentamientos, incluyendo detalles de cada combate.
- **`historialGanadores.json`**: Guarda una lista de los nombres de los ganadores.

### `EspacioEnfrentamiento`

- **Enfrentamiento**: Gestiona la lógica de combate entre personajes, incluyendo el ataque, las mejoras y la actualización del historial de enfrentamientos.

### `EspacioTasks`

- **Tasks**: Contiene el método `GetNombrePersonajes` que consume una API para obtener los nombres de los personajes basados en el tipo (Plantas o Zombies).

## API de Personajes

El juego consume una API para obtener los nombres de los personajes según el tipo seleccionado por el usuario. La API utilizada es:

- **URL de la API**: `https://pvz-2-api.vercel.app/api/{tipo}`
- **Tipo de Personaje**: Puede ser `plantas` o `zombies`.

El método `GetNombrePersonajes` en la clase `Tasks` realiza una solicitud HTTP GET a la API y deserializa la respuesta en una lista de nombres de personajes.

## Uso

1. **Ejecutar el Juego**: Al ejecutar el programa, se mostrará un banner inicial y se te pedirá que selecciones el tipo de personaje y el nombre del jugador.
2. **Combate**: El jugador luchará contra oponentes generados aleatoriamente. El historial de cada enfrentamiento se guardará automáticamente.
3. **Final del Juego**: Después de los combates, el menú final te permitirá revisar los archivos JSON con el historial de enfrentamientos y los ganadores.

## Métodos y Funciones Clave

- **`Banners.ShowBannerInicial()`**: Muestra el banner inicial del juego.
- **`Funciones.SeleccionarTipoPersonaje()`**: Permite al usuario seleccionar el tipo de personaje.
- **`Funciones.ElegirNombrePersonaje()`**: Permite al usuario elegir el nombre del personaje.
- **`FabricaPersonajes.CrearPlayer1()`**: Crea el personaje principal.
- **`Funciones.MostrarDatosPersonaje()`**: Muestra los datos del personaje en la consola.
- **`PersonajeJson.VerificaYguardaLosPersonajes()`**: Verifica y guarda los datos de los personajes en un archivo JSON.
- **`Enfrentamiento.LuchasContraTodos()`**: Inicia el combate contra todos los oponentes.
- **`PersonajeJson.MenuFinal()`**: Muestra el menú final y permite revisar los archivos JSON.

## Contribuciones

Las contribuciones al proyecto son bienvenidas. Por favor, abre un *issue* o envía una *pull request* con tus sugerencias y mejoras.

## Licencia

Este proyecto está licenciado bajo la Licencia MIT. Consulta el archivo `LICENSE` para obtener más detalles.


