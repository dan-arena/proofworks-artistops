# Engineering Coding Standards

## Purpose

This document defines implementation standards for the ProofWorks platform.

The purpose of these standards is to improve:

- maintainability
- readability
- reviewability
- implementation consistency
- AI-assisted development safety
- architectural clarity
- interview credibility
- long-term scalability
- deterministic operational ownership
- frontend/backend boundary preservation
- compositional architecture safety

These standards intentionally favor:

- practical engineering
- explicit ownership
- clear naming
- modular responsibility
- maintainable workflows
- explainable operational behavior

over:

- unnecessary cleverness
- excessive abstraction
- stylistic bureaucracy
- theoretical perfectionism
- artificial architectural complexity

This document should evolve as implementation experience grows.

---

# Core Engineering Philosophy

ProofWorks favors:

- readable code
- explicit intent
- modular ownership
- self-documenting structure
- backend-owned operational logic
- frontend presentation simplicity
- maintainable decomposition
- deterministic operational evaluation
- compositional dashboard behavior
- pragmatic dogmatism

Pragmatism may simplify structure.

Pragmatism may NOT:
- violate separation of concerns
- blur operational ownership
- move operational evaluation into frontend systems
- hide orchestration inside dashboard behavior

---

# Architectural Alignment

Implementation must align with established architecture principles:

- decomposable modular monolith
- dumb UI / smart backend
- repository-local implementation
- operational domain ownership
- extraction-ready boundaries
- backend-owned operational truth
- compositional dashboard architecture
- deterministic operational evaluation

Implementation convenience must not override architectural ownership.

---

# Operational Cognition Philosophy

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
- contextual operational emphasis
- workflow navigation
- operational cognition through presentation

Frontend systems must NOT:
- derive operational truth
- calculate readiness
- infer escalation semantics
- duplicate backend evaluation logic
- invent unsupported operational meaning

This distinction is a core engineering governance rule.

---

# Naming Philosophy

## Prefer Clarity Over Brevity

Use names that clearly communicate intent.

Prefer:

```text
counterparty
releaseLifecycleState
releaseCancellationReason
taskCompletionStatus
loopIndex
releaseReadinessEvaluation
operationalConfidenceState
```

Avoid:

```text
cty
rls
rcr
tcs
i
rr
ocs
```

unless operating inside extremely small and obvious algorithmic contexts.

Modern tooling, autocomplete, and AI assistance reduce the cost of descriptive naming significantly.

Readability is more valuable than keystroke reduction.

---

# Operational Naming Guidance

Operational meaning should remain explicit in naming.

Prefer names that clarify:
- evaluation vs visualization
- projection vs mutation
- aggregation vs orchestration
- operational truth vs presentation state

Examples:

```text
ReleaseHealthEvaluationService
ReleaseSummaryProjection
OperationalStatusViewModel
DashboardSummaryQuery
ReadinessEvaluationResult
```

Avoid ambiguous names such as:

```text
ReleaseHelper
DashboardEngine
StatusManager
DataProcessor
WorkflowThing
```

Names should make ownership obvious.

---

# Abbreviation Guidance

Avoid unnecessary abbreviations.

Abbreviations are acceptable only when:
- industry standard
- universally recognizable
- operationally obvious

Examples:
- api
- dto
- url
- id

Avoid inventing local abbreviations.

---

# Language Convention Alignment

Follow established language/platform naming standards.

---

## C#

Follow Microsoft conventions.

Examples:
- PascalCase for public types/methods/properties
- camelCase for local variables/parameters
- interface prefix `I`
- async suffix `Async`

---

## JavaScript / React

Follow common JavaScript and React conventions.

Examples:
- PascalCase for React components
- camelCase for variables/functions
- descriptive hook/service naming
- explicit component naming

---

## TypeScript

Follow established TypeScript conventions.

Types and interfaces should remain explicit and descriptive.

---

# Backend Architecture Style

ProofWorks uses a hybrid modular-monolith architecture style.

Preferred structure:

```text
Operational Domain
    -> Commands
    -> Queries
    -> Handlers
    -> Contracts
    -> Validation
```

Architecture should remain:
- operation-oriented
- modular
- extraction-ready
- operationally explainable

Avoid:
- giant service layers
- generic abstraction dumping
- hidden workflow ownership
- dashboard-owned orchestration
- shared operational sludge

---

# Request / Response Contract Standards

API boundary contracts should use:

```text
<RequestName>Request
<RequestName>Response
```

Examples:

```text
CreateReleaseRequest
CreateReleaseResponse

GetReleaseDetailRequest
ReleaseDetailResponse
```

Contracts should remain:
- explicit
- operation-oriented
- ownership-clear

Avoid:
- generic payload naming
- ambiguous transport models
- frontend-derived operational semantics

---

# Command / Query Standards

Operational intent should be modeled explicitly.

Rules:

- state mutation -> Command
- state retrieval/projection -> Query

Examples:

```text
CreateReleaseCommand
UpdateReleaseMetadataCommand

GetReleaseDetailQuery
GetReleaseListQuery
GetDashboardSummaryQuery
```

