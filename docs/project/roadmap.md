# Project Roadmap

## Overview

The Vulnerable Cinephile Social Network is developed as an educational application security project. The project aims to simulate the lifecycle of a modern web application, from an intentionally vulnerable proof of concept to a progressively hardened system following secure development and OWASP SAMM principles.

Each phase concludes with a documented milestone branch that preserves the state of the application, its architecture, security posture, findings, and training materials.

---

# Phase 1 — Planning

## Objective

Define project goals, scope, architecture, and security objectives.

## Activities

* Define functional requirements
* Define non-functional requirements
* Define learning objectives
* Create initial architecture
* Create initial data-flow diagrams
* Define planned vulnerabilities
* Define project documentation structure

## Deliverables

### Project

* Vision document
* Requirements document
* Roadmap

### Architecture

* System context diagram
* Initial data-flow diagram

### Security

* Threat model draft
* Planned vulnerability catalog

### Milestone

* `planning`

---

# Phase 2 — Vulnerable Proof of Concept

## Objective

Create a minimal working application containing intentionally vulnerable functionality.

## Activities

* Implement authentication
* Implement user profiles
* Implement movie reviews
* Introduce planned vulnerabilities
* Verify exploitability of planned vulnerabilities

## Security Activities

* Validate all planned vulnerabilities
* Record exploitation evidence

## Deliverables

### Application

* Functional PoC

### Security

* Vulnerability verification report
* Updated threat model

### Training

* Initial exploitation labs

### Milestone

* `poc-vulnerable`

---

# Phase 3 — MVP Expansion

## Objective

Expand the application into a realistic social networking platform.

## Activities

* Implement watchlists
* Implement following system
* Implement notifications
* Implement media uploads
* Expand API surface

## Security Activities

* Introduce additional planned vulnerabilities
* Update attack surface analysis

## Deliverables

### Application

* Expanded MVP

### Architecture

* Updated architecture diagrams
* Updated data-flow diagrams

### Security

* Updated vulnerability catalog
* Updated planned vulnerability catalog

### Training

* New exploitation labs

### Milestone

* `mvp-expanded`

---

# Phase 4 — Security Assessment

## Objective

Perform a structured security assessment of the application.

## Activities

* Black-box testing
* White-box testing
* Manual code review
* Threat analysis

## Security Activities

* Verify planned vulnerabilities
* Identify unplanned vulnerabilities
* Assess business logic flaws
* Create risk ratings

## Deliverables

### Reports

* Penetration test report
* Vulnerability catalog
* Risk register

### Training

* Labs based on discovered attack paths

### Milestone

* `security-assessment`

---

# Phase 5 — Initial Security Hardening

## Objective

Improve the security posture while preserving selected educational vulnerabilities.

## Activities

* Fix selected vulnerabilities
* Implement authorization controls
* Improve input validation
* Improve authentication controls
* Improve security headers

## Security Activities

* Retesting
* Verification of fixes
* Risk acceptance review

## Deliverables

### Security

* Hardening report
* Verification report
* Updated risk register

### Architecture

* Updated security architecture

### Milestone

* `initial-hardening`

---

# Phase 6 — OWASP SAMM Alignment

## Objective

Evaluate and improve security maturity using OWASP SAMM practices.

## Activities

* Assess current maturity
* Define security requirements
* Introduce secure development practices
* Improve governance and verification activities

## Security Activities

* SAMM assessment
* Gap analysis
* Improvement planning

## Deliverables

### Security

* SAMM assessment report
* Security requirements document
* Secure development guidelines

### Milestone

* `samm-aligned`

---

# Phase 7 — Final Documentation and Polish

## Objective

Consolidate project artifacts and prepare the project as a learning and portfolio resource.

## Activities

* Review documentation
* Review diagrams
* Review reports
* Review labs
* Validate project structure

## Deliverables

### Documentation

* Complete architecture documentation
* Complete security documentation
* Complete training materials

### Training

* Offensive labs
* Defensive labs

### Reports

* Final project summary
* Lessons learned

### Milestone

* `final-polish`

---

# Project Success Criteria

The project is considered complete when:

* All planned phases have been completed.
* All milestone branches have been preserved.
* Planned vulnerabilities have been documented and verified.
* Security assessments have been performed and documented.
* Security hardening activities have been validated.
* OWASP SAMM alignment has been assessed.
* Educational labs have been created from verified findings.
* Documentation accurately reflects the evolution of the application and its security posture.
