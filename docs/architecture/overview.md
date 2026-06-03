# Architecture Overview

## Overview

CinePhile Network will use a client-server architecture implemented as a modular monolith. The application is designed to provide enough realism for application security testing while avoiding the operational complexity of a distributed microservice system.

The system will consist of a browser-based frontend, a backend REST API, a relational database, and a local deployment environment based on Docker Compose.

The planned request flow is:

```text
Browser
  ↓
Cloudflare Tunnel
  ↓
React Frontend
  ↓
ASP.NET REST API
  ↓
PostgreSQL Database
```

---

## Architecture Style

The backend will be implemented as a modular monolith with DDD software design.

This means that the application is deployed as a single backend service, but the internal codebase is separated into logical modules such as:

* Identity and access management
* User profiles
* Movies and watchlists
* Social feed
* Groups
* Notifications
* Administration and moderation
* Direct messages

This approach was selected because it provides a realistic internal structure while keeping deployment and development manageable.

The Domain Driven Software Design (DDD) approach will ensure codebase entities are reflecting business domain, making the system easier to understand and maintain.

Microservices are intentionally avoided during the initial phases because they would add infrastructure complexity that is not required for the project goals.

---

## Main Components

### Browser Client

The browser is the primary user interface for regular users and administrators.

Users interact with the application through a single page application served by the frontend.

### Cloudflare Tunnel

Cloudflare Tunnel may be used to expose the local application environment for testing purposes.

This component represents the public entry point into the application and is relevant for later security assessment activities involving headers, routing, exposure, and proxy configuration.

### React Frontend

The frontend will be implemented as a React single page application.

Its responsibilities include:

* Rendering user interfaces
* Handling routing
* Managing client-side state
* Sending REST API requests to the backend
* Handling authentication tokens on the client side

During the initial vulnerable phases, the frontend will use the native `fetch` API for HTTP requests.

A more structured request handling approach, such as TanStack Query, may be introduced during the security hardening phase if frontend state management, request caching, or authorization issues demonstrate the need for it.

### ASP.NET REST API

The backend will be implemented as an ASP.NET REST API.

Its responsibilities include:

* Authentication
* Authorization
* Business logic
* Input processing
* Data validation
* API responses
* Communication with the database

Although deployed as a single backend service, the API will be internally organized into feature modules.

Also some API endpoints will rely on client-side validation only, which will be described in more details in [planned vulnerabilites documentation](../security/planned-vulnerabilities.md).

### PostgreSQL Database

PostgreSQL will be used as the primary relational database.

The database will store application data such as:

* Users
* Profiles
* Movies
* Watchlists
* Posts
* Comments
* Groups
* Notifications
* Reports
* Administrative actions
* Messages

### Entity Framework Core

Entity Framework Core will be used as the Object-Relational Mapper between the ASP.NET API and PostgreSQL.

EF Core will be responsible for:

* Mapping application entities to database tables
* Managing migrations
* Querying data
* Persisting changes

---

## Authentication and Authorization

Authentication will be based on JSON Web Tokens.

After successful login, the backend issues a token that the frontend uses to authenticate future API requests.

Authorization will be role-based.

The system will support at least the following roles:

* Anonymous user
* Regular user
* Administrator

Role-based authorization will be used to restrict access to administrative functionality and protected user actions.

Authorization behavior may intentionally differ between vulnerable and hardened phases of the project to support security testing and remediation activities.

---

## Local Deployment

The local deployment environment will use Docker Compose.

The expected local environment includes:

* Frontend container
* Backend API container
* PostgreSQL container
* Optional reverse proxy / tunnel configuration

Docker Compose is used to make the environment reproducible and easier to run during development, testing, security assessment, and training exercises.

---

## Security-Relevant Architecture Notes

The architecture is intentionally designed to support both vulnerable and hardened security states.

During later phases, selected vulnerabilities will be mitigated and documented as part of the security hardening process.

The architecture must therefore implement some vulnerabilities.

---

## Initial Design Decisions

### Modular Monolith Instead of Microservices

A modular monolith is used to keep the system understandable and maintainable while still allowing realistic separation of application domains.

### REST API Instead of GraphQL

REST is used because it is simple, widely understood, and sufficient for the project requirements.

### Native Fetch in Early Phases

Native `fetch` will be used in the frontend during early development phases to keep implementation simple and expose request-handling decisions clearly.

A more advanced data-fetching library may be introduced later as part of hardening or maintainability improvements.

### Docker Compose for Local Deployment

Docker Compose is selected for local deployment because it provides reproducibility without requiring Kubernetes or cloud infrastructure.

### JWT-Based Authentication

JWT is selected for authentication because it is common in modern web applications and provides realistic security testing opportunities around token storage, expiration, validation, and authorization handling.

