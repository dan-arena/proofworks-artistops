# Engineering Definition of Done

## Purpose

This document defines the minimum completion expectations for implementation work within the ProofWorks platform.

The purpose of the Definition of Done is to:

- reduce implementation drift
- preserve architectural integrity
- improve review consistency
- improve maintainability
- support AI-assisted development safely
- enforce operational quality standards
- ensure work is actually complete
- preserve deterministic operational ownership
- preserve frontend/backend boundary integrity
- preserve compositional dashboard architecture
- preserve explainable operational cognition

This document exists to provide:

```text
clear completion expectations
```

not:
- process theater
- bureaucratic overhead
- artificial ceremony

The Definition of Done should evolve as the platform evolves.

---

# Core Philosophy

Work is considered complete when:

- the implementation behaves correctly
- architectural boundaries remain intact
- the code is maintainable
- the implementation is reviewable
- meaningful testing exists
- operational intent is preserved
- known compromises are documented honestly
- operational ownership remains deterministic
- frontend systems remain presentation-oriented
- backend systems remain operational-truth owners

The goal is not perfection.

The goal is:
- sustainable engineering quality
- maintainable system evolution
- operational reliability
- explainable implementation
- trustworthy operational behavior

---

# Architectural Alignment Philosophy

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
- interaction ergonomics
- workflow guidance
- contextual operational emphasis
- operational navigation support

Completed work must preserve this distinction.

Frontend systems must NOT:
- derive operational truth
- calculate readiness
- infer escalation semantics
- duplicate backend evaluation logic
- invent unsupported operational meaning

This is a Definition of Done concern, not merely an architecture preference.

---

# Required Completion Conditions

Unless explicitly exempted, completed work should satisfy the following expectations.

---

# Functional Completion

The implementation must:
- satisfy Story acceptance criteria
- satisfy operational workflow expectations
- behave correctly under expected usage conditions
- handle meaningful failure conditions appropriately
- preserve deterministic operational behavior
- preserve explainable operational semantics

The implementation should not:
- rely on undefined behavior
- rely on accidental side effects
- rely on downstream systems compensating for incorrect behavior
- rely on frontend inference of operational truth
- introduce hidden orchestration behavior

---

# Architectural Boundary Compliance

Completed work must preserve established architectural principles.

Including:
- dumb UI / smart backend
- backend-owned business logic
- backend-owned operational evaluation
- SRP enforcement
- modular ownership boundaries
- repository-local implementation
- extraction-ready modularity
- compositional dashboard architecture
- deterministic operational ownership

Frontend code must not:
- own business rules
- own operational workflows
- own lifecycle logic
- own operational calculations
- derive escalation semantics
- calculate readiness
- duplicate Health-domain logic
- infer unsupported operational meaning

Backend code must not:
- leak responsibilities across domains
- become hidden orchestration sludge
- violate ownership boundaries casually
- hide operational semantics implicitly
- centralize unrelated operational ownership

Dashboard systems must remain:
- compositional
- aggregation-oriented
- visibility-focused

Dashboard systems must NOT become:
- workflow orchestration engines
- operational evaluation owners
- hidden business logic layers
- operational-truth authorities

---

# ApplicationDataService Compliance

Frontend implementation should preserve the:

```text
ApplicationDataService
```

pattern expectations.

ApplicationDataServices may:
- coordinate API interactions
- shape ViewModels
- translate request/response contracts
- coordinate loading/error interaction flow

ApplicationDataServices must NOT:
- own business logic
- derive operational truth
- calculate readiness
- derive escalation semantics
- duplicate backend operational evaluation
- become hidden orchestration engines

React components should not directly accumulate API orchestration complexity.

---

# Code Quality Expectations

Completed implementation should be:
- readable
- intentional
- understandable
- maintainable
- reviewable
- ownership-clear

The code should:
- use descriptive naming
- preserve clear operational ownership
- favor self-documenting structure
- avoid unnecessary cleverness
- preserve evaluation/presentation boundaries

The implementation should align with:
- coding-standards.md
- architecture governance documents
- repository boundary rules
- operational cognition ownership rules

---

# Operational Naming Expectations

Naming should preserve operational clarity.

Completed implementation should clearly distinguish:
- evaluation vs presentation
- projection vs mutation
- aggregation vs orchestration
- operational truth vs UI visibility

Examples of preferred naming:

```text
ReleaseHealthEvaluationService
DashboardSummaryProjection
OperationalStatusViewModel
ReleaseReadinessEvaluation
```

Avoid vague ownership-obscuring naming such as:

```text
WorkflowHelper
DashboardEngine
StatusManager
DataProcessor
```

