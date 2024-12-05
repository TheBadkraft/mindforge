Knowledge Base: Codex of Sigma
Revision 2.012

Project Overview:
The Codex of Sigma project, through the MindForge Codificer and MindForge.Compiler toolchains, enables the design, generation, and compilation of custom programming languages. It consists of two main assemblies:

MindForge.Codificer.dll: Generates a parser for languages defined in the Codex format.
MindForge.Compiler.dll: Utilizes the generated parser to compile source code written in a Codex-defined language into executable form.

Core Concepts:
Modular Language Definition: Languages are defined using the Codex format, which supports modularity through include directives.
Control Directives: Directives prefixed with __ control parser behavior and can invoke plugins.
Dynamic Rule Generation: Parsing rules are dynamically created from Codex definitions, using an Abstract Rule Tree (ART) as an intermediary structure.

Abstract Rule Tree (ART):
The ART is a tree structure representing the grammar and rules from the Codex:

Nodes: Represent rules, rule components, or terminals.
Edges: Define relationships like composition, alternation, or sequence between rules.

MindForge Namespace and Assembly Structure:
csharp
// MindForge Codificer Assembly:
MindForge.Codificer.dll

namespace MindForge.Codificer {
    namespace Lexicon {
        namespace Analysis {
            // Class for lexical analysis of source code
            public class Lexer { ... }
            // Represents a token in the source code
            public class Token { ... }
            // Struct for indexing into character arrays for tokenization
            public struct Index { ... }
        }

        namespace Grammar {
            // Abstract base class for all rules
            public abstract class Rule { ... }
            // Class for rules that can be generated dynamically
            public class DynamicRule { ... }
            // Class representing a component of a rule
            public class RuleComponent { ... }
            // Factory class for creating rule objects from RuleNodes
            public class RuleFactory { 
                public static Rule CreateRule(RuleNode node) { ... } 
            }
            // Node in the Abstract Rule Tree (ART)
            public class RuleNode { ... }
            // Rule that can contain other rules, representing a combination
            public class CompositeRule { ... }
            // Collection of all rules for a language
            public class RuleSet { 
                public List<Rule> Rules { get; } = new List<Rule>();
                public void Add(Rule rule) { Rules.Add(rule); }
                // Other methods...
            }
        }
    }

    namespace Generation {
        // Class responsible for designing the parser structure
        public class Architect { ... }
        // Class for encoding parser logic into executable code
        public class Encoder { ... }
    }

    namespace Tools {
        // Utility for validating Codex definitions
        public class CodexValidator { ... }
        // Tool for monitoring performance of parsing operations
        public class PerformanceMonitor { ... }
    }

    // Main class for parsing Codex files into an ART
    public unsafe class CodexParser { 
        // Changed to reflect the use of RuleSet as the result
        public RuleSet ParseCodexFromFile(string filePath) { ... } 
        public RuleSet ParseCodexRules(string content) { ... } 
        private unsafe void IndexContent(string content) { ... }
    }
}

// MindForge Compiler Assembly:
MindForge.Compiler.dll

namespace MindForge.Compiler {
    // Class to encapsulate the result of parsing the source code
    public class ParseResult { 
        // Contains properties like ParseTree, Errors, etc.
    }

    // Uses the generated parser to parse source code at runtime
    public class RuntimeParser { 
        // Method to parse source code, returning a ParseResult
        public ParseResult Parse(string source) { ... }
    }

    // Main compilation class that generates executable from parsed code
    public class Compiler {
        // Method to compile parsed code, taking ParseResult as an argument
        public void Compile(ParseResult parseResult, string outputPath) { ... }
    }

    namespace Tools {
        // Optimization tool for improving compiled code
        public class CodeOptimizer { ... }
        // Error handling and reporting tool
        public class ErrorReporter { ... }
    }
}

