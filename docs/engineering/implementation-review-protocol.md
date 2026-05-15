# Implementation Review Protocol
# ProofWorks ArtistOps

---

# Purpose

This document defines the lightweight implementation review expectations for ProofWorks ArtistOps.

The protocol exists to support:

- governed AI-assisted implementation
- deterministic implementation review
- bounded execution validation
- architecture preservation
- rollback safety
- decomposition compliance
- operational correctness
- maintainable implementation quality

This protocol is intentionally designed for:

- small-team operation
- AI-era software delivery
- repository-local execution
- practical engineering workflows
- explainable implementation governance

This protocol is NOT intended to create:

- enterprise approval theater
- heavyweight process bureaucracy
- excessive Agile ritualization
- formal change board workflows
- implementation micromanagement

Implementation review exists to preserve implementation integrity while enabling fast, practical delivery.

---

# Governance References

This protocol should be interpreted alongside:

```text
/docs/engineering/coding-standards.md
/docs/engineering/testing-strategy.md
/docs/engineering/definition-of-done.md
/docs/engineering/task-document-standard.md
```

Implementation review must also preserve:

- Architecture governance
- UX governance
- backend/frontend ownership boundaries
- repository-local Story boundaries
- backend-owned operational cognition
- dumb UI / smart backend philosophy

---

# Review Philosophy

Implementation review exists to answer a small set of critical questions:

```text
Did the implementation:
- stay within scope?
- preserve architecture?
- preserve operational semantics?
- remain understandable?
- remain reviewable?
- remain rollback-safe?
- remain aligned with the Task contract?
```

Implementation review is NOT intended to optimize for:

- maximal abstraction
- speculative extensibility
- theoretical elegance
- framework cleverness
- resume-driven complexity

The preferred implementation is typically:

```text
simple
bounded
reviewable
deterministic
maintainable
```

especially during early implementation maturity.

---

# AI Execution Governance Philosophy

AI-generated implementation is treated as:

```text
governed execution assistance
```

NOT:

```text
autonomous engineering authority
```

AI systems may assist with:
- implementation
- tests
- scaffolding
- repetitive patterns
- repository-local development

AI systems must NOT:
- redefine architecture
- expand scope
- invent operational semantics
- bypass decomposition boundaries
- accumulate hidden orchestration
- create speculative abstractions

Human review remains mandatory.

---

# Review Goals

Reviewers are responsible for validating:

- Task scope adherence
- repository locality
- architecture compliance
- decomposition compliance
- coding standards compliance
- testing expectations
- operational semantics preservation
- backend/frontend ownership preservation
- maintainability
- implementation reviewability
- rollback safety

Reviewers should specifically verify:

- no unauthorized feature expansion
- no hidden orchestration accumulation
- no speculative infrastructure
- no accidental lifecycle behavior leakage
- no cancellation semantics leakage
- no frontend operational cognition leakage

---

# Scope Adherence Expectations

Implementations must remain bounded to the current Task.

Implementation should NOT:
- implement future Stories
- implement future Features
- implement speculative infrastructure
- introduce unrelated abstractions
- create hidden dependency chains

If implementation pressure suggests broader architectural work is needed:

```text
STOP
RETURN TO GOVERNANCE
```

rather than silently expanding implementation scope.

---

# Repository Locality Expectations

Implementations should remain:

```text
repository-local
```

whenever possible.

Tasks should avoid:
- cross-repository orchestration
- hidden coupling
- shared-state assumptions
- premature distributed behavior

Repository-local implementation preserves:
- reviewability
- rollback simplicity
- deterministic testing
- bounded AI execution

---

# Architecture Compliance Expectations

Implementation review must preserve:

- backend-owned operational truth
- backend lifecycle ownership
- cancellation-as-business-operation semantics
- bounded Story ownership
- modular monolith boundaries
- deterministic orchestration flow

Reviewers should reject implementations that:
- move operational semantics into the frontend
- introduce hidden lifecycle transitions
- bypass backend validation authority
- leak orchestration into presentation layers

---

# Decomposition Compliance Expectations

Task documents are considered the executable implementation boundary.

Reviewers should validate:

- implementation remains within Task scope
- implementation satisfies acceptance checks
- implementation respects non-goals
- implementation does not absorb adjacent Tasks
- implementation preserves Story sequencing

