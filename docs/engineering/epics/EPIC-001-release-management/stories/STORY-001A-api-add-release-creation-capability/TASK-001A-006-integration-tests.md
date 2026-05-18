---
id: TASK-001A-006
title: Add Story-Level Integration Tests
type: Task

epic: EPIC-001
feature: FEATURE-001
story: STORY-001A

repository: proofworks-artistops-api
area: API

status: ReadyForImplementation

priority: Medium
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
  - TASK-001A-005

tags:
  - ArtistOps
  - ReleaseManagement
  - API
  - IntegrationTests
  - ReleaseCreation
---

# TASK-001A-006
# Add Story-Level Integration Tests

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

Validate STORY-001A as an independently integration-testable backend Story.

This Task establishes end-to-end verification that:

- create-release API behavior works
- backend operational rules are enforced
- lifecycle initialization is deterministic
- validation behavior functions correctly
- backend-owned operational truth remains protected

This Task intentionally focuses only on Story-level integration verification.

This Task intentionally avoids:

- frontend testing
- lifecycle transition testing
- cancellation testing
- dashboard testing
- authentication/authorization testing

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
TASK-001A-005-api-operation.md
```

---

# Scope

## In Scope

- Story-level API integration tests
- end-to-end create-release verification
- validation failure verification
- lifecycle initialization verification
- backend-owned operational rule verification
- response verification

## Out Of Scope

- frontend testing
- lifecycle transition testing
- cancellation testing
- list/detail behavior testing
- dashboard behavior testing
- authentication/authorization testing

---

# Integration Test Goals

The integration suite must prove:

- STORY-001A works independently inside the API repository
- valid requests create Releases successfully
- invalid requests fail predictably
- backend initializes lifecycleState to Draft
- backend owns operational state initialization
- API responses reflect persisted backend state

---

# Required Integration Scenarios

## Scenario: Valid Release Creation

### Given

```text
valid CreateReleaseRequest
```

### When

```text
caller invokes create-release API operation
```

### Then

Verify:

- request succeeds
- Release is created
- backend-generated identifier exists
- lifecycleState equals Draft
- timestamps exist
- response matches persisted Release state

---

## Scenario: Missing Title Fails

### Given

```text
CreateReleaseRequest without title
```

### When

```text
caller invokes create-release API operation
```

### Then

Verify:

- validation failure occurs
- title validation failure is returned
- Release is not created

---

## Scenario: Blank Title Fails

### Given

```text
blank or whitespace-only title
```

### When

```text
caller invokes create-release API operation
```

### Then

Verify:

- validation failure occurs
- Release is not created

---

## Scenario: Unsupported ReleaseType Fails

### Given

```text
unsupported ReleaseType
```

### When

```text
caller invokes create-release API operation
```

### Then

Verify:

- validation failure occurs
- Release is not created

---

## Scenario: Missing TargetReleaseDate Fails

### Given

```text
missing targetReleaseDate
```

### When

```text
caller invokes create-release API operation
```

### Then

Verify:

- validation failure occurs
- Release is not created

---

## Scenario: Caller Cannot Control Lifecycle State

### Given

```text
caller attempts to provide lifecycleState
```

### When

```text
create-release behavior executes
```

### Then

Verify:

```text
Release.lifecycleState == Draft
```

And verify:
- caller input cannot override backend lifecycle initialization

---

## Scenario: Caller Cannot Control Identifier

### Given

```text
caller attempts to provide id
```

### When

```text
create-release behavior executes
```

### Then

Verify:
- backend generates Release identifier
- caller input cannot override identifier generation

---

# Operational Rules Under Test

## Rule: Backend Owns Lifecycle Initialization

Verify:

```text
new Release.lifecycleState == Draft
```

for all successful create-release operations.

---

## Rule: Backend Owns Identifier Generation

Verify:
- Release identifiers are backend-generated
- callers cannot override identifiers

---

## Rule: Backend Validation Is Authoritative

Verify:
- invalid requests fail regardless of caller behavior
- frontend assumptions are irrelevant
- backend remains operational authority

---

# Pseudocode Test Flow

## Successful Flow

```text
submit valid CreateReleaseRequest

validate request

create Release

persist Release

return CreateReleaseResponse

verify persisted state
```

---

## Validation Failure Flow

```text
submit invalid CreateReleaseRequest

validation fails

return validation failure

verify Release was not created
```

---

# File / Code Area Guidance

Likely repository areas affected:

```text
/Tests
/IntegrationTests
/API
```

Potential implementation artifacts:

```text
CreateReleaseIntegrationTests
Story-level API test fixtures
test helpers
```

Exact implementation structure should follow repository conventions.

---

# Acceptance Checks

This Task is complete when:

- Story-level integration tests exist
- valid create-release requests succeed
- invalid requests fail predictably
- lifecycleState initializes to Draft
- backend-generated identifiers are verified
- validation behavior is verified
- response contracts are verified
- tests execute entirely within the API repository
- no frontend dependency exists
- no lifecycle transition behavior exists
- no cancellation behavior exists

---

# Implementation Guidance

Implementation should remain focused exclusively on STORY-001A integration verification.

Implementation should follow existing repository conventions for:

- integration testing structure
- test organization
- fixtures
- API testing
- implementation style

Implementation should preserve:

- backend-owned operational behavior
- lifecycle ownership protection
- bounded Task scope
- repository-local testing
- reviewable test coverage

Implementation should include:

- Story-level integration tests
- create-release workflow verification
- validation failure verification
- backend operational ownership verification

Required integration scenarios include:

- valid Release creation
- missing title validation failure
- blank title validation failure
- unsupported ReleaseType validation failure
- missing targetReleaseDate validation failure
- lifecycleState initialization to Draft
- backend-generated identifier verification

Implementation should preserve backend ownership of:

- lifecycle initialization
- identifier generation
- validation authority
- persisted response state

Implementation should avoid:

- lifecycle transitions
- cancellation workflows
- frontend tests
- dashboard behavior tests
- authentication/authorization systems

Testing should validate:

- successful end-to-end create-release behavior
- deterministic validation failures
- backend-owned operational state initialization
- persisted response consistency
- repository-local Story verification

---

# Implementation Risk Notes

## Risk: Test Environment Coupling

Integration tests may become tightly coupled to infrastructure specifics.

Mitigation:

Use repository-standard integration boundaries and fixtures.

---

## Risk: Hidden Lifecycle Expansion

Tests may accidentally assume lifecycle transition behavior exists.

Mitigation:

Only validate Draft initialization.

Do not test transitions.

---

## Risk: Frontend Assumption Leakage

Tests may accidentally rely on frontend behavior.

Mitigation:

Tests must execute entirely inside the API repository boundary.

---

## Risk: Over-Testing Future Behavior

Implementation may drift into future Features.

Mitigation:

Only verify STORY-001A operational behavior.

---

# Strategic Importance

This Task establishes:

- independently integration-testable Story verification
- deterministic backend operational validation
- end-to-end Release creation confidence
- backend-owned operational truth verification

This Task intentionally acts as the final verification boundary proving STORY-001A is implementation-complete and operationally coherent.