Project Architecture:
MindForge.Codificer:
Parses Codex files into an ART.
Generates dynamic parsing rules from the ART, which are then collected into a RuleSet.
Contains namespaces for lexical analysis (Lexicon.Analysis), grammar (Lexicon.Grammar), parser generation (Generation), and utilities (Tools).
MindForge.Compiler:
Uses RuntimeParser to parse source code into a ParseResult.
Compiles the parsed source (ParseResult) into an executable using Compiler.
Includes ParseResult as a core component directly under MindForge.Compiler.
Also includes tools for optimization and error reporting in the Tools namespace.

Origin of the Term "Codificer":
The term "Codificer" combines:

Codify: To arrange laws or rules systematically, reflecting the project's aim to define language structures.
Artificer: An artisan or inventor, symbolizing the skill and creativity in crafting language processing tools.

Workflow:
Language Definition: Developers define a new language using the Codex format.
ART Construction: The CodexParser converts the Codex into an ART.
Parser Generation: 
RuleFactory dynamically creates rules from the ART.
Architect and Encoder generate the parser from these rules.
Software Development: Programmers write source code in the new language.
Compilation: 
The MindForge.Compiler uses RuntimeParser to parse the source code into a ParseResult.
Then, Compiler compiles this ParseResult into an executable.

Codex Documentation:
Part 1: Overview and Descriptions
Overview:

The Codex of Sigma language definition format is designed to provide a structured and extensible approach to defining programming languages. The uniqueness of our standard lies in:

Modularity: Through the Include directive, users can compose languages from reusable, modular components, simplifying maintenance and fostering reuse.
Simplicity and Readability: Balances expressiveness with simplicity for ease of use.
Toolchain Compatibility: Ensures language definitions work with the MindForge toolchain.
Versioning and History: Tracks language evolution through headers.
Flexibility: Allows defining both simple and complex languages.

Standard Header:

codex
## !tc_compatibility
## 
## Codex: [LanguageName]
## Release: [ReleaseName]
## Version: [VersionNumber]
## Include: ["FileName.codex", ...]
##//

!tc_compatibility: Ensures compatibility with the MindForge toolchain.
LanguageName: Name of the defined or extended language.
ReleaseName: Codename or identifier for the release.
VersionNumber: Tracks the language's evolution (major.minor.patch).
Include: Specifies additional Codex files to merge rules from.

Symbols:

:= - Defines rules.
| - Represents alternatives.
{} - Zero or more occurrences.
[] - Optional element.
? - Optional element (not used here).
... - Indicates repetition.
.. - Denotes a range of characters.

Quotes:

Double Quotes (") for string literals or character sets.
Single Quotes (') for character literals or nested quotes clarity.

Understanding Non-terminals and Terminals:

Non-terminals: < and > enclosed syntactic categories.
Terminals: Actual language symbols or literals.

Control Directives:
Introduction: Enhance compilation and runtime behavior.
Syntax: Prefixed with __ within angle brackets.
Examples: __managed.scope for resource management, __interop.metadata for external system integration.

Part 2: Rules, Declarations, and Samples
Rules:

Declarations: 
codex
<declaration> := <type> <identifier> ["=" <expression>]
Types: 
codex
<type> := "int" | "float" | "string" | "bool"
Expressions: 
codex
<expression> := <literal> | <identifier> | <unary_operator> <expression> | 
                <expression> <operator> <expression> | "(" <expression> ")"
Lexical Elements:
Identifier: <identifier> := <letter> | "_" { <letter> | <digit> | "_" }
Letter: <letter> := "A".."Z" | "a".."z"
Digit: <digit> := "0".."9"

Including Other Codex Files:

To merge rules from other files, use:

codex
## Include: ["FileName1.codex", "FileName2.codex"]

This structure promotes modularity and reusability in language definition.

Appendix: Coding Style Guidelines
Braces: Opening braces for namespaces, classes, methods, etc., should be on the same line.
Variable Naming: 
Use camelCase for local variables and method parameters.
Use PascalCase for public members, methods, and class names.
No Leading Underscores: Avoid starting identifiers or variables with underscores.
Method Length: Keep methods short and focused.
Comments: 
Use XML comments for public members and types.
Use // for inline comments where necessary.
Spacing: Ensure consistent spacing around operators and after commas.
Error Handling: Use exceptions for error handling.
Code Readability: Prioritize clarity and simplicity in code structure.