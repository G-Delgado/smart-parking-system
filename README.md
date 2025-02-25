# Smart Parking Lot Management System (IoT)

## Project Description

This project is a smart parking management system that interacts with IoT sensors located in parking spots. Through a RESTful API, the system simulates the occupation and release of parking spots and keeps track of their status.

## Table of Contents
- [Main Features](#main-features)
- [API Endpoints](#api-endpoints)
- [Project Structure](#project-structure)
- [Dependency Injection](#dependency-injection)
- [Tests](#tests)
- [Authentication](#authentication)
- [Diagrams](#diagrams)
- [How to Run the Project](#how-to-run-the-project)

## Main Features

1. **Detect when a car enters or exits a parking spot**:
   - IoT devices simulate this behavior by sending API requests to mark parking spots as occupied or free.

2. **Track the number of available parking spots**:
   - The system maintains a dynamic count of available spots.

3. **Expose a RESTful API that returns the status of parking spots**:
   - It allows you to know whether a spot is occupied or free.

4. **Perform basic CRUD operations for parking spots and IoT devices**:
   - You can add, delete, and modify parking spots and IoT devices.

### API Endpoints

- **POST /api/parking-spots/{id}/occupy**: Marks a parking spot as occupied.
- **POST /api/parking-spots/{id}/free**: Marks a parking spot as free.
- **GET /api/parking-spots**: Returns the status of all parking spots.
- **POST /api/parking-spots**: Adds a new parking spot.
- **DELETE /api/parking-spots/{id}**: Deletes a parking spot.
  
### Business Rules

- A parking spot can either be free or occupied.
- The system keeps a dynamic count of available spots.
- Only registered IoT devices can occupy or free a parking spot.

### Simulated IoT Devices

- IoT devices are identified by a unique GUID.
- Only registered devices can send requests to occupy or free a parking spot.

### Basic Validations

- Parking spots cannot be occupied twice without being freed first.
- Parking spots cannot be freed if they are already free.

## Project Structure

### Controllers
- **AuthController**: Handles authentication and authorization operations.
- **IoTDeviceController**: Manages operations related to IoT devices.
- **ParkingController**: Manages operations related to parking spots.

### DTOs
- **CreateIoTDeviceDTO**: Represents the information required to create an IoT device.
- **CreateParkingSpotDTO**: Represents the information required to create a parking spot.
- **CreateUserDTO**: Represents the information required to create a user.
- **IoTDeviceDTO**: Represents the data of an IoT device.
- **LoginUseDTO**: Contains the login credentials of a user.
- **ParkingSpotDTO**: Represents the data of a parking spot.
- **UserDTO**: Represents the data of a user.

### Models
- **IoTDevice**: Represents an IoT device.
- **ParkingSpot**: Represents a parking spot.
- **ParkingState**: Enumerates the possible states of a parking spot (occupied, free).
- **Role**: Defines user roles (e.g., Administrator, User).
- **User**: Represents a user in the system.

### Repositories
- **IoTDeviceRepository**: Repository for managing operations on IoT devices.
- **IIoTDeviceRepository**: Interface for IoT device repository operations.
- **ParkingRepository**: Repository for managing operations on parking spots.
- **IParkingRepository**: Interface for parking spot repository operations.
- **UserRepository**: Repository for managing operations on users.
- **IUserRepository**: Interface for user repository operations.

### Services
- **AuthService**: Service for managing user authentication and authorization.
- **IAuthService**: Interface for authentication and authorization service.
- **IoTDeviceService**: Service for managing IoT devices.
- **IIoTDeviceService**: Interface for IoT device service.
- **ParkingService**: Service for managing parking spots.
- **IParkingService**: Interface for parking service.

## Dependency Injection

The system uses **dependency injection** for managing services and repositories. This practice ensures that classes are decoupled and promotes scalability and extensibility. By using interfaces and dependency injection, we can easily modify the implementation of a service or repository without affecting other parts of the system.

### Project Scalability

The project is designed to be scalable. By following the principle of separation of concerns, each component (Controller, Service, Repository, etc.) has a single responsibility. This makes it easier to add new features or modify existing ones without causing side effects in other parts of the system.

Dependency injection and layer structuring allow the system to grow in an organized manner, making it easier to integrate new services (e.g., new types of IoT sensors) or migrate the database (e.g., transitioning from in-memory storage to a real database like SQLite or PostgreSQL).

## Tests

The project includes unit tests to ensure the correct functioning of the system's key operations. The tests mainly focus on the **AuthController**, ensuring that authentication and authorization processes are handled correctly.

### Used Dependencies

The project uses the following dependencies:

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
## Authentication
The system uses JWT (JSON Web Tokens) for authentication. Tokens are issued after a user logs in and are used to authorize requests to protected endpoints.

## Diagrams
For this section, I made a few diagrams before starting the actual code. This is done as a good practice to have the entire system design in mind before beginning development.

### Problem Imagination
For this first step, the idea was to start thinking about how I was conceiving the problem. In my case, I imagined parking spaces having supports with IoT sensors, where each sensor had one parking space, and each parking space had one sensor.

![Thought Process](./images-docs/ImageThinking.png)

### Class Diagram
For this part, I tried to gather all the information I had about the entities related to the problem, creating interfaces, controllers, services, etc., trying to maintain the highest decoupling possible, because if the problem were to grow, it would be easier to scale it that way. Additionally, having services and controllers reference interfaces allows for even greater decoupling. (Zoom in or go to the folder with the image to appreciate the diagram).

![Class Diagram](./images-docs/SmartParkingSystem-ClassDiagram.png)

## How to Run the Project

 1. Clone the repository:
 `git clone https://github.com/G-Delgado/smart-parking-system`
 2. Navigate to the project directory:
 `cd smart-parking-system`
 3. Restore dependencies:
 `dotnet restore`
 4. Run the project:
 `dotnet run`
 5. Access the Swagger API: `http://localhost:5000/swagger`

If you want to run tests for the AuthController:
 1. Go to the test project:
 `cd smart-parking-system/SmartParkingSystem.Tests`
 2. Restore dependencies:
 `dotnet restore`
 3. Run the tests
 `dotnet test`

## Acknowledgements
A big thank you to everyone who has made it this far :D!
