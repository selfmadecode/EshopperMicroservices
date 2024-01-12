# Microservice Application with gRPC, EfCore, C# .NET, RabbitMQ, Repository Pattern, Clean Architecture, and API Gateway with Ocelot

## Overview

This microservice application is built using C# with .NET, following the principles of clean architecture, and utilizing technologies such as gRPC for communication, Entity Framework Core (EfCore) for data access, RabbitMQ for messaging, and Ocelot for API gateway.

## Technologies Used

- **C# .NET:** The primary programming language used for building the microservices.
- **gRPC:** A high-performance, open-source framework for building remote procedure call (RPC) APIs.
- **Entity Framework Core (EfCore):** A lightweight, extensible, and cross-platform version of the popular Entity Framework data access technology.
- **RabbitMQ:** A message broker that enables communication between microservices through messaging.
- **Repository Pattern:** An architectural pattern that separates the logic that retrieves data from the underlying storage system (EfCore in this case).
- **Clean Architecture:** A software design philosophy that separates the concerns of application into distinct layers to make the codebase more maintainable and testable.
- **API Gateway using Ocelot:** A .NET API Gateway that acts as a reverse proxy for handling routing, authentication, and other cross-cutting concerns.

## Microservices

1. **Basket.API:** allows you users to add items to their basket, remover item and checkuot.
   - Technologies used: gRPC, EfCore, RabbitMQ, Mass Transit

2. **Ordering.API:** Allows users to make order, get the order and pay
   - Technologies used: CQRS using Mediator, EfCore, RabbitMQ, Clean architecture

3. Catalog.API
4. Discount.API
5. OcelotApiGw
   
## Setup

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/selfmadecode/eshoppermicroservices.git
   ```

2. **Build and Run Microservices:**
   - Follow the README instructions in each microservice directory for building and running.

3. **API Gateway Setup:**
   - Navigate to the `OcelotApiGw` directory.
   - Follow the README instructions for setting up and configuring Ocelot.

4. **Database Migration:**
   - Run EF Core migrations to initialize the databases for each microservice.

## Contributing

Contributions are welcome! If you find any issues or have suggestions, please open an issue or submit a pull request.

## License

This microservice application is open-source and available under the MIT License.

**Happy coding!**
