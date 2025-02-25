# Smart Parking Lot Management System (IoT)

## Descripción del Proyecto

Este proyecto es un sistema de gestión de estacionamiento inteligente que interactúa con sensores IoT ubicados en los espacios de estacionamiento. A través de una API RESTful, el sistema permite simular la ocupación y liberación de espacios de estacionamiento y llevar el registro del estado de los mismos.

## Tabla de Contenidos
- [Funcionalidades](#funcionalidades-principales)
- [API Endpoints Principales](#api-endpoints)
- [Estructura](#estructura-del-proyecto)
- [Inyección de Dependencias](#inyección-de-dependencias)
- [Tests](#tests)
- [Autenticación](#autenticación)
- [Diagramas](#diagramas)
- [Como ejecutar el proyecto](#instrucciones-para-correr-el-proyecto)

## Funcionalidades Principales

1. **Detectar cuando un coche entra o sale de un espacio de estacionamiento**:
   - Los dispositivos IoT simulan este comportamiento enviando solicitudes de API para marcar los espacios como ocupados o libres.

2. **Seguir el número de espacios de estacionamiento disponibles**:
   - El sistema mantiene un conteo dinámico de los espacios libres.

3. **Exponer una API RESTful que devuelva el estado de los espacios**:
   - Permite conocer si un espacio está ocupado o libre.

4. **Realizar operaciones CRUD básicas para los espacios de estacionamiento y los dispositivos IoT**:
   - Se pueden agregar, eliminar y modificar los espacios de estacionamiento y los dispositivos IoT.

### API Endpoints

- **POST /api/parking-spots/{id}/occupy**: Marca un espacio de estacionamiento como ocupado.
- **POST /api/parking-spots/{id}/free**: Marca un espacio de estacionamiento como libre.
- **GET /api/parking-spots**: Devuelve el estado de todos los espacios de estacionamiento.
- **POST /api/parking-spots**: Agrega un nuevo espacio de estacionamiento.
- **DELETE /api/parking-spots/{id}**: Elimina un espacio de estacionamiento.
  
### Reglas de Negocio

- Un espacio de estacionamiento puede estar libre o ocupado.
- El sistema mantiene un conteo dinámico de los espacios disponibles.
- Solo los dispositivos IoT registrados pueden ocupar o liberar un espacio de estacionamiento.

### Dispositivos IoT Simulados

- Los dispositivos IoT son identificados por un GUID único.
- Solo los dispositivos registrados pueden enviar solicitudes para ocupar o liberar un espacio de estacionamiento.

### Validaciones Básicas

- Los espacios de estacionamiento no pueden ser ocupados dos veces sin ser liberados previamente.
- Los espacios de estacionamiento no pueden ser liberados si ya están libres.

## Estructura del Proyecto

### Controllers
- **AuthController**: Maneja las operaciones de autenticación y autorización.
- **IoTDeviceController**: Administra las operaciones relacionadas con los dispositivos IoT.
- **ParkingController**: Gestiona las operaciones relacionadas con los espacios de estacionamiento.

### DTOs
- **CreateIoTDeviceDTO**: Representa la información necesaria para crear un dispositivo IoT.
- **CreateParkingSpotDTO**: Representa la información necesaria para crear un espacio de estacionamiento.
- **CreateUserDTO**: Representa la información necesaria para crear un usuario.
- **IoTDeviceDTO**: Representa los datos de un dispositivo IoT.
- **LoginUseDTO**: Contiene las credenciales de inicio de sesión de un usuario.
- **ParkingSpotDTO**: Representa los datos de un espacio de estacionamiento.
- **UserDTO**: Representa los datos de un usuario.

### Models
- **IoTDevice**: Representa un dispositivo IoT.
- **ParkingSpot**: Representa un espacio de estacionamiento.
- **ParkingState**: Enumera los posibles estados de un espacio de estacionamiento (ocupado, libre).
- **Role**: Define los roles de los usuarios (e.g., Administrador, Usuario).
- **User**: Representa un usuario en el sistema.

### Repositories
- **IoTDeviceRepository**: Repositorio para manejar operaciones sobre dispositivos IoT.
- **IIoTDeviceRepository**: Interfaz para las operaciones del repositorio de dispositivos IoT.
- **ParkingRepository**: Repositorio para manejar operaciones sobre espacios de estacionamiento.
- **IParkingRepository**: Interfaz para las operaciones del repositorio de espacios de estacionamiento.
- **UserRepository**: Repositorio para manejar operaciones sobre usuarios.
- **IUserRepository**: Interfaz para las operaciones del repositorio de usuarios.

### Services
- **AuthService**: Servicio para gestionar la autenticación y autorización de usuarios.
- **IAuthService**: Interfaz para el servicio de autenticación y autorización.
- **IoTDeviceService**: Servicio para gestionar dispositivos IoT.
- **IIoTDeviceService**: Interfaz para el servicio de dispositivos IoT.
- **ParkingService**: Servicio para gestionar espacios de estacionamiento.
- **IParkingService**: Interfaz para el servicio de espacios de estacionamiento.

## Inyección de Dependencias

El sistema hace uso de **inyección de dependencias** para la gestión de servicios y repositorios. Esta práctica asegura que las clases estén desacopladas y facilita la escalabilidad y la extensibilidad del sistema. Al usar interfaces e inyección de dependencias, podemos fácilmente modificar la implementación de un servicio o repositorio sin afectar otras partes del sistema.

### Escalabilidad del Proyecto

El proyecto está diseñado para ser escalable. Al seguir el principio de separación de responsabilidades, cada componente (Controller, Service, Repository, etc.) tiene una única responsabilidad. Esto facilita la adición de nuevas funcionalidades o la modificación de las existentes sin causar efectos secundarios en otras partes del sistema.

La inyección de dependencias y la estructuración en capas permite que el sistema crezca de manera ordenada, facilitando la integración de nuevos servicios (por ejemplo, nuevos tipos de sensores IoT) o la migración de la base de datos (como pasar de almacenamiento en memoria a una base de datos real como SQLite o PostgreSQL).

## Tests

El proyecto incluye pruebas unitarias que aseguran el correcto funcionamiento de las operaciones clave del sistema. Las pruebas están centradas principalmente en el **AuthController**, asegurando que los procesos de autenticación y autorización se manejen correctamente.

### Dependencias Utilizadas

El proyecto utiliza las siguientes dependencias:

```xml
<ItemGroup>
    <PackageReference Include="BCrypt.Net-Next" Version="4.0.3" />
    <PackageReference Include="DotNetEnv" Version="3.1.1" />
    <PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="8.0.0-*" />
    <PackageReference Include="Microsoft.AspNetCore.Mvc.Testing" Version="8.0.0-*" />
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="8.0.13" />
    <PackageReference Include="Microsoft.IdentityModel.Tokens" Version="8.6.0" />
    <PackageReference Include="Moq" Version="4.20.72" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="7.2.0" />
    <PackageReference Include="System.IdentityModel.Tokens.Jwt" Version="8.6.0" />
    <PackageReference Include="xunit" Version="2.9.3" />
    <PackageReference Include="xunit.runner.visualstudio" Version="3.0.2">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
</ItemGroup>
```

## Autenticación
El sistema usa JWT (JSON Web Tokens) para la autenticación. Los tokens se emiten después de que un usuario inicia sesión y se usan para autorizar las solicitudes a los endpoints protegidos.

## Diagramas
Para esta sección, hice unos cuantos diagramas antes de iniciar el código como tal. Esto se hace como buena práctica para poder tener todo el diseño del sistema en mente antes de iniciar a desarrollar.

### Imaginación del problema
Para este primer paso la idea era empezar a pensar como estaba concibiendo el problema. En mi caso, la forma en como lo imaginé eran estacionamientos que tenían unos soportes los cuales cada uno tenía un sensor IoT, por lo que al final cada sensor tenía un solo estacionamiento y cada estacionamiento un solo sensor.

![Proceso de pensamiento](./images-docs/ImageThinking.png)

### Diagrama de clases
Para esta parte, traté de conseguir toda la información que tenía sobre las entidades pertenecientes al problema, cree las interfaces, controladores, servicios, etc., tratando de mantener el máximo desacoplamiento posible porque si el problema llegara a crecer, sería más fácil el poder escalarlo de esa forma. Además, el poder hacer que los servicios y las controladores referencien a las interfaces, nos permite el tener aún mayor desacoplamiento. (Haz zoom o ve a la carpeta con la imagen para poder apreciar el diagrama).

![Diagrama de clases](./images-docs/SmartParkingSystem-ClassDiagram.png)

## Instrucciones para correr el proyecto

 1. Clona el repositorio:
 `git clone https://github.com/G-Delgado/smart-parking-system`
 2. Navega al directorio del proyecto:
 `cd smart-parking-system`
 3. Restaura las dependencias:
 `dotnet restore`
 4. Ejecuta el proyecto:
 `dotnet run`
 5. Accede a la API de Swagger: `http://localhost:5000/swagger`

Si quieres ejecutar las pruebas de AuthController:
 1. Accede al proyecto de los test
 `cd smart-parking-system/SmartParkingSystem.Tests`
 2. Restaura las dependencias
 `dotnet restore`
 3. Ejecuta las pruebas
 `dotnet test`

## Agradecimientos
Muchísimas gracias a los que hayan visto hasta aquí :D!
