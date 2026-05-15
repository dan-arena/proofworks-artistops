---
id: TASK-001A-004
title: Implement Create Release Application Behavior
type: Task

epic: EPIC-001
feature: FEATURE-001
story: STORY-001A

repository: proofworks-artistops-api
area: API

status: ReadyForImplementation

priority: High
size: Medium

codexReady: true
aiSafe: true
executionBoundary: CommitSized

parentStory: STORY-001A

dependencies:
  - TASK-001A-001
  - TASK-001A-002
  - TASK-001A-003

tags:
  - ArtistOps
  - ReleaseManagement
  - API
  - ApplicationBehavior
  - ReleaseCreation
---

# TASK-001A-004
# Implement Create Release Application Behavior

---

# Parent Story

```text
STORY-001A
API Story: Add Release Creation Capability
```

---

# Repository Ownership

```text
proofworks-artistops-api
```

---

# Task Purpose

Implement the backend-owned application behavior responsible for creating a Release.

This Task establishes the orchestration layer connecting:

- validated request input
- domain initialization
- persistence invocation
- create-release response generation

This Task intentionally focuses only on backend create-release behavior.

This Task intentionally avoids:

- API endpoint implementation
- lifecycle transitions
- cancellation workflows
- list/detail behavior
- frontend behavior
- dashboard behavior

---

# Source Governance References

Architecture Story boundary:

```text
/docs/architecture/milestones/v1.0.0-artist-release-operations-mvp/epics/EPIC-001-release-management/story-decomposition.md
```

Engineering Task standard:

```text
/docs/engineering/task-document-standard.md
```

Dependent Tasks:

```text
TASK-001A-001-domain-model.md
TASK-001A-002-api-contract.md
TASK-001A-003-validation.md
```

---

# Scope

## In Scope

- create-release application behavior
- backend release initialization
- domain object creation
- persistence invocation
- response generation
- application-level tests

## Out Of Scope

- endpoint implementation
- request validation implementation
- lifecycle transitions
- cancellation workflows
- release list behavior
- release detail behavior
- frontend behavior

---

# Application Behavior Responsibilities

The application layer must:

- accept validated create-release input
- initialize Release domain object
- assign backend-owned operational values
- invoke persistence behavior
- return created-release response

The application layer must NOT:

- expose HTTP concerns
- implement lifecycle transitions
- implement cancellation behavior
- implement dashboard behavior
- infer frontend behavior

---

# Operational Rules

## Rule: Backend Owns Release Initialization

The application layer must ensure:

```text
Release.lifecycleState == Draft
```

during initialization.

The caller must not influence lifecycle initialization.

---

## Rule: Backend Owns Identifier Assignment

The application layer must ensure:

```text
Release.id
```

is backend-generated.

---

## Rule: Backend Owns Timestamp Assignment

The application layer must ensure:

```text
createdAt
updatedAt
```

are backend-assigned.

---

## Rule: Persistence Remains Behind Repository Boundary

Persistence behavior should remain abstracted behind repository/application boundaries according to repository conventions.

The application layer should not tightly couple itself to:
- storage engine specifics
- database technology
- infrastructure concerns

---

# Pseudocode Behavior

## Create Release Flow

```text
function createRelease(request):

    validate request

    release = initialize Release

    release.id = generateUniqueIdentifier()

    release.lifecycleState = Draft

    release.createdAt = currentTimestamp()

    release.updatedAt = release.createdAt

    persist release

    response = map release to CreateReleaseResponse

    return response
```

---

# File / Code Area Guidance

Likely repository areas affected:

```text
/Application
/Application/Releases
/Domain
/Persistence
/Tests
```

Potential implementation artifacts:

```text
CreateReleaseHandler
CreateReleaseService
ReleaseRepository abstraction
application behavior tests
```

Exact implementation structure should follow repository conventions.

---

# Required Tests

## Application Behavior Tests

### Test: Valid Request Creates Release

Verify:

- Release initializes successfully
- Release receives backend-generated identifier
- lifecycleState initializes to Draft
- timestamps initialize correctly
- persistence behavior is invoked
- response is returned

---

### Test: Persisted Release Matches Response

Verify:

- persisted Release values match CreateReleaseResponse values

---

### Test: LifecycleState Initializes To Draft

Verify:

```text
Release.lifecycleState == Draft
```

during creation behavior.

---

### Test: Caller Cannot Override Lifecycle State

Verify callers cannot influence:

```text
lifecycleState
```

during create-release behavior.

---

### Test: Backend Assigns Identifier

Verify:

```text
Release.id
```

is backend-generated.

---

# Acceptance Checks

This Task is complete when:

- create-release application behavior exists
- validated input can create a Release
- backend assigns Release identifier
- backend initializes lifecycleState to Draft
- backend assigns timestamps
- persistence invocation exists
- CreateReleaseResponse is returned
- application behavior tests pass
- no endpoint behavior exists
- no lifecycle transition behavior exists
- no cancellation behavior exists

---

# Codex Execution Prompt

```text
Implement TASK-001A-004 in the proofworks-artistops-api repository.

Goal:
Implement backend application behavior for creating a Release in STORY-001A.

Follow existing repository conventions for:
- application structure
- orchestration patterns
- repository boundaries
- testing
- implementation style

Implement only:
- create-release application behavior
- Release initialization orchestration
- persistence invocation
- CreateReleaseResponse generation
- application-level tests

Operational rules:
- backend generates Release identifiers
- backend initializes lifecycleState to Draft
- backend assigns timestamps
- validated requests create Releases
- persistence remains abstracted behind repository boundaries

Do NOT implement:
- API endpoint behavior
- lifecycle transitions
- cancellation workflows
- list/detail behavior
- frontend behavior
- dashboard behavior

Add tests validating:
- successful Release creation
- lifecycleState defaults to Draft
- identifiers are backend-generated
- timestamps initialize correctly
- persistence invocation occurs
- response matches persisted Release state

Keep implementation:
- small
- reviewable
- repository-local
- architecture-safe
- rollback-safe
```

---

# Implementation Risk Notes

## Risk: Endpoint Leakage

Implementation may drift into HTTP or endpoint concerns.

Mitigation:

Keep this Task application-layer only.

Endpoint behavior belongs to TASK-001A-005.

---

## Risk: Persistence Coupling

Application behavior may become tightly coupled to storage implementation.

Mitigation:

Preserve repository/application abstraction boundaries.

---

## Risk: Lifecycle Transition Leakage

Implementation may accidentally include lifecycle transition behavior.

Mitigation:

Only initialize Draft state.

Do not implement transitions.

---

## Risk: Hidden Feature Expansion

Implementation may drift into:
- list behavior
- detail behavior
- dashboard behavior

Mitigation:

Preserve strict STORY-001A boundaries.

---

# Strategic Importance

This Task establishes:

- backend orchestration patterns
- backend-owned operational initialization
- persistence interaction patterns
- deterministic create-release behavior

This Task intentionally acts as the operational backbone for later:
- API exposure
- lifecycle workflows
- release detail workflows
- future operational aggregation behavior