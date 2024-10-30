# High-Level Code Compiler and Virtual Machine

This repository contains a project for creating a compiler that translates high-level code into a custom assembly language and a virtual machine to execute the generated assembly code.

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Code Structure](#code-structure)
- [License](#license)

## Overview
The project aims to develop a compiler that converts high-level programming code into a custom assembly language. Additionally, it includes a virtual machine to execute the generated assembly code, allowing for testing and debugging.

## Features
- **High-Level to Assembly Compilation**: Translates high-level code into a custom assembly language.
- **Virtual Machine Execution**: Executes the custom assembly code.
- **Debugging Tools**: Includes features for step-by-step execution and breakpoints.
- **Graphical User Interface**: Provides a GUI for loading, compiling, and executing code.

## Prerequisites
- **.NET Framework**: Ensure you have the .NET Framework installed.
- **Visual Studio**: Recommended for development and debugging.

## Installation
1. **Clone the repository**:
   ```sh
   git clone https://github.com/yourusername/high-level-code-compiler-vm.git
   cd high-level-code-compiler-vm
   ```

2. **Open the project in Visual Studio**:
   - Open `high-level-code-compiler-vm.sln` in Visual Studio.

3. **Build the project**:
   - Build the solution to restore dependencies and compile the code.

## Usage
1. **Load a high-level code file**:
   - Use the GUI to load a high-level code file.

2. **Compile the code**:
   - Click on the "Compile" button to translate the high-level code into assembly.

3. **Execute the assembly code**:
   - Use the virtual machine to execute the generated assembly code.
   - Utilize debugging features like step-by-step execution and breakpoints.

## Code Structure
- **`Form1.cs`**: Contains the main GUI logic and event handlers.
- **`Compiler.cs`**: Handles the compilation of high-level code to assembly.
- **`VirtualMachine.cs`**: Implements the virtual machine to execute assembly code.
- **`AssemblyLanguage.cs`**: Defines the custom assembly language syntax and semantics.

## License
This project is licensed under the MIT License. See the `LICENSE` file for details.
