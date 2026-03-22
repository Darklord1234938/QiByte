# QiByte
 
A stack-based virtual machine with a custom instruction set, built from scratch in C#.
 
---
 
## What is it?
 
QiByte is a Forth-like stack machine — a virtual computer that executes its own custom bytecode instructions. It has its own lexer, token classifier, stack engine and arithmetic system.
 
The same paradigm powers some of the most important software in computing history:
- **Forth** — 1970s stack language still used in embedded systems
- **PostScript** — the language printers run
- **WebAssembly** — what the modern web runs at native speed
- **JVM** — what Java compiles to
- **CPython bytecode** — what Python actually executes
 
QiByte is an independent implementation of this paradigm, built from first principles.
 
---
 
## How it works
 
```
Source Code (text)
       │
       ▼
┌─────────────┐
│    LEXER    │  Tokenizes input using regex
└──────┬──────┘
       │
       ▼
┌─────────────┐
│   TOKENS    │  Classifies each token as ID or NUM
└──────┬──────┘
       │
       ▼
┌─────────────┐
│  DISPATCH   │  Matches instruction names to operations
└──────┬──────┘
       │
       ▼
┌─────────────┐
│    STACK    │  Executes operations on the value stack
└─────────────┘
```
 
---
 
## Example
 
```
PUSH 10 PUSH 4 ADD POP
```
 
Step by step:
```
PUSH 10  →  stack: [10]
PUSH 4   →  stack: [10, 4]
ADD      →  stack: [14]
POP      →  stack: []  (prints 14)
```
 
---
 
## Instruction Set
 
### Stack Operations
 
| Opcode | Code | Description |
|--------|------|-------------|
| PUSH n | 0x02 | Push value onto stack |
| POP    | 0x03 | Remove and print top of stack |
| DUP    | 0x04 | Duplicate top value |
| SWAP   | 0x05 | Swap top two values |
| OVER   | 0x06 | Copy second value to top |
| DROP2  | 0x08 | Remove top two values |
 
### Arithmetic
 
| Opcode | Code | Description |
|--------|------|-------------|
| ADD    | 0x10 | Add top two values |
| SUB    | 0x11 | Subtract top two values |
| MUL    | 0x12 | Multiply top two values |
| DIV    | 0x13 | Divide top two values |
| MOD    | 0x14 | Modulo of top two values |
| NEG    | 0x15 | Negate top value |
 
### Planned
 
| Opcode | Code | Description |
|--------|------|-------------|
| SHL    | 0x16 | Shift left |
| SHR    | 0x17 | Shift right |
| LSHR   | 0x18 | Logical right shift |
| NOT    | 0x19 | Bitwise NOT |
| JMP    | —    | Unconditional jump |
| JZ     | —    | Jump if zero |
| LABEL  | —    | Define jump target |
| VAR    | —    | Variable storage |
 
---
 
## Token System
 
QiByte classifies every token automatically:
 
```csharp
"10"    → TokenType.NUM
"PUSH"  → TokenType.ID
"3.14"  → TokenType.NUM
"ADD"   → TokenType.ID
```
 
Planned token types:
- `STRING` — "hello"
- `CHAR` — 'a'
- `BOOL` — True / False
- `LABEL` — jump targets
 
---
 
## Project Status
 
| Feature | Status |
|---------|--------|
| Lexer | ✅ Working |
| Token classifier | ✅ Working |
| Stack engine | ✅ Working |
| Arithmetic operations | ✅ Working |
| File input | 🔄 In progress |
| Binary bytecode format | 📋 Planned |
| Jump / label instructions | 📋 Planned |
| Variables / registers | 📋 Planned |
| Turing complete | 📋 Planned |
 
---
 
## Tech Stack
 
- **Language:** C#
- **Framework:** .NET
- **IDE:** Visual Studio
 
---
 
## What I Learned
 
- How lexers tokenize source code
- How stack machines execute instructions
- Why Forth semantics work the way they do
- How bytecode instruction sets are designed
- The relationship between source code and execution
 
---
 
## Roadmap
 
The goal is for QiByte to become the assembly language of [V-Console](../V-Console) — a custom virtual game console. Programs written in QiByte will compile to binary bytecode that the V-Console CPU executes directly.
 
```
QiByte source (.qib)
       │
       ▼
QiByte Compiler
       │
       ▼
Binary bytecode
       │
       ▼
V-Console CPU
```
 
---
 
## Related Projects
 
- [V-Console](https://github.com/Darklord1234938/V-console) — The virtual game console QiByte is being built for
- [CPU Emulator](https://github.com/Darklord1234938/CPU-EMU) — The CPU that will execute QiByte bytecode
 
---
 
## Author
 
**Quidon Roethof** — Software Developer, Netherlands
 
*Built from scratch to understand how programming languages and virtual machines actually work at a fundamental level.*