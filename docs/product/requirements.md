# Product requirements
## Overview

CinePhile Network is a social networking application for movie enthusiasts designed to simulate the development and operation of a modern web application.

The primary purpose of the project is educational. The application provides realistic functionality and architecture to support penetration testing, application security activities, vulnerability management, and secure software development lifecycle (SSDLC) practices.

While the application intentionally limits feature depth, it aims to provide sufficient complexity to resemble a real-world system and expose meaningful attack surfaces.

---

## Functional Requirements

### 1. Identity and Access Management
- Users can register.
- Users can log in.
- Users can log out.
- Users can optionally enable MFA.
- The system supports at least two roles: regular user and administrator.

### 2. User Profiles
- Users can edit their display name, tag, description, and profile picture.
- Users can configure profile visibility.
- Users can blacklist other users.

### 3. Movies and Watchlists
- Users can create movie entries with name, description, picture, and tags.
- Users can create watchlists.
- Users can add movies to watchlists using statuses such as planned, watching, watched, or abandoned.

### 4. Social Feed
- Users can publish posts.
- Users can comment on posts.
- Users can comment on user profiles.
- Users can like posts or comments.
- Users can follow other users.
- Users can mention users and reference movies.

### 5. Groups
- Users can create groups.
- Users can join and leave groups.
- Groups can be public or private.
- Private groups use a whitelist.
- Public groups may use a blacklist.

### 6. Search
- Users can search for people, posts, movies, and groups.

### 7. Notifications
- Users can subscribe to notifications from people or groups.
- Users receive notifications about likes, comments, mentions, and new followers.
- Users can manage notification preferences.

### 8. Administration and Moderation
- Administrators can access a dashboard with basic statistics.
- Administrators can moderate users, posts, comments, movies, and groups.
- Users can report content or users.
- Administrators can review and respond to reports.

### 9. Direct Messages (optional)
- Users can send messages to each other.

## User Roles

### Anonymous User

Can:
- Register
- Log in
- View public profiles
- View public groups

### Registered User

Can:
- Access all social features
- Create and manage content
- Configure profile settings
- Join groups
- Send direct messages

### Administrator

Can:
- Access administrative dashboards
- Moderate content
- Manage users
- Process reports
- View audit logs

## Non-Functional Requirements

- The application shall expose a REST API.
- The application shall have a more complex infrastructure with Proxy, Front-End, Back-End and Database servers
- The application shall use a relational database.
- The application shall support containerized deployment.
- The application shall maintain audit logs for administrative actions.
- The application shall support both vulnerable and hardened security states throughout the project lifecycle.

## Scope Limitations

This product intentionally limits feature depth. The goal is not to build a complete social network, but to provide enough realistic functionality to support application security testing, vulnerability research, security documentation, and hardening activities.
Also scope of PoC and MVP differs and their requirements will be described in separate files [PoC](poc-reqs.md) and [MVP](mvp-reqs.md)
