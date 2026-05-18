# Repository Inventory

## Purpose

This document defines the current and planned repository model for ProofWorks.

Repository inventory exists to clarify:

- repository ownership
- repository purpose
- documentation location
- public/private boundaries
- dependency direction
- extraction strategy
- implementation responsibility
- operational cognition ownership
- protected capability governance
- compositional architecture boundaries

This document is governance, not prediction.

It should prevent implementation drift without pretending to know every future repository boundary before the system earns them.

---

# Repository Strategy

ProofWorks uses a lean repository model during early development.

The current strategy is:

- keep ArtistOps product implementation together
- enforce architecture boundaries inside the monolith
- avoid premature repository splitting
- allow the application and operational usage patterns to reveal future extraction seams
- create private repositories only when IP protection or security boundaries require them
- preserve deterministic operational ownership
- preserve compositional dashboard architecture
- preserve backend-owned operational cognition

Repository boundaries are not the same thing as architecture boundaries.

Architecture boundaries are enforced through:

- modules
- responsibility ownership
- dependency direction
- frontend/backend separation
- operational cognition ownership
- public/private capability rules
- review discipline
- deterministic operational evaluation boundaries

---

# Current Authoritative Repositories

---

# proofworks-artistops

## Status

Current / Authoritative

---

## Purpose

Primary product repository for the ProofWorks ArtistOps platform.

This repository contains the real ArtistOps application and its:
- product documentation
- architecture documentation
- engineering governance
- operational workflow implementation
- frontend application
- backend application
- milestone decomposition artifacts

This repository exists to demonstrate:
- realistic engineering capability
- modular operational architecture
- maintainable implementation strategy
- believable operational workflows
- explainable architecture evolution

while preserving future commercial product boundaries.

---

## Owns

- ArtistOps product implementation
- backend API application
- frontend web application
- product documentation
- architecture documentation
- engineering governance documentation
- milestone decomposition documents
- Epic/Feature/Story planning artifacts
- implementation standards for this application
- operational workflow implementation
- deterministic operational evaluation
- dashboard composition behavior
- operational visibility systems
- ApplicationDataService orchestration patterns

---

## Documentation Areas

Expected documentation structure:

```text
/docs
  /product
  /architecture
  /engineering
```

---

## Application Areas

Expected application structure should remain simple and practical.

Conceptual structure:

```text
/src
  /api
  /web
```

Exact implementation structure may evolve, but must preserve:

- backend/frontend separation
- module ownership clarity
- release/task/blocker/health/timeline/dashboard boundaries
- decomposable modular monolith architecture
- dumb UI / smart backend philosophy
- compositional dashboard behavior
- backend-owned operational cognition

---

## Architectural Ownership Philosophy

The platform intentionally separates:

```text
Operational cognition through evaluation
```

from:

```text
Operational cognition through presentation
```

Backend systems own:
- operational evaluation
- readiness determination
- escalation semantics
- lifecycle validity
- release confidence logic
- deterministic operational truth

Frontend systems own:
- visualization
- workflow guidance
- interaction ergonomics
- contextual operational emphasis
- operational navigation support

The frontend may:
- shape backend responses into ViewModels
- support filtering/sorting interactions
- emphasize operational significance visually

The frontend must NOT:
- calculate operational truth
- derive readiness
- infer escalation semantics
- duplicate backend evaluation logic
- invent unsupported operational meaning

---

## Dashboard Governance Philosophy

Dashboard behavior should remain:

> compositional and visibility-oriented

Dashboard systems may:
- aggregate operational summaries
- compose cross-domain visibility
- support rapid operational scanning
- support layered operational navigation

Dashboard systems must NOT become:
- workflow orchestration engines
- operational evaluation owners
- hidden business logic layers
- frontend-owned operational cognition systems

Operational meaning must originate from backend operational domains.

---

## Testing Location Guidance

Tests should normally live with the project they validate.

Project-local tests are the default.

Root-level test areas should be reserved only for future:
- cross-project integration tests
- system-level operational tests
- end-to-end workflow validation

when they become justified.

Preferred principle:

```text
Tests belong close to the project they validate unless the test genuinely validates cross-project behavior.
```

---

## Public / Private Boundary

This repository may publicly demonstrate:

- modular monolith design
- clean architecture boundaries
- REST API implementation patterns
- FastEndpoints usage patterns
- React implementation patterns
- workflow modeling
- operational visibility systems
- deterministic operational evaluation
- compositional dashboard architecture
- testing strategy
- observability patterns
- CI/CD patterns
- practical engineering standards
- AI-safe decomposition practices

This repository must not expose:

- protected commercial ArtistOps IP
- proprietary workflow engines
- monetizable AI orchestration
- private artist-management algorithms
- sellable libraries intended for future commercial use
- protected operational intelligence
- protected orchestration logic
- monetizable operational evaluation systems

If implementation begins crossing into protected product IP:

- public implementation must stop
- Architecture review becomes mandatory
- a private repository/security boundary must be defined before continuing

---

# proofworks-engineering-playbook

## Status

Current / Authoritative

---

## Purpose

Public engineering demonstration and interview-preparation repository.

This repository exists to demonstrate general engineering capability through:
- reusable examples
- patterns
- algorithms
- architectural explanations
- implementation exercises
- interview-relevant demonstrations

This repository supports:
- engineering growth
- interview readiness
- explainable implementation capability
- reusable engineering education

It is intentionally separate from ArtistOps production implementation.

---

## Owns

- generalized coding patterns
- algorithm examples
- interview-relevant implementations
- reusable educational examples
- extension method examples
- pattern explanations
- dotnetfiddle-derived examples when useful
- generalized architecture demonstrations
- non-product-specific technical demonstrations

---

## Does Not Own

- ArtistOps production runtime implementation
- ArtistOps operational workflows
- ArtistOps private product logic
- protected ArtistOps IP
- application-specific orchestration
- customer/artist-specific operational behavior
- monetizable operational intelligence
- protected AI workflow orchestration

---

## Dependency Rule

ArtistOps must not depend on:
- Engineering Playbook runtime code
- Playbook packages
- Playbook build outputs
- Playbook operational behavior

The repositories are intentionally separate.

The Engineering Playbook may influence ArtistOps through:
- learning
- architectural clarification
- generalized pattern exploration
- interview-oriented decomposition

but must not become a runtime dependency.

---

## Pattern Extraction Workflow

When ArtistOps reveals the need for a reusable or interview-relevant pattern, use the following workflow when sensible:

```text
ArtistOps implementation need emerges
    ->
Identify reusable/interview-relevant pattern
    ->
Explore in dotnetfiddle if useful
    ->
Document or implement generalized pattern in Engineering Playbook
    ->
Apply concrete implementation inside ArtistOps
```

This preserves:

- clean repository boundaries
- educational clarity
- practical implementation focus
- interview relevance
- separation between generalized patterns and product implementation

---

# Planned / Future Repositories

Future repositories should not be predicted aggressively.

Planned repositories are documented only when they create governance guardrails now.

Future repositories may be created when justified by:

- IP protection
- security isolation
- deployment independence
- ownership clarity
- operational scale
- private commercial product boundaries
- protected orchestration systems
- protected AI operational intelligence

---

# Future Private ArtistOps Capability Repository

## Status

Planned / Governance Placeholder

---

## Purpose

Protect commercially valuable ArtistOps capabilities if and when they emerge.

This repository should not be created speculatively.

It becomes necessary when a capability is no longer merely:
- a public engineering demonstration
- a reusable architectural pattern
- a generalized operational workflow

and instead becomes:

- protected commercial product IP
- proprietary operational intelligence
- monetizable workflow orchestration
- protected AI operational capability

---

## Potential Ownership

A future private repository may own:

- proprietary workflow orchestration
- monetizable artist operations logic
- protected AI/RAG/agentic workflows
- private release optimization logic
- commercial artist-management capabilities
- protected APIs or libraries
- protected operational evaluation systems
- protected recommendation engines
- monetizable operational intelligence
- protected automation pipelines

---

## Creation Trigger

Creation is required when public implementation would expose:

- sellable business logic
- proprietary operational intelligence
- protected automation workflows
- monetizable AI orchestration
- reusable commercial libraries
- commercially valuable evaluation systems
- protected orchestration semantics

---

## Governance Rule

The moment a capability crosses into protected product IP:

- public implementation must stop
- Architecture must define the private boundary
- security expectations must be established
- API consumption rules must be established
- public demo behavior must be reviewed for exposure risk
- operational semantics exposure must be evaluated

Protected capability extraction should occur intentionally rather than reactively.

---

# Future Achievement / Reflection Repository Boundary

## Status

Future Extraction Consideration

---

## Purpose

Operational workflow management and achievement/reflection systems should remain architecturally separable concerns.

Future concepts such as:
- Green Room
- milestone reflection
- achievement systems
- collectible operational history
- retrospective artist experiences
- emotionally reflective workflow experiences

should remain distinct from:
- operational evaluation
- release risk visibility
- workflow execution
- escalation systems
- operational urgency management

This separation preserves:
- emotional UX clarity
- operational cognition clarity
- modular extraction readiness
- future protected capability flexibility

This does NOT require a future repository immediately.

It establishes a future architectural seam intentionally.

---

# Repository Boundary Principles