Naming should make ownership obvious.

---

# Testing Expectations

Completed work should include:
- meaningful automated testing where appropriate
- happy-path validation where meaningful
- failure-path validation where meaningful
- edge-case validation where meaningful
- deterministic operational evaluation validation where meaningful
- architectural-boundary protection where meaningful

Testing expectations should follow:
- testing-strategy.md

Tests should:
- improve confidence
- improve correctness
- isolate failure clearly
- preserve ownership boundaries
- reinforce deterministic operational behavior

Tests should not exist solely for:
- coverage theater
- arbitrary quotas
- meaningless framework validation
- fake operational confidence

---

# Frontend Testing Boundary Expectations

Frontend tests should validate:
- interaction behavior
- operational visualization
- ApplicationDataService orchestration
- UX behavior
- workflow guidance behavior
- operational cognition through presentation

Frontend tests must NOT:
- duplicate backend operational evaluation
- independently calculate readiness
- infer escalation semantics
- become hidden business-rule engines

Frontend testing should preserve:
- dumb UI philosophy
- deterministic backend ownership
- compositional dashboard behavior

---

# Backend Testing Boundary Expectations

Backend tests should validate:
- operational workflows
- business rules
- lifecycle validity
- readiness determination
- escalation semantics
- release confidence logic
- deterministic operational evaluation
- query/read-model correctness

Backend tests should preserve:
- operational truth ownership
- explainable operational behavior
- deterministic evaluation semantics

Important distinction:

```text
Waiting != At Risk
```

Dependency state and operational confidence are intentionally separate concerns and should remain separately testable.

---

# Regression Protection Rule

When a testing failure or production defect is fixed, the implementation should include automated regression protection where practical.

Preferred workflow:

```text
Failure identified
    ->
Failure reproduced
    ->
Regression test added
    ->
Fix implemented
    ->
Regression test passes
```

Regression tests should:
- validate the actual failure path
- protect the corrected behavior
- preserve operational learning
- preserve historical failure understanding

Regression tests should include comments explaining:
- the original failure scenario
- why the test exists
- why the behavior is important to protect

This protects against accidental removal during future cleanup or refactoring efforts.

Regression tests are institutional memory.

---

# TODO / FIXME / TECH DEBT Governance

Comments indicating incomplete or intentionally compromised work must use explicit categories.

---

# TODO Guidance

TODO is reserved for:

- known future enhancements
- intentional future capability notes
- planned evolution points
- architectural reminders for future work
- future extraction reminders
- future operational capability placeholders

TODO should NOT:
- hide incomplete implementation
- mask broken behavior
- replace backlog tracking irresponsibly

TODO indicates:

```text
not required for current completion
```

---

# FIXME Guidance

FIXME is reserved for:

- incomplete implementation
- incorrect behavior
- known defects
- behavior requiring correction before operational completion
- architectural violations requiring immediate resolution

FIXME indicates:

```text
must be resolved before Epic completion
```

FIXME markers may temporarily exist during active development.

Completed Epics should not contain unresolved FIXME markers unless explicitly approved and documented.

---

# TECH DEBT Guidance

TECH DEBT markers identify:

- intentional pragmatic compromises
- temporary simplifications
- accepted architectural shortcuts
- deferred cleanup work
- intentionally naive implementations
- temporarily simplified operational evaluation behavior

TECH DEBT should include:
- impact area
- rationale
- originating work item or governance reference

Preferred format:

```text
TECH DEBT - [Artifact Type] - [Identifier] - [Summary]
```

Examples:

```text
TECH DEBT - EPIC-001 - Intentional naive lifecycle state handling

TECH DEBT - FEATURE-004 - Temporary duplicated mapping logic pending mapper strategy

TECH DEBT - ARCHITECTURE - Simplified in-memory caching until distributed cache evaluation
```

The purpose is:
- traceability
- maintainability
- future cleanup clarity
- preservation of architectural intent
- preservation of operational reasoning

TECH DEBT comments should not become permanent camouflage for poor engineering discipline.

---

# Documentation Expectations

Documentation should be updated when implementation changes:

- architecture behavior
- operational workflows
- ownership boundaries
- integration expectations
- governance rules
- operational cognition ownership
- dashboard composition behavior
- evaluation/presentation separation
- important constraints
- non-obvious operational behavior

Documentation should NOT attempt to narrate implementation minutia.

Good documentation should:
- age slowly
- preserve architectural intent
- preserve operational clarity
- explain non-obvious behavior
- explain important tradeoffs
- explain ownership rationale

Code should remain the primary implementation detail source.

