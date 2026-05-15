# Implementation Execution Rules

## Purpose

This document defines the operational execution rules for AI-assisted implementation execution within ProofWorks.

These rules exist to preserve:

- bounded implementation scope
- architecture integrity
- decomposition integrity
- rollback safety
- reviewability
- deterministic implementation flow

These rules apply to:

- Codex-assisted implementation
- AI-assisted implementation execution
- implementation execution threads
- executable Engineering Task documents

---

## Core Execution Philosophy

AI implementation is:

```text
governed execution assistance
```

NOT:

```text
autonomous engineering authority
```

AI execution must remain:

- bounded
- reviewable
- architecture-compliant
- decomposition-compliant
- rollback-safe
- repository-local

Human review remains mandatory.

---

## Approved Execution Model

The currently approved implementation strategy is:

```text
Single-Task Sequential Implementation
```

Implementation flow:

```text
Task Selection
  ->
Codex Implementation
  ->
Human Review
  ->
Governance Validation
  ->
Acceptance Validation
  ->
Commit
  ->
Next Task
```

Parallel AI implementation is intentionally deferred until implementation governance maturity increases.

---

## Implementation Thread Rules

Implementation execution threads MUST:

- remain repository-local
- remain Story-local
- implement only the currently assigned Task
- stop after Task completion
- await review before proceeding
- preserve decomposition boundaries
- preserve architecture boundaries
- preserve UX governance boundaries

Implementation execution threads MUST NOT:

- expand scope
- implement future Tasks
- introduce speculative abstractions
- redesign architecture
- introduce orchestration systems
- infer undefined behavior
- introduce speculative infrastructure
- modify unrelated files without justification

---

## Task Boundary Enforcement

Executable Task documents are considered:

```text
the implementation contract
```

Implementation must remain inside the Task boundary.

If ambiguity is encountered:

```text
STOP
```

and escalate through the Coordinator/governance flow rather than improvising behavior.

---

## Review Expectations

Every implementation Task requires human review before continuation.

Review validates:

- architecture compliance
- decomposition compliance
- repository locality
- coding standards compliance
- testing expectations
- implementation simplicity
- operational semantics preservation
- absence of scope creep
- absence of hidden orchestration
- rollback safety

---

## Rollback Philosophy

Rollback is treated as:

```text
governance preservation
```

NOT:

```text
implementation failure shame
```

Rollback is expected and acceptable when implementation violates:

- architecture boundaries
- decomposition boundaries
- repository locality
- lifecycle semantics
- operational ownership
- reviewability expectations
- implementation simplicity expectations

especially during AI-assisted implementation.

---

## Repository Locality Rule

Implementation execution MUST preserve:

- repository-local Stories
- repository-local Tasks
- repository-local implementation

Cross-repository implementation is NOT permitted during a Task execution loop unless explicitly authorized by governance review.

---

## Backend Ownership Rule

Implementation MUST preserve:

```text
backend-owned operational cognition
```

Frontend implementations must NOT:

- infer lifecycle transitions
- calculate operational readiness
- calculate escalation state
- enforce lifecycle validity
- own operational truth

Frontend remains presentation-oriented.

---

## Completion Rule

A Task is considered complete only when:

- acceptance checks pass
- required tests pass
- repository builds successfully
- implementation remains within scope
- implementation remains reviewable
- governance validation passes
- human review approves continuation

Completion does NOT authorize automatic continuation into the next Task.

---

## Escalation Rule

If implementation encounters:

- architecture ambiguity
- missing operational semantics
- decomposition conflicts
- repository ownership ambiguity
- governance conflicts
- unclear UX expectations

implementation MUST stop and escalate through the governance chain.

AI execution must never silently invent governance behavior.

---

## Current Approved Initial Execution Target

Approved initial implementation target:

```text
TASK-001A-001-domain-model.md
```

This Task was intentionally selected because it is:

- architecture-safe
- highly reviewable
- low orchestration risk
- rollback-safe
- operationally isolated
- implementation-simple

This Task is intended to validate:

- decomposition quality
- implementation governance quality
- Codex execution quality
- review workflow quality
- repository convention stability