---

## Lean First

ProofWorks should avoid repository proliferation during early development.

Repository splits should be earned through:
- real operational pressure
- security boundaries
- protected capability evolution
- deployment needs
- ownership clarity

not guessed upfront.

---

## Modular Before Distributed

The ArtistOps application should first prove:
- internal modular boundaries
- deterministic operational ownership
- compositional dashboard behavior
- explainable operational evaluation

before extracting:
- repositories
- services
- distributed infrastructure

Extraction should follow demonstrated seams.

---

## Pragmatic Dogmatism

ProofWorks favors practical delivery, but not at the cost of separation of concerns.

Pragmatism may simplify structure.

Pragmatism may NOT:
- merge responsibilities
- blur operational ownership
- move business logic into frontend systems
- hide orchestration inside dashboard behavior
- erode deterministic operational boundaries

Temporary simplification is acceptable when:

- ownership remains clear
- SRP is preserved
- code can be moved later without surgery
- business logic remains backend-owned
- modules do not become entangled
- operational cognition ownership remains explicit

Temporary simplification is NOT acceptable when:

- UI starts owning business rules
- persistence concerns leak everywhere
- modules manipulate each other’s internals
- shared code becomes a dumping ground
- release/task/blocker/health/timeline/dashboard responsibilities blur together
- dashboard systems begin evaluating operational truth
- frontend systems infer unsupported operational semantics

---

# Dependency Direction

Within ArtistOps, dependency direction should preserve clear responsibility boundaries.

Preferred conceptual direction:

```text
Frontend
    ->
Backend API
    ->
Operational Modules
    ->
Domain Evaluation / Workflow Behavior
    ->
Shared Infrastructure / Shared Kernel
```

This is conceptual guidance, not a demand for excessive folder ceremony.

The important rule is:

```text
Dependencies should not invert responsibility ownership.
```

Examples:

- frontend should not own backend rules
- dashboard should not own release lifecycle
- shared code should not own domain behavior
- infrastructure should not dictate domain rules
- frontend should not derive escalation semantics
- dashboard should not evaluate readiness
- Health should not become hidden orchestration infrastructure

---

# Shared Code Rule

Shared code should be treated carefully.

Shared areas may contain:

- common primitives
- stable utilities
- cross-cutting infrastructure helpers
- validation infrastructure
- error handling patterns
- observability helpers

Shared areas must not become:

- a dumping ground
- a second hidden monolith
- a place where unclear ownership goes to hide
- a workaround for poor module boundaries
- hidden orchestration infrastructure
- operational evaluation sludge

When ownership is unclear:
- pause
- clarify the module boundary
- identify the true operational owner

before placing code into shared areas.

---

# Documentation Ownership

Product, Architecture, and Engineering documentation for ArtistOps belongs in:

```text
proofworks-artistops/docs
```

This is intentional because the documentation governs that application directly.

The Engineering Playbook may include:
- generalized explanations
- reusable demonstrations
- interview-oriented examples
- generalized architectural patterns

inspired by ArtistOps work.

However:
- ArtistOps governance
- operational decomposition
- implementation standards
- operational semantics

remain inside the ArtistOps repository.

---

# Extraction Strategy

Extraction should be considered when:

- a module has stable boundaries
- ownership is clear
- coupling is low
- deployment independence becomes useful
- IP protection requires separation
- security boundaries require separation
- operational scale justifies separation
- protected orchestration emerges
- monetizable operational intelligence emerges

Extraction should NOT occur because:

- microservices sound impressive
- repo count appears more mature
- future needs are being guessed
- a fashionable pattern appears attractive
- infrastructure aesthetics are being optimized prematurely

The current architecture posture is:

```text
decomposable modular monolith first
repository extraction later if justified
```

---

# Review Triggers

Architecture review is required when:

- a new repository is proposed
- a module is proposed for extraction
- public/private boundaries are unclear
- protected IP may be entering a public repo
- shared code begins accumulating domain behavior
- frontend logic begins carrying business rules
- dependencies begin crossing ownership boundaries
- dashboard systems begin owning operational meaning
- frontend systems begin evaluating operational truth
- Health evaluation becomes opaque or non-deterministic
- protected orchestration capability begins emerging

---

# Final Governance Position

The current repository model is intentionally lean:

```text
proofworks-artistops
proofworks-engineering-playbook
```

This supports:

- fast implementation
- clean documentation ownership
- modular monolith evolution
- practical AI-assisted workflows
- public proof-of-capability development
- deterministic operational ownership
- compositional operational architecture
- future protected IP extraction
- explainable operational cognition

The goal is not to predict every future repository.

The goal is to build clean boundaries now so future extraction is possible when the system proves where those boundaries belong.