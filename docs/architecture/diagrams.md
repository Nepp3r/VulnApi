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
### Level 0 DFD:
```mermaid
flowchart LR
    users["Users"]
    admins["Administrators"]

    app["CinePhile Network"]

    db[("PostgreSQL Database")]

    users -->|"User input, content, search queries"| app
    app -->|"Profiles, feeds, notifications, search results"| users

    admins -->|"Moderation actions, report reviews"| app
    app -->|"Dashboard data, reports, audit data"| admins

    app -->|"Read/write application data"| db
    db -->|"Stored application data"| app
```

### Level 1 DFD:
```mermaid
flowchart LR
    anon["Anonymous User"]
    user["Regular User"]
    admin["Administrator"]

    auth["1. Authentication"]
    profile["2. Profile Management"]
    movies["3. Movies and Watchlists"]
    social["4. Social Feed"]
    groups["5. Groups"]
    search["6. Search"]
    notifications["7. Notifications"]
    adminPanel["8. Administration and Moderation"]
    messages["9. Direct Messages"]

    db[("PostgreSQL Database")]

    anon -->|"Registration data / login credentials"| auth
    auth -->|"Authentication result / JWT"| anon
    auth -->|"User account data"| db
    db -->|"User account record"| auth

    anon -->|"Search query"| search
    user -->|"Search query"| search
    search -->|"Search results"| anon
    search -->|"Search results"| user
    search -->|"Search criteria"| db
    db -->|"Users / posts / movies / groups"| search

    user -->|"Profile updates / visibility settings / blacklist entries"| profile
    profile -->|"Profile data"| user
    profile -->|"Profile records"| db
    db -->|"Profile records"| profile

    user -->|"Movie data / watchlist changes"| movies
    movies -->|"Movie and watchlist data"| user
    movies -->|"Movie and watchlist records"| db
    db -->|"Movie and watchlist records"| movies

    user -->|"Posts / comments / likes / follows / mentions"| social
    social -->|"Feed content"| user
    social -->|"Social content records"| db
    db -->|"Social content records"| social

    user -->|"Group creation / membership changes / group content"| groups
    groups -->|"Group data"| user
    groups -->|"Group records / membership records"| db
    db -->|"Group records / membership records"| groups

    user -->|"Notification preferences / subscriptions"| notifications
    notifications -->|"Notifications"| user
    notifications -->|"Notification records"| db
    db -->|"Notification records"| notifications

    user -->|"Message content / conversation actions"| messages
    messages -->|"Conversation data / message delivery"| user
    messages -->|"Message records"| db
    db -->|"Message records / conversation records"| messages

    admin -->|"Moderation actions / report responses"| adminPanel
    adminPanel -->|"Dashboard data / moderation results"| admin
    adminPanel -->|"Administrative records / moderation records"| db
    db -->|"Reports / users / content / audit data"| adminPanel
```

## 4. Trust Boundary Diagram
Purpose:
Shows security boundaries between users, frontend, backend, and database.

```mermaid
flowchart LR
    User["Anonymous / Regular User"]

    subgraph Internet["Untrusted Zone"]
        User
    end

    subgraph App["Application Zone"]
        Frontend["React SPA"]
        Backend["ASP.NET API"]
    end

    subgraph Data["Trusted Data Zone"]
        DB[("PostgreSQL")]
    end

    User -->|"HTTPS"| Frontend
    Frontend -->|"REST API"| Backend
    Backend -->|"EF Core"| DB
```

## 5. Authentication Flow Diagram
Purpose:
Shows JWT-based authentication flow between frontend and backend.
```mermaid
sequenceDiagram
  actor User
  participant Frontend
  participant API
  User ->> Frontend: Enters credentials
  Frontend ->> API: Issues post request with credentials
  API ->> API: Verify credentials
  API ->> Frontend: Returns signed JWT
  Frontend ->> Frontend: Stores JWT
  Frontend ->> User: Authentication and Authorization complete
  User ->> Frontend: Sends request
  Frontend ->> API: Attaches JWT
  API ->> API: Verifies JWT
  API ->> Frontend: Returns response
  Frontend ->> User: Relays response
```
