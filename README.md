# Education Platform Microservices

A modern online education platform built with **.NET 9.0** and **Microservice Architecture**.

This project is being developed as a real-world, scalable education platform while exploring modern backend architecture, inter-service communication, distributed data management, containerization, authentication, and asynchronous messaging.

The project is inspired by an Udemy-like online course platform and is developed incrementally by building independent microservices and integrating them through well-defined communication patterns.

---

## 🚀 Technologies

### Backend

- .NET 9.0
- ASP.NET Core
- C#
- Minimal API
- RESTful API
- MediatR
- CQRS
- Clean Architecture
- Onion Architecture
- FluentValidation
- AutoMapper
- Refit

### Microservice Infrastructure

- Docker
- Docker Compose
- .NET Aspire
- YARP API Gateway
- RabbitMQ
- MassTransit

### Databases & Storage

- MongoDB
- PostgreSQL
- SQL Server
- Redis

### Authentication & Authorization

- Keycloak
- OAuth 2.0
- OpenID Connect
- JWT
- Access Token
- Refresh Token

### Frontend

- ASP.NET Core Razor Pages

---

## 🏗️ Architecture

The application is designed using a **Microservice Architecture**, where each business domain is developed as an independent service.

Each microservice can have its own:

- Business logic
- Database
- API
- Deployment lifecycle
- Scaling strategy

High-level architecture:

```text
                         ┌─────────────────────┐
                         │   Razor Pages UI    │
                         └──────────┬──────────┘
                                    │
                                    ▼
                         ┌─────────────────────┐
                         │    API Gateway      │
                         │       YARP          │
                         └──────────┬──────────┘
                                    │
              ┌─────────────────────┼─────────────────────┐
              │                     │                     │
              ▼                     ▼                     ▼
      ┌───────────────┐     ┌───────────────┐     ┌───────────────┐
      │    Catalog    │     │    Basket     │     │   Discount    │
      │   Microservice│     │  Microservice │     │  Microservice │
      └───────┬───────┘     └───────┬───────┘     └───────┬───────┘
              │                     │                     │
              ▼                     ▼                     ▼
          MongoDB                 Redis                PostgreSQL


      ┌───────────────┐     ┌───────────────┐     ┌───────────────┐
      │     Order     │     │ Fake Payment  │     │     File      │
      │  Microservice │     │  Microservice │     │  Microservice │
      └───────┬───────┘     └───────────────┘     └───────────────┘
              │
              ▼
          SQL Server


                         ┌─────────────────────┐
                         │      RabbitMQ        │
                         │    + MassTransit     │
                         └──────────┬──────────┘
                                    │
                     Asynchronous Communication


                         ┌─────────────────────┐
                         │      Keycloak       │
                         │ Authentication /    │
                         │    Authorization    │
                         └─────────────────────┘
