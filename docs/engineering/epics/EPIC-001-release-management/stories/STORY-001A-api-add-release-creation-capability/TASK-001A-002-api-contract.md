---
id: TASK-001A-002
title: Define Create Release API Contracts
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

tags:
  - ArtistOps
  - ReleaseManagement
  - API
  - Contracts
  - ReleaseCreation
---

# TASK-001A-002
# Define Create Release API Contracts

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

Define the API-facing request and response contracts required for Release creation.

This Task establishes the external create-release contract boundary between callers and backend-owned operational behavior.

This Task intentionally focuses only on:

- request contract shape
- response contract shape
- caller-owned fields
- backend-owned fields
- serialization expectations
- contract-level correctness

This Task intentionally avoids:

- validation implementation
- create-release orchestration
- persistence behavior
- lifecycle transition behavior
- cancellation behavior
- endpoint implementation

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

Dependent Task:

```text
TASK-001A-001-domain-model.md
```

---

# Scope

## In Scope

- CreateReleaseRequest definition
- CreateReleaseResponse definition
- request field definitions
- response field definitions
- serialization expectations
- lifecycle ownership protection
- contract-level tests

## Out Of Scope

- validation implementation
- endpoint implementation
- persistence behavior
- lifecycle transitions
- cancellation workflows
- application orchestration
- frontend implementation

---

# API Contract Definitions

## Contract: CreateReleaseRequest

Represents caller-provided input used to create a Release.

### Fields

| Field | Type | Required | Owner | Notes |
|---|---|---:|---|---|
| title | text | yes | caller | required |
| releaseType | ReleaseType | yes | caller | approved enum value only |
| targetReleaseDate | calendar date | yes | caller | required |
| operationalNotes | text | no | caller | optional |

---

## Forbidden Request Fields

The request contract must NOT include:

| Field | Reason |
|---|---|
| id | backend-generated |
| lifecycleState | backend-owned |
| createdAt | backend-owned |
| updatedAt | backend-owned |

The caller must not control operational state initialization.

---

## Contract: CreateReleaseResponse

Represents the backend-created Release returned after successful creation.

### Fields

| Field | Type | Required | Owner | Notes |
|---|---|---:|---|---|
| id | unique identifier | yes | backend | generated during creation |
| title | text | yes | backend | normalized/persisted value |
| releaseType | ReleaseType | yes | backend | persisted value |
| targetReleaseDate | calendar date | yes | backend | persisted value |
| lifecycleState | ReleaseLifecycleState | yes | backend | must equal Draft |
| operationalNotes | text | no | backend | persisted value |
| createdAt | timestamp | yes | backend | assigned during creation |

---

# Behavioral Rules

## Rule: Request Does Not Control Lifecycle

The caller must not provide:

```text
lifecycleState
```

The backend owns lifecycle initialization.

---

## Rule: Request Does Not Control Identity

The caller must not provide:

```text
id
```

The backend generates identifiers.

---

## Rule: Response Must Reflect Persisted State

The response must contain:

- backend-generated identifier
- persisted values
- initialized lifecycle state
- backend-assigned timestamps

---

# Serialization Expectations

## Request Serialization

The request contract should:

- serialize consistently
- support standard API request binding
- reject unsupported enum values
- ignore or reject forbidden operational fields according to repository standards

---

## Response Serialization

The response contract should:

- serialize consistently
- expose backend-owned operational values
- expose initialized lifecycleState
- expose backend-generated identifier

---

# Pseudocode Behavior

## Request Flow

```text
caller submits CreateReleaseRequest

backend validates request

backend initializes Release

backend returns CreateReleaseResponse
```

---

## Contract Ownership Flow

```text
caller owns:
    title
    releaseType
    targetReleaseDate
    operationalNotes

backend owns:
    id
    lifecycleState
    createdAt
    updatedAt
```

---

# File / Code Area Guidance

Likely repository areas affected:

```text
/Contracts
/Contracts/Releases
/Tests
```

Potential implementation artifacts:

```text
CreateReleaseRequest
CreateReleaseResponse
contract serialization tests
```

Exact implementation structure should follow repository conventions.

---

# Required Tests

## Contract Serialization Tests

### Test: Serialize Valid CreateReleaseRequest

Verify:

- valid request serializes correctly
- required fields serialize correctly
- optional operationalNotes serializes correctly

---

### Test: Request Does Not Include Forbidden Operational Fields

Verify request contract excludes:

```text
id
lifecycleState
createdAt
updatedAt
```

---

### Test: Serialize Valid CreateReleaseResponse

Verify:

- response serializes correctly
- lifecycleState serializes correctly
- backend-generated identifier serializes correctly

---

### Test: Response Includes Draft Lifecycle State

Verify:

```text
CreateReleaseResponse.lifecycleState == Draft
```

---

# Acceptance Checks

This Task is complete when:

- CreateReleaseRequest exists
- CreateReleaseResponse exists
- request contract contains only caller-owned fields
- request contract excludes lifecycle ownership
- request contract excludes identifier ownership
- response contract exposes backend-owned operational values
- response exposes initialized lifecycleState
- contract serialization tests pass
- no validation implementation exists
- no endpoint implementation exists
- no application orchestration exists

---

# Implementation Guidance

Implementation should remain focused exclusively on the API request and response contracts required for Release creation.

Implementation should follow existing repository conventions for:

- folder structure
- naming consistency
- serialization behavior
- testing organization
- implementation style

Implementation should preserve:

- backend ownership boundaries
- lifecycle ownership protection
- bounded Task scope
- repository-local implementation
- reviewable change size

Implementation should include:

- CreateReleaseRequest
- CreateReleaseResponse
- contract serialization tests

Implementation should avoid:

- validation behavior
- application orchestration
- API endpoint implementation
- persistence logic
- lifecycle transitions
- cancellation workflows
- frontend concerns

Testing should validate:

- request serialization
- response serialization
- exclusion of forbidden operational fields
- lifecycleState exposure in responses
- Draft lifecycleState serialization behavior

---

# Implementation Risk Notes

## Risk: Lifecycle Ownership Leakage

The request contract may accidentally expose lifecycleState.

Mitigation:

Do not allow caller-controlled lifecycle fields.

---

## Risk: Identifier Ownership Leakage

The request contract may accidentally expose id.

Mitigation:

Identifiers remain backend-owned.

---

## Risk: Validation Leakage

Implementation may accidentally include validation behavior.

Mitigation:

Validation belongs to TASK-001A-003.

Keep this Task contract-only.

---

## Risk: Endpoint Leakage

Implementation may drift into endpoint orchestration.

Mitigation:

Endpoint behavior belongs to TASK-001A-005.

Keep this Task contract-only.

---

# Strategic Importance

This Task establishes:

- the caller/backend contract boundary
- backend operational ownership boundaries
- lifecycle ownership protection
- future API consistency patterns

This Task intentionally acts as the API contract seam for later:
- validation
- application orchestration
- endpoint behavior
- frontend integration