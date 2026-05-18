---
id: TASK-001A-003
title: Add Create Release Validation
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

tags:
  - ArtistOps
  - ReleaseManagement
  - API
  - Validation
  - ReleaseCreation
---

# TASK-001A-003
# Add Create Release Validation

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

Define and implement backend validation behavior for Release creation input.

This Task establishes the validation boundary protecting backend-owned operational behavior from invalid caller input.

This Task intentionally focuses only on:

- create-release validation rules
- validation failure behavior
- supported enum validation
- required field validation
- validation tests

This Task intentionally avoids:

- endpoint orchestration
- persistence behavior
- lifecycle transitions
- cancellation behavior
- frontend validation behavior
- application orchestration

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
```

---

# Scope

## In Scope

- title validation
- releaseType validation
- targetReleaseDate validation
- operationalNotes validation
- validation failure behavior
- validation tests

## Out Of Scope

- endpoint implementation
- persistence behavior
- lifecycle transitions
- cancellation workflows
- frontend validation behavior
- request/response serialization
- application orchestration

---

# Validation Rules

## Rule: Title Is Required

The request must contain:

```text
title
```

Validation failure occurs when:

- title is missing
- title is null
- title is empty
- title is whitespace-only

---

## Rule: Title Maximum Length

The title must not exceed the repository-approved maximum length.

Suggested MVP constraint:

```text
150 characters
```

Final implementation should follow repository standards if a canonical shared limit exists.

---

## Rule: ReleaseType Must Be Supported

The request must contain a supported ReleaseType value.

Allowed values:

```text
Single
EP
Album
LiveRelease
Other
```

Unsupported enum values must fail validation.

---

## Rule: TargetReleaseDate Is Required

The request must contain:

```text
targetReleaseDate
```

Validation failure occurs when:
- value is missing
- value is null
- value cannot be parsed as a valid calendar date

---

## Rule: OperationalNotes Is Optional

The request may omit:

```text
operationalNotes
```

If provided:
- operationalNotes must remain within repository-approved maximum length
- operationalNotes must serialize safely

Suggested MVP constraint:

```text
2000 characters
```

---

## Rule: Lifecycle Ownership Remains Backend-Owned

Validation must reject or ignore caller attempts to provide:

```text
id
lifecycleState
createdAt
updatedAt
```

according to repository standards.

---

# Validation Failure Expectations

Validation failures should:

- remain deterministic
- return structured validation failure information
- identify invalid fields when appropriate
- avoid exposing internal implementation details

Validation behavior should remain consistent with repository API standards.

---

# Pseudocode Behavior

## Validation Flow

```text
function validateCreateReleaseRequest(request):

    require title exists
    require title is not blank
    require title length is valid

    require releaseType is supported

    require targetReleaseDate exists
    require targetReleaseDate is valid

    if operationalNotes exists:
        require operationalNotes length is valid

    reject forbidden operational ownership fields

    return validation result
```

---

# File / Code Area Guidance

Likely repository areas affected:

```text
/Validation
/Contracts
/Tests
```

Potential implementation artifacts:

```text
CreateReleaseRequestValidator
validation tests
validation failure helpers
```

Exact implementation structure should follow repository conventions.

---

# Required Tests

## Validation Success Tests

### Test: Valid Request Passes Validation

Verify:

- valid title passes
- supported releaseType passes
- valid targetReleaseDate passes
- optional operationalNotes passes

---

## Validation Failure Tests

### Test: Missing Title Fails Validation

Verify:
- missing title fails
- validation failure references title

---

### Test: Blank Title Fails Validation

Verify:
- empty title fails
- whitespace-only title fails

---

### Test: Oversized Title Fails Validation

Verify:
- titles exceeding maximum length fail validation

---

### Test: Unsupported ReleaseType Fails Validation

Verify:
- unsupported enum values fail validation

---

### Test: Missing TargetReleaseDate Fails Validation

Verify:
- missing targetReleaseDate fails validation

---

### Test: Oversized OperationalNotes Fails Validation

Verify:
- oversized operationalNotes fails validation

---

### Test: Forbidden Lifecycle Fields Are Rejected Or Ignored

Verify callers cannot control:

```text
id
lifecycleState
createdAt
updatedAt
```

according to repository standards.

---

# Acceptance Checks

This Task is complete when:

- title validation exists
- releaseType validation exists
- targetReleaseDate validation exists
- operationalNotes validation exists
- unsupported ReleaseType values fail validation
- invalid requests fail deterministically
- validation tests pass
- validation remains backend-owned
- no endpoint behavior exists
- no persistence behavior exists
- no lifecycle transition behavior exists

---

# Implementation Guidance

Implementation should remain focused exclusively on backend validation behavior for CreateReleaseRequest.

Implementation should follow existing repository conventions for:

- validation structure
- naming consistency
- testing organization
- error handling
- implementation style

Implementation should preserve:

- backend-owned validation authority
- lifecycle ownership protection
- bounded Task scope
- repository-local implementation
- reviewable change size

Implementation should include validation for:

- required title
- non-blank title
- title maximum length
- supported ReleaseType values
- required targetReleaseDate
- operationalNotes length constraints when provided

Implementation should preserve backend ownership of:

- id
- lifecycleState
- createdAt
- updatedAt

Implementation should avoid:

- endpoint orchestration
- persistence behavior
- lifecycle transitions
- cancellation workflows
- frontend validation assumptions
- application orchestration behavior

Testing should validate:

- valid requests pass
- invalid requests fail deterministically
- unsupported ReleaseType values fail
- required field validation behavior
- oversized value handling
- forbidden operational ownership field handling

---

# Implementation Risk Notes

## Risk: Frontend Validation Leakage

Implementation may assume frontend validation guarantees.

Mitigation:

Backend validation remains authoritative.

---

## Risk: Validation Drift

Validation rules may diverge from operational ownership rules.

Mitigation:

Preserve backend ownership of:
- lifecycle state
- identifiers
- timestamps

---

## Risk: Framework-Coupled Validation

Validation implementation may become tightly coupled to a specific framework pattern.

Mitigation:

Preserve operational validation intent independent of framework specifics.

---

## Risk: Business Logic Leakage

Validation implementation may drift into orchestration behavior.

Mitigation:

Keep this Task validation-only.

Application orchestration belongs to TASK-001A-004.

---

# Strategic Importance

This Task establishes:

- backend-owned validation authority
- deterministic create-release validation
- caller/backend operational boundaries
- future API validation consistency

This Task intentionally acts as the validation boundary protecting backend-owned operational truth.