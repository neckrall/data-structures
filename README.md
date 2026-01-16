# Data Structures

This repository is an educational and exploratory project focused on
the practical study of data structures and algorithms.

## Project Goal

The primary goal of this repository is to achieve a **deep understanding
of how data structures work internally**, rather than to recreate
production-ready library implementations.

The project is used to:
- study the internal structure of data structures;
- analyze invariants and relationships between elements;
- understand the asymptotic complexity of operations (Big O);
- practice deliberate API and operation contract design.

All implementations are written from scratch and are intended to explain
**why** data structures behave the way they do, not merely **how**
to use them.

## Chosen Level of Abstraction

An intentionally simplified level of abstraction is used throughout
this project. Implementations:
- do not aim to be complete or universal replacements for standard
  library collections;
- may omit defensive programming and misuse validation;
- focus on the correctness of core operations and their complexity;
- do not always implement all platform-specific interfaces or conventions.

These decisions are made deliberately to avoid mixing algorithmic
learning with infrastructure or library design concerns.

## Testing

The correctness of implementations is verified using unit tests whose
purpose is to:
- validate operation contracts;
- detect logical errors in data structure behavior;
- ensure that structural invariants are preserved after operations.

The tests are not intended for performance benchmarking and do not
represent production-scale usage scenarios.

## Time and Space Complexity

The table below summarizes the asymptotic complexity of core operations.

| Data structure     | Access | Search | Insert                               | Remove                               | Space     |
| ------------------ | ------ | ------ | ------------------------------------ | ------------------------------------ | --------- |
| Singly Linked List | O(n)   | O(n)   | Known node - O(1)<br>By value - O(n) | Known node - O(1)<br>By value - O(n) | T + 1 ref |

### Notes

| Data structure     | Note                                                                                                                                                                                   |
| ------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Singly Linked List | Insertion and removal are constant-time operations only when the target<br>position is already known. When a previous node must be located, the<br>complexity degrades to linear time. |

### Big O Reference (Fast → Slow)
O(1) < O(log n) < O(n) < O(n log n) < O(n²) < O(2ⁿ)
_(This reference is provided for orientation when comparing operation costs.)_

## Repository Purpose

This repository serves as:
- a learning and knowledge reinforcement tool;
- a space for experimenting with architectural decisions;
- a demonstration of engineering thinking and core Computer Science
  fundamentals.

This project is not intended for direct use in production systems.
