---
id: TASK-001A-005
title: Expose Create Release API Operation
type: Task

epic: EPIC-001
feature: FEATURE-001
story: STORY-001A

repository: proofworks-artistops-api
area: API

status: ReadyForImplementation

priority: High
size: Small

codexReady: true
aiSafe: true
executionBoundary: CommitSized

parentStory: STORY-001A

dependencies:
  - TASK-001A-001
  - TASK-001A-002
  - TASK-001A-003
  - TASK-001A-004

tags:
  - ArtistOps
  - ReleaseManagement
  - API
  - Endpoint
  - ReleaseCreation
---

# TASK-001A-005
# Expose Create Release API Operation

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

Expose backend Release creation behavior through the API boundary.

This Task establishes the externally callable API operation for STORY-001A.

This Task intentionally focuses only on:

- create-release API operation
- request binding
- application behavior invocation
- API response behavior
- API integration behavior

This Task intentionally avoids:

- lifecycle transitions
- cancellation workflows
- release list behavior
- release detail behavior
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
TASK-001A-004-application-behavior.md
```

---

# Scope

## In Scope

- create-release API operation
- request binding
- validation invocation
- application behavior invocation
- response generation
- API integration tests

## Out Of Scope

- lifecycle transitions
- cancellation workflows
- release list behavior
- release detail behavior
- frontend behavior
- dashboard behavior
- authentication/authorization implementation

---

# API Operation Definition

## Operation

```text
Create Release
```

---

## Suggested Route Shape

```text
POST /releases
```

Exact routing conventions should follow repository standards.

---

## Request Contract

The operation accepts:

```text
CreateReleaseRequest
```

Allowed request fields:

```text
title
releaseType
targetReleaseDate
operationalNotes
```

Forbidden request fields:

```text
id
lifecycleState
createdAt
updatedAt
```

---

## Response Contract

The operation returns:

```text
CreateReleaseResponse
```

The response must include:

```text
id
title
releaseType
targetReleaseDate
lifecycleState
operationalNotes
createdAt
```

---

# Operational Rules

## Rule: API Operation Does Not Own Business Rules

The endpoint must not:

- implement lifecycle rules
- implement cancellation rules
- implement release validation logic directly
- implement persistence logic directly

The endpoint should orchestrate existing backend behavior only.

---

## Rule: API Operation Returns Backend-Owned State

The response must reflect backend-owned operational truth.

The endpoint must not:
- infer lifecycle state
- mutate lifecycle state
- fabricate operational state

---

## Rule: API Operation Uses Existing Validation

Validation behavior must come from the validation layer defined in TASK-001A-003.

---

# Pseudocode Behavior

## API Flow

```text
receive CreateReleaseRequest

bind request

validate request

invoke create-release application behavior

receive CreateReleaseResponse

return successful created response
```

---

## Validation Failure Flow

```text
receive invalid request

validation fails

return validation failure response
```

---

# File / Code Area Guidance

Likely repository areas affected:

```text
/Endpoints
/API
/Application
/Tests
```

Potential implementation artifacts:

```text
CreateReleaseEndpoint
CreateReleaseControllerAction
API integration tests
```

Exact implementation structure should follow repository conventions.

---

# Required Tests

## API Integration Tests

### Test: Valid Request Returns Created Response

Verify:

- valid request succeeds
- successful response is returned
- response contains backend-generated identifier
- lifecycleState equals Draft

---

### Test: Invalid Request Returns Validation Failure

Verify:

- invalid title fails
- unsupported ReleaseType fails
- missing targetReleaseDate fails

---

### Test: Forbidden Operational Fields Are Not Caller-Controlled

Verify callers cannot control:

```text
id
lifecycleState
createdAt
updatedAt
```

through the API operation.

---

### Test: Response Matches Persisted Release

Verify API responses reflect persisted backend state.

---

# Acceptance Checks

This Task is complete when:

- create-release API operation exists
- request binding works
- validation executes
- create-release application behavior executes
- successful requests return CreateReleaseResponse
- invalid requests fail predictably
- API integration tests pass
- no lifecycle transition behavior exists
- no cancellation behavior exists
- no frontend behavior exists

---

# Implementation Guidance

Implementation should remain focused exclusively on exposing Release creation behavior through the API boundary.

Implementation should follow existing repository conventions for:

- endpoint structure
- routing
- request binding
- response handling
- testing organization
- implementation style

Implementation should preserve:

- backend-owned operational behavior
- lifecycle ownership protection
- bounded Task scope
- repository-local implementation
- reviewable change size

Implementation should include:

- create-release API operation
- request binding
- validation invocation
- application behavior invocation
- response handling
- API integration tests

Implementation should preserve backend ownership of:

- lifecycleState
- identifiers
- timestamps
- validation behavior

Suggested route shape:

```text
POST /releases
```

Implementation should avoid:

- lifecycle transitions
- cancellation workflows
- list/detail behavior
- frontend concerns
- dashboard behavior
- authentication/authorization systems

Testing should validate:

- valid requests succeed
- invalid requests fail predictably
- lifecycleState initializes to Draft
- backend-owned fields remain protected
- API responses reflect persisted backend state

---

# Implementation Risk Notes

## Risk: Endpoint Business Logic Leakage

Implementation may drift into business rule ownership.

Mitigation:

Endpoints orchestrate only.

Business behavior belongs to the application layer.

---

## Risk: Validation Duplication

Endpoint implementation may duplicate validation logic.

Mitigation:

Reuse validation behavior from TASK-001A-003.

---

## Risk: Lifecycle Ownership Leakage

Endpoint implementation may expose lifecycle mutation behavior.

Mitigation:

Only expose initialized lifecycleState returned by backend behavior.

---

## Risk: Future Authentication Drift

Implementation may prematurely introduce authentication complexity.

Mitigation:

Authentication and authorization are intentionally deferred from STORY-001A.

---

# Strategic Importance

This Task establishes:

- externally callable Release creation behavior
- backend API orchestration patterns
- API/application boundary consistency
- backend-owned operational response behavior

This Task intentionally acts as the API entry point for future:
- frontend release creation workflows
- operational release management workflows
- future authenticated API behavior