Task boundaries exist to preserve:
- AI-safe execution
- rollback simplicity
- implementation explainability
- deterministic reviewability

---

# Coding Standards Expectations

Implementation review should verify compliance with:

```text
/docs/engineering/coding-standards.md
```

Reviewers should prioritize:

- readability
- simplicity
- naming clarity
- operational clarity
- implementation explainability
- maintainability

Reviewers should avoid incentivizing:
- abstraction inflation
- framework cleverness
- premature optimization
- speculative extensibility

---

# Testing Expectations

Implementation review should verify compliance with:

```text
/docs/engineering/testing-strategy.md
```

Reviewers should validate:
- required tests exist
- tests remain deterministic
- tests verify operational behavior
- tests preserve repository locality
- tests remain understandable
- tests align with Task acceptance expectations

Reviewers should reject:
- fake coverage inflation
- brittle orchestration-heavy tests
- hidden integration assumptions
- tests that validate future unimplemented behavior

---

# Completion Expectations

A Task is generally considered complete when:

- acceptance checks are satisfied
- required tests pass
- repository builds successfully
- implementation remains within Task scope
- implementation remains reviewable
- implementation remains understandable
- required documentation updates are completed
- implementation preserves architecture boundaries
- implementation preserves operational ownership boundaries

Tasks should not be considered complete if:
- hidden TODO/FIXME accumulation exists beyond accepted standards
- implementation expands beyond Task scope
- implementation introduces speculative abstractions
- implementation violates repository locality
- implementation reduces reviewability

---

# Rollback Philosophy

Rollback is considered:

```text
governance preservation
```

NOT:

```text
implementation failure shame
```

Rollback is acceptable and expected when implementation violates:

- architecture boundaries
- decomposition boundaries
- repository locality
- lifecycle semantics
- operational ownership
- reviewability expectations
- implementation simplicity expectations

especially during AI-assisted implementation.

Rollback is a normal governance tool.

The earlier rollback occurs:
- the cheaper correction becomes
- the simpler review becomes
- the lower architectural risk becomes

---

# Sequential Implementation Guidance

Current approved implementation strategy:

```text
Single-Task Sequential Implementation
```

This currently exists to:

- validate decomposition quality
- validate Codex execution quality
- validate repository conventions
- preserve rollback simplicity
- preserve reviewability
- reduce ambiguity propagation
- stabilize implementation governance

Parallel AI execution remains intentionally deferred until:
- decomposition maturity increases
- implementation quality stabilizes
- repository conventions stabilize
- review workflows stabilize

---

# Lightweight Review Expectations

Implementation review should remain:

```text
practical
fast
bounded
deterministic
implementation-oriented
```

Review should NOT become:
- approval theater
- committee-driven
- excessively ceremonial
- artificially bureaucratic

The goal is:

```text
high-confidence implementation validation
```

not:
```text
enterprise workflow simulation
```

---

# Recommended Review Flow

Preferred implementation flow:

```text
Task Document
  ->
Codex / Human Implementation
  ->
Human Review
  ->
Acceptance Validation
  ->
Commit
  ->
Next Task
```

Preferred rollback flow:

```text
Implementation Drift Detected
  ->
Stop
  ->
Rollback
  ->
Refine Task / Governance
  ->
Re-implement
```

---

# AI Review Expectations

When reviewing AI-generated implementation, reviewers should specifically check for:

- hidden scope expansion
- abstraction inflation
- speculative extensibility
- repository convention drift
- architecture drift
- orchestration accumulation
- fake generic patterns
- unnecessary indirection
- implementation explainability loss

The implementation should remain understandable by humans without requiring:
- AI reconstruction
- hidden inference
- undocumented orchestration knowledge

---

# Definition Of Done Relationship

Implementation review does NOT replace:

```text
/docs/engineering/definition-of-done.md
```

Instead:

- Definition of Done defines completion expectations
- Implementation Review validates practical compliance

The two documents are intentionally complementary.

---

# Strategic Purpose

This protocol exists to ensure ProofWorks demonstrates:

- governed AI-assisted engineering
- deterministic implementation review
- bounded execution maturity
- explainable engineering governance
- maintainable software delivery
- practical architecture preservation
- realistic AI-era engineering workflows

through lightweight operational discipline rather than enterprise process theater.