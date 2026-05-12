# Repository Boundaries

## Purpose

This document defines repository ownership boundaries for the ProofWorks platform.

Repository boundaries exist to ensure:

- maintainable implementation ownership
- clean decomposition
- scalable development workflows
- repository autonomy
- AI-friendly implementation scopes
- safe public/private separation

This document should be updated whenever repositories are added, split, privatized, or re-scoped.

---

# Repository Strategy

ProofWorks intentionally separates:

- product implementation
- frontend implementation
- infrastructure concerns
- engineering demonstration content
- private product IP

The platform favors:

- clear repository ownership
- minimal overlap
- explicit contracts
- feature-level coordination
- repository-local implementation Stories

---

# Current Repository Model

## proofworks-artistops-api

### Responsibility

Primary backend application repository.

### Owns

- .NET backend application
- REST APIs
- FastEndpoints usage
- application modules
- domain logic
- operational rules
- persistence
- backend validation
- internal domain events
- backend observability
- authentication integration
- authorization enforcement
- API contracts
- backend tests

### Does NOT Own

- frontend UI
- frontend routing
- frontend rendering
- infrastructure provisioning
- reusable engineering playbook examples
- protected commercial product IP that has been privatized

---

## proofworks-artistops-web

### Responsibility

Primary frontend application repository.

### Owns

- React frontend
- frontend routing
- feature UI composition
- dashboard rendering
- frontend state management
- API consumption
- interaction workflows
- visual operational visibility
- filtering/sorting/presentation logic
- frontend tests

### Does NOT Own

- operational business rules
- persistence rules
- backend validation rules
- release lifecycle enforcement
- protected commercial APIs
- infrastructure provisioning

---

## proofworks-engineering-playbook

### Responsibility

Public engineering demonstration repository.

### Owns

- reusable engineering examples
- architecture demonstrations
- algorithms
- design patterns
- coding challenge solutions
- extension method examples
- educational implementation patterns
- interview-focused engineering demonstrations

### Purpose

This repository demonstrates engineering capability publicly without exposing protected product IP.

### Does NOT Own

- production ArtistOps product logic
- protected workflow engines
- proprietary operational logic
- customer-sensitive capabilities
- protected APIs
- commercial automation systems

---

## Documentation Repository / Documentation Structure

### Responsibility

Architecture, Product, Governance, and Planning documentation.

### Owns

- milestone documentation
- Epic documentation
- architecture decisions
- decomposition guidance
- sequencing guidance
- governance documents
- workflow definitions
- implementation planning

---

# Feature Coordination Model

## Features

Features may span repositories.

Example:

Feature:
Create Release

May require:
- backend API Story
- frontend UI Story

---

## Stories

Stories must remain repository-local.

### Good Example

Feature:
Create Release

Stories:
- API repo Story
- Web repo Story

### Bad Example

Single Story:
"Build Create Release"

This creates:
- unclear ownership
- oversized implementation scope
- AI implementation ambiguity
- difficult review boundaries

---

# Cross-Repository Coordination

Cross-repository coordination should happen at the Feature level.

Repositories should coordinate through:

- API contracts
- DTO definitions
- endpoint documentation
- Story sequencing
- implementation readiness

Repositories should NOT tightly couple implementation internals.

---

# Public vs Private Repository Strategy

## Public Repositories

Public repositories may demonstrate:

- architecture quality
- modular decomposition
- observability patterns
- infrastructure approaches
- operational workflows
- engineering quality

Public repositories should function as:

- engineering demonstrations
- portfolio artifacts
- interview discussion material
- educational references

---

## Private Repositories

Private repositories are required when functionality becomes commercially valuable.

### Trigger Conditions

A repository or module should become private when it contains:

- proprietary workflow engines
- sellable libraries
- commercially valuable operational intelligence
- protected automation systems
- artist/customer-sensitive capabilities
- protected AI operational systems
- monetizable platform capabilities

---

# IP Protection Migration Rule

When Architecture determines that a capability has crossed into protected product IP territory:

The implementation process must STOP until:

- a private repository exists
- security expectations are defined
- deployment boundaries are defined
- public exposure risk is reviewed
- protected APIs are isolated

Public repositories should never accidentally become the product itself.

---

# Future Repository Expansion

Additional repositories may eventually exist for:

- infrastructure/IaC
- deployment automation
- AI/RAG systems
- protected operational engines
- mobile applications
- shared UI libraries
- shared SDKs
- internal platform tooling

New repositories should only be introduced when justified by:

- ownership clarity
- deployment independence
- IP separation
- operational complexity
- scaling requirements

---

# Repository Naming Guidance

Repositories should favor:

- explicit naming
- operational clarity
- stable terminology

Prefer:

- proofworks-artistops-api
- proofworks-artistops-web

Avoid:

- generic names
- ambiguous abbreviations
- trend-based naming

Repository names should remain understandable years later.

---

# Repository Boundary Philosophy

Repository boundaries should optimize for:

- maintainability
- explainability
- reviewability
- operational clarity
- AI-assisted implementation
- future scalability

The goal is not maximum repository count.

The goal is clean ownership with sustainable evolution.