Commands should not masquerade as Queries.

Queries should not mutate operational state.

---

# Handler Standards

Commands and Queries should use explicit handlers.

Examples:

```text
CreateReleaseCommandHandler
GetReleaseDetailQueryHandler
GetDashboardSummaryQueryHandler
```

Handler responsibilities:
- orchestrate operational behavior
- coordinate validation/workflow execution
- preserve operational boundaries
- preserve deterministic operational ownership

Handlers should remain:
- focused
- cohesive
- ownership-clear

Handlers should avoid:
- hidden orchestration sprawl
- cross-domain workflow ownership
- frontend-oriented operational logic

---

# Endpoint Standards

API design should remain operation-oriented.

Framework choice may vary by module.

Both are acceptable when justified:
- ASP.NET REST Controllers
- FastEndpoints

The important concern is:
- clear ownership
- explicit contracts
- maintainable operational boundaries
- deterministic operational behavior

Framework usage should not become inconsistent chaos inside a single operational module.

---

# Frontend Philosophy

The frontend should remain intentionally thin.

Frontend responsibilities:
- rendering
- interaction flow
- API consumption
- view model shaping
- user experience behavior
- operational cognition through presentation

Frontend must NOT own:
- business rules
- operational workflows
- lifecycle logic
- authorization decisions
- operational calculations
- readiness evaluation
- escalation derivation
- operational confidence logic

Operational truth belongs in backend systems.

---

# Dashboard Engineering Philosophy

Dashboard behavior should remain:

> compositional and visibility-oriented

Dashboard systems may:
- aggregate operational summaries
- compose operational visibility
- support rapid operational scanning
- support layered workflow navigation

Dashboard systems must NOT:
- own operational truth
- orchestrate workflows
- calculate readiness
- derive escalation semantics
- become hidden business logic engines

Dashboard code should remain:
- compositional
- query-oriented
- operationally lightweight

Dashboard scope creep is a major architectural risk.

---

# ApplicationDataService Pattern

Frontend API interaction should favor the ApplicationDataService pattern.

Purpose:
- isolate API contract translation
- isolate view model shaping
- support mocked/demo implementations
- allow frontend progress before backend completion
- reduce API leakage into components
- preserve dumb UI boundaries

Preferred flow:

```text
React Component
    -> IApplicationDataService
        -> API Contracts
            -> Backend API
```

ApplicationDataServices should:
- understand API contracts
- translate ViewModels
- orchestrate frontend data interactions
- coordinate interaction flow

ApplicationDataServices should NOT:
- own business rules
- evaluate operational truth
- calculate release health
- derive escalation semantics
- infer unsupported operational meaning
- duplicate backend operational logic

React components should not directly own API orchestration complexity.

---

# ViewModel Standards

Frontend models should be presentation-oriented.

Examples:

```text
ReleaseDetailViewModel
ReleaseListItemViewModel
ReleaseSummaryViewModel
OperationalStatusViewModel
DashboardSummaryViewModel
```

ViewModels should:
- support rendering needs
- remain presentation-focused
- avoid operational ownership
- avoid backend semantic duplication

ViewModels should NOT:
- become domain models
- calculate operational truth
- infer unsupported operational meaning

---

# Method Design Standards

Methods should either:

1. perform a single atomic operation

OR

2. clearly describe a workflow/business operation composed primarily of smaller atomic methods

Methods should read like understandable operational flows.

Workflow methods should:
- coordinate intent clearly
- preserve operational ownership
- avoid hidden orchestration sprawl

---

# Method Length Guidance

Methods exceeding approximately 20 lines should trigger evaluation.

Evaluation questions:
- does the method have multiple responsibilities?
- can intent become clearer through decomposition?
- are hidden workflows accumulating?
- would extraction improve readability?
- is orchestration becoming unclear?
- is evaluation/presentation logic mixing?

This is a review guideline, not a hard prohibition.

The goal is clarity, not arbitrary line-count policing.

---

# Class Size Guidance

Classes exceeding approximately 100 lines should trigger evaluation.

Evaluation questions:
- is the class maintaining SRP?
- is workflow ownership becoming blurred?
- should behavior be extracted?
- are unrelated concerns accumulating?
- is orchestration becoming centralized improperly?
- is dashboard logic absorbing domain logic?

This is guidance, not a rigid limit.

Length thresholds are smoke alarms, not guillotines.

---

# SRP Enforcement

Single Responsibility Principle is a non-negotiable architectural expectation.

Temporary implementation convenience must not:
- merge unrelated responsibilities
- blur ownership boundaries
- entangle operational concerns
- move operational cognition into presentation layers

Pragmatism may simplify structure.

Pragmatism may not violate SRP.

---

# Comment Philosophy

Code should strive to be self-documenting through:
- descriptive naming
- small focused methods
- explicit workflows
- clear responsibility ownership

---

# Method / Class Descriptions

Public classes, handlers, services, and complex workflows should include concise descriptions explaining:
- what the component does
- why it exists
- important operational context when necessary
- important ownership boundaries when necessary

