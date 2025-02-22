# API PSP

Este proyecto es una API para gestionar jugadores utilizando ASP.NET Core y Entity Framework Core con una base de datos en memoria.

## Estructura del Proyecto

- Controllers/: Contiene los controladores, por ejemplo, JugadoresController.cs.

- Models/: Contiene las clases de modelo (Jugador.cs) y el contexto (JugadorContext.cs).

- Program.cs: Configura los servicios, el middleware y el pipeline de la aplicación.

## Notas
- Se utiliza una base de datos en memoria; los datos se reinician cada vez que se detiene la aplicación.

