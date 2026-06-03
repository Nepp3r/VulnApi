# Architecture Diagrams

## 1. System Context Diagram
Purpose:
Shows what external entities communicate with application and what is their relation to it.

```mermaid
graph LR
    RegularUser["Regular User"]
    Administrator["Administrator"]

    CinePhile(("CinePhile"))

    AnonymousUser["Anonymous User"]

    RegularUser -- Uses social network features --> CinePhile
    CinePhile -- Communicates results, sends notifications --> RegularUser
    Administrator -- Moderates users, content, and reports --> CinePhile
    CinePhile -- Sends user reports, shows metrics --> Administrator
    AnonymousUser -- Looks at the content --> CinePhile
    CinePhile -- Grants limited capabilities --> AnonymousUser
```

## 2. Container Diagram
Purpose:
Shows runtime components and communication paths.

```mermaid
flowchart TD
    Browser["Web Browser"]
    CF["Cloudflare Tunnel"]
    Frontend["React SPA Frontend"]
    Backend["ASP.NET API Server"]
    DB[("PostgreSQL Database")]

    Browser -->|"REST API calls"| CF
    Browser -->|"Loads SPA"| CF
    CF --> Frontend
    CF --> Backend

    Backend -->|"EF Core queries / migrations"| DB
```

## 3. Data Flow Diagram
Purpose:
Shows how important data moves through the system.

```mermaid
graph LR
  server["ASP.NET Backend"]
  cf["Cloudflare tunnel"]
  user("Regular user")
  anon("Anonymous user")
  admin("Administrator")
  db{"PostgreSQL"}

  cf -- Proxy relaying --> server
  anon -- Log in --> cf
  anon -- View public page/group --> cf
  user -- Log out --> cf
  user -- Post --> cf
  user -- Change settings --> cf
  server -- Query --> db
  db -- Response with data --> server
```

## 4. Trust Boundary Diagram
Purpose:
Shows security boundaries between users, frontend, backend, and database.

## 5. Authentication Flow Diagram
Purpose:
Shows JWT-based authentication flow between frontend and backend.
