# Planned Vulnerabilities

## Overview

The purpose of this document is to define the intentionally introduced vulnerabilities that will be implemented throughout the project lifecycle.

These vulnerabilities are introduced for educational purposes to support:

* Penetration testing practice (both black box and white box)
* Application security assessments
* Threat modeling
* Vulnerability management
* Security hardening activities
* OWASP SAMM alignment exercises

Each vulnerability follows a lifecycle:

```text
Planned → Implemented → Verified → Fixed / Accepted Risk
```

The list is expected to evolve as the application grows and new functionality is introduced.

---

# Vulnerability Catalog

| ID     | Phase | Category                                | Area               |
| ------ | ----- | --------------------------------------- | ------------------ |
| PV-001 | PoC   | Stored Cross-Site Scripting (XSS)       | Social Feed        |
| PV-002 | PoC   | Insecure Direct Object Reference (IDOR) | User Profiles      |
| PV-003 | PoC   | Frontend-Only Authorization             | Administration     |
| PV-004 | PoC   | User Enumeration                        | Authentication     |
| PV-005 | PoC   | Weak Password Policy                    | Authentication     |
| PV-006 | MVP   | Stored Cross-Site Scripting (XSS)       | Profile Comments   |
| PV-007 | MVP   | Unrestricted File Upload                | Profile Pictures   |
| PV-008 | MVP   | Mass Assignment                         | Profile Management |
| PV-009 | MVP   | Information Disclosure                  | Search             |
| PV-010 | MVP   | Missing Rate Limiting                   | Authentication     |
| PV-011 | MVP   | Cross-Site Request Forgery (CSRF)       | User Settings      |
| PV-012 | MVP   | Insecure Direct Object Reference (IDOR) | Direct Messages    |
| PV-013 | MVP   | Broken Group Authorization              | Groups             |
| PV-014 | MVP   | Excessive Data Exposure                 | REST API           |
| PV-015 | MVP   | Missing Audit Logging                   | Administration     |

---

# Vulnerability Details

## PV-001 — Stored Cross-Site Scripting (XSS)

### Phase

PoC

### Area

Social Feed

### Description

User-generated post content is rendered without proper output encoding or sanitization.

### Educational Objective

Demonstrate:

* XSS discovery
* Payload construction
* Impact assessment
* Remediation through output encoding

---

## PV-002 — Insecure Direct Object Reference (IDOR)

### Phase

PoC

### Area

User Profiles

### Description

Profile-related endpoints expose object identifiers that may be modified to access resources belonging to other users.

### Educational Objective

Demonstrate:

* Authorization testing
* Resource ownership validation
* Horizontal privilege escalation

---

## PV-003 — Frontend-Only Authorization

### Phase

PoC

### Area

Administration

### Description

Administrative functionality is hidden through frontend controls while backend endpoints do not consistently enforce authorization requirements.

### Educational Objective

Demonstrate:

* Authorization bypass
* Vertical privilege escalation
* Importance of server-side authorization

---

## PV-004 — User Enumeration

### Phase

PoC

### Area

Authentication

### Description

Authentication responses disclose whether a user account exists.

### Example

* "User does not exist"
* "Incorrect password"

### Educational Objective

Demonstrate:

* Information disclosure
* Account discovery techniques

---

## PV-005 — Weak Password Policy

### Phase

PoC

### Area

Authentication

### Description

The application accepts weak passwords without complexity or length requirements.

### Educational Objective

Demonstrate:

* Credential attacks
* Authentication hardening

---

## PV-007 — Unrestricted File Upload

### Phase

MVP

### Area

Profile Pictures

### Description

Uploaded files are not sufficiently validated before storage and processing.

### Educational Objective

Demonstrate:

* File upload abuse
* Content validation weaknesses
* Dangerous file handling

---

## PV-008 — Mass Assignment

### Phase

MVP

### Area

Profile Management

### Description

API endpoints bind user-supplied objects directly to application entities without explicit field restrictions.

### Educational Objective

Demonstrate:

* API security testing
* Privilege escalation through hidden fields
* Secure DTO usage

---

## PV-010 — Missing Rate Limiting

### Phase

MVP

### Area

Authentication

### Description

Authentication endpoints do not limit repeated requests.

### Educational Objective

Demonstrate:

* Credential stuffing
* Password spraying
* Authentication protection mechanisms

---

# Future Vulnerabilities

The following categories may be introduced in later project phases:

* SSRF
* Business Logic Vulnerabilities
* Race Conditions
* Insecure File Processing
* Sensitive Data Exposure
* Misconfigured Security Headers
* JWT Validation Weaknesses
* HTTP Request Desynchronization