The goal is rapid comprehension.

---

# Code Comment Guidance

Comments should generally explain:
- why something exists
- why a non-obvious approach was chosen
- operational/business context
- external constraints
- intentional deviations from normal patterns
- architectural protection decisions
- operational ownership rationale

Comments should NOT:
- narrate obvious code behavior
- compensate for poor naming
- explain trivial implementation details
- replace proper decomposition

---

# TODO / FIXME / TECH DEBT Standards

## TODO

Use TODO for:
- known future enhancements
- intentionally deferred capabilities
- future operational expansion points
- planned architectural evolution

TODO should NOT indicate:
- broken implementation
- incomplete Epic-critical behavior

---

## FIXME

Use FIXME only for:
- known incorrect behavior
- implementation that must be corrected before completion
- operationally unsafe temporary behavior

FIXME indicates:
- unresolved correctness risk

FIXME should not survive milestone completion.

---

## TECH DEBT

Use TECH DEBT for:
- intentional pragmatic compromise
- known simplification
- intentionally naive implementation
- future architectural cleanup

TECH DEBT comments should include:
- originating document/section when possible
- operational rationale
- intended future direction

Example:

```text
TECH DEBT - EPIC-004 Release Health Evaluation
Intentional deterministic implementation before future advanced evaluation strategy.
```

TECH DEBT should preserve:
- future comprehension
- architectural intent
- review clarity

---

# Folder / Module Organization

Folders should reflect:
- operational ownership
- feature boundaries
- modular cohesion
- deterministic responsibility

Avoid:
- giant utility folders
- unclear ownership
- generic dumping grounds
- hidden orchestration layers

Shared areas should remain:
- intentional
- minimal
- infrastructure-oriented

---

# Extension Method Guidance

Extension methods are acceptable when they:
- improve readability
- encapsulate stable reusable behavior
- reduce duplication cleanly

Avoid extension methods that:
- hide business logic
- create surprising behavior
- obscure ownership boundaries
- conceal operational semantics

---

# Utility / Helper Guidance

Avoid generic helper dumping grounds.

If ownership is unclear:
- pause
- clarify the boundary
- determine the correct module

“Helpers” should not become architecture landfill.

Avoid vague structures such as:
- WorkflowHelper
- DashboardHelper
- StatusManager
- UtilityProcessor

Prefer:
- explicit ownership
- operation-oriented naming
- deterministic responsibility

---

# Testing Naming Standards

Test names should clearly describe behavior.

Prefer:

```text
Should_Create_Release_When_Request_Is_Valid
Should_Reject_Invalid_Lifecycle_Transition
Should_Return_Overdue_Status_When_Due_Date_Has_Passed
```

Avoid:
- vague naming
- implementation-detail naming
- cryptic abbreviations

Test intent should be immediately understandable.

---

# Regression Test Standards

When a production or testing failure occurs:

- the fix must include regression coverage
- the regression test should explicitly preserve the failure path
- the regression reason should remain understandable

Regression tests should include comments explaining:
- the historical failure
- why the test exists
- why removal would be dangerous

This prevents:
- accidental regression-test pruning
- loss of operational context
- repeated historical failures

Regression tests are institutional memory.

---

# Markdown / Documentation Naming

Documentation names should remain:
- explicit
- predictable
- searchable

Prefer:

```text
coding-standards.md
testing-strategy.md
repository-inventory.md
```

Avoid:
- vague names
- novelty names
- abbreviations without strong justification

---

# Documentation Philosophy

Documentation should preserve:
- intent
- ownership
- architecture decisions
- operational semantics
- important constraints
- non-obvious reasoning

Documentation should NOT:
- duplicate obvious implementation details
- become implementation archaeology
- attempt to narrate every code path

Documentation should remain:
- strategically valuable
- operationally useful
- maintainable

---

# AI-Assisted Development Standards

Implementation should remain AI-friendly.

Preferred characteristics:
- explicit ownership
- small focused methods
- clear naming
- isolated responsibilities
- reviewable workflows
- modular cohesion
- deterministic operational semantics

Avoid:
- giant ambiguous methods
- unclear ownership
- hidden coupling
- excessive indirection
- orchestration sludge
- frontend operational evaluation logic

AI should accelerate implementation, not increase architectural chaos.

---

# Reviewability Standard

Code should optimize for reviewability.

Reviewers should quickly understand:
- what changed
- why it changed
- which responsibility owns it
- whether architectural boundaries were preserved
- whether operational cognition ownership remained correct

Implementation clarity is more valuable than cleverness.

---

# Final Engineering Philosophy

The goal of these standards is not stylistic perfection.

The goal is:
- maintainable systems
- understandable code
- scalable implementation
- explainable engineering
- architectural consistency
- safe AI-assisted development
- deterministic operational ownership
- compositional operational architecture
- strong interview credibility

Good engineering should feel:
- clear
- intentional
- cohesive
- understandable
- evolvable

Future engineers should understand the codebase without archaeology.