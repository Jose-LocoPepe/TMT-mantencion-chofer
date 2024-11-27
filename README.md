<!-- PROYECTO -->
<br />
<div align="center">
  <h3 align="center">Transportes Mardones Torres.</h3>
  <h3 align="center">Sistema de mantenimiento de choferes</h3>
</div>

## Tabla de Contenidos
- [Introducción](#introducción)
- [Tecnologías Utilizadas](#tecnologías-utilizadas)
- [Pasos de Ejecución](#pasos-de-ejecución)
- [Migraciones](#migraciones)
- [Iniciar la Aplicación](#iniciar-la-aplicación)
- [Versionado 📌](#versionado)
- [Autores ✒️](#autores)
- [Licencia 📄](#licencia)


# Full-Stack - Aplicacion de consola para gestión de personal "Transporte Mardones Torres"

## Introducción

Esta aplicación es un proyecto para el ramo de "Proyecto Desarrollo e Integración de Soluciones" del 2°Semestre 2024. 
Está diseñado para darle mantencion a los busesy choferes de la base de datos. 

## Tecnologías Utilizadas 
- [.NET](https://dotnet.microsoft.com/en-us/)
- [MySQL](https://www.mysql.com)
- [MySQL Workbench](https://dev.mysql.com/downloads/installer/)

Asegúrate de tener instalada la herramienta de Entity Framework Core CLI:
```bash
dotnet tool install --global dotnet-ef
```

### Pasos de Ejecución

Abrir el proyecto en el Visual Studio Code o su editor favorito. Abre una nueva terminal.
Debemos copiar el archivo .env para poder establecer la conexión con nuestra base de datos.
```bash
copy .env.example .env
```

### Configuración de la Base de Datos

Cambia los siguientes parámetros en el archivo `.env` con las variables de entorno de la base de datos:

- **server**: Es la dirección del servidor MySQL. Puede utilizar `localhost` si tiene el servidor MySQL en la misma máquina que la aplicación web.
- **port**: Es el puerto donde se realiza la conexión a la base de datos.
- **database**: Aquí va el nombre de la base de datos creada en nuestro administrador de base de datos preferido (Ej: MySQL Workbench).
- **user**: El nombre de usuario que utiliza para acceder a la base de datos.
- **password**: Es la contraseña del usuario.


Ejecuta el siguiente comando en un terminal para poder instalar las dependencias en el proyecto.
```bash
dotnet restore
```

## Tipo de archivo y uso

Si está interesado en agregar buses desde un archivo, debe hacerlo del siguiente formato:

```bash
NOMBRE | APELLIDO | DISPONIBILIDAD | KILOMETRAJE
Carlos,Sanchez,true,325551
María,Gonzalez,false,20000
Luis,Perez,true,10055
Ana,Lopez,true,26364
```

El formato debe ser guardado en .txt en la carpeta raíz del programa compilado.

### Iniciar la Aplicación

Ahora levantamos la aplicación en un terminal con el comando:
```bash
dotnet run
```




## Versionado 

Usamos [GitHub](https://github.com/Jose-LocoPepe/TMT-mantencion) para el versionado.

## Autores ✒️

###### José Bautista

###### Nicolás Mardones


## Licencia 

Este proyecto está bajo la Licencia de &copy; Nicolás Mardones, José Bautista