Documentation should focus on:
- intent
- boundaries
- rationale
- workflows
- constraints

---

# Reviewability Expectations

Completed work should be reviewable without archaeology.

Reviewers should quickly understand:
- what changed
- why it changed
- what operational behavior was added or modified
- which module owns the behavior
- whether boundaries were preserved
- whether operational cognition ownership remained correct
- whether dashboard composition rules remained intact
- whether frontend/backend boundaries remained intact

Oversized implementation blobs should be avoided.

---

# Dashboard Completion Expectations

Dashboard implementation is complete only when:
- it remains compositional
- operational meaning remains backend-derived
- no hidden workflow orchestration exists
- no frontend operational evaluation exists
- no duplicated Health-domain logic exists

Dashboard implementation is NOT complete if:
- readiness is calculated client-side
- escalation semantics emerge in frontend code
- dashboard code becomes hidden business logic
- aggregation logic becomes orchestration logic

Dashboard scope creep is a major architectural risk.

---

# Health Evaluation Completion Expectations

Health-domain implementation is complete only when:
- evaluation behavior remains deterministic
- operational reasoning remains explainable
- confidence evaluation remains understandable
- readiness behavior remains reviewable
- operational semantics remain explicit

Health implementation is NOT complete if:
- opaque scoring exists
- unsupported AI evaluation exists
- hidden weighting systems emerge
- emotionally manipulative scoring emerges
- operational reasoning becomes impossible to explain clearly

Operational trustworthiness is more important than artificial intelligence theater.

---

# AI-Assisted Development Expectations

AI-assisted implementation must follow the same standards as human-written implementation.

AI-generated code is not exempt from:
- architecture rules
- testing expectations
- naming standards
- reviewability expectations
- SRP expectations
- operational ownership boundaries
- dashboard composition rules
- deterministic operational evaluation requirements

AI-generated work must be reviewed for:
- correctness
- meaningfulness
- architectural alignment
- maintainability
- ownership clarity
- operational semantics correctness

Passing compilation is not considered sufficient quality validation.

---

# Build / Execution Expectations

Completed implementation should:
- build successfully
- execute without obvious instability
- avoid introducing known broken states
- preserve operational behavior expectations
- preserve deterministic operational semantics

Work should not be merged in knowingly broken states without explicit documented approval.

---

# Operational Integrity Expectations

Implementation should preserve:
- operational coherence
- workflow clarity
- module ownership
- predictable behavior
- deterministic operational evaluation
- explainable operational semantics
- frontend/backend ownership integrity

Short-term convenience should not silently create:
- architectural entanglement
- ownership confusion
- hidden coupling
- operational ambiguity
- frontend operational cognition
- hidden orchestration systems
- dashboard evaluation creep

---

# Protected IP Governance

Completed work must respect public/private capability boundaries.

Public repositories must not expose:
- protected workflow intelligence
- proprietary orchestration logic
- monetizable operational AI systems
- protected commercial ArtistOps IP
- protected operational evaluation systems
- monetizable orchestration semantics

If implementation begins crossing those boundaries:
- work must pause
- Architecture review is required
- private boundary decisions must be established before continuation

Protected capability extraction should occur intentionally rather than reactively.

---

# Architecture Review Trigger Conditions

Architecture review is required when implementation begins introducing:
- frontend operational evaluation
- dashboard orchestration ownership
- hidden shared operational engines
- duplicated operational semantics
- opaque Health evaluation
- speculative AI orchestration
- cross-domain operational ownership
- monetizable operational intelligence
- protected orchestration logic

Architecture boundaries should evolve intentionally, not accidentally.

---

# Merge Readiness Philosophy

Code is merge-ready when:

- the implementation is operationally correct
- meaningful testing exists
- architecture boundaries remain intact
- technical compromises are documented honestly
- the implementation is understandable
- future engineers can maintain it safely
- deterministic operational ownership remains preserved
- frontend/backend ownership remains correct
- dashboard composition remains intact

Merge readiness is not:
- perfection
- over-testing
- over-documentation
- process compliance theater

It is:
- responsible engineering completion

---

# Final Definition of Done Philosophy

The purpose of the Definition of Done is not to slow engineering down.

The purpose is to prevent:

- silent architectural decay
- hidden implementation drift
- meaningless testing
- undocumented compromise accumulation
- AI-generated chaos
- operational ambiguity
- frontend operational cognition creep
- dashboard orchestration creep
- opaque operational evaluation
- hidden ownership erosion

Good engineering should remain:
- understandable
- maintainable
- explainable
- modular
- evolvable
- operationally trustworthy

The system should become easier to evolve over time, not harder.