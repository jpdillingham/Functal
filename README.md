# Functal v1.0.0 README

Thank you for downloading Functal! This has been a passion project of mine for a while now, and I
hope you enjoy using it!

This README is a quick guide to getting started. Full
documentation on learning the Functal language and using the library API can be found at
[functal.com/api/v1](functal.com/api/v1)

If you find Functal useful, please consider donating to support its continued development:
[functal.com/donate](functal.com/donate)

## Installation

Functal is a .Net Standard 2.0 Library. It can be added your project by adding `Functal.dll` as a
dependency. For example, in Visual Studio 2019:

1. In the Solution Explorer, right click the `References` or `Dependencies` item and click
  `Add Reference`. This opens the Reference Manager.
2. Click `Assemblies` on the left side of the Reference Manager, and then click `Browse`.
3. Navigate to where you have saved `Functal.dll` and click `Add`.
4. Click `OK`.

You're now ready to use Functal in your .Net project!

## Full Documentation

For full documentation on Functal's vast featureset, visit [functal.com/api/v1](functal.com/api/v1)

## Language Features

The Functal language has lots of great features. For a demonstration of each of the below features,
look at the quick examples below:

* Data Types
* Literals
* Operators
* Constants (can add your own)
* Parameters (like variables)
* Functions with Overloading (can add your own).
* If Statements

## Quick Examples

The following are some quick examples for how to use Functal's features. Paste these snippets into a
.Net Console application and start debugging to try them out:

### Hello World

```cs
using System;
using Functal;

public static class Program {
  public static void Main(string[] argv) {
    FunctalExpression<int> expression = new FunctalCompiler().Compile<int>(
      "LengthOf(\"Hello, world!\")"
    );
    Console.WriteLine(expression.Execute());
    Console.ReadKey();
  }
}
```

### Operators

```cs
using System;
using Functal;

class Program {
  static void Main(string[] args) {
    FunctalCompiler compiler = new FunctalCompiler();

    // Arithmetic operators.
    FunctalExpression<int> arithmeticExpression = compiler.Compile<int>("(1 + 2) * 3 / 2");
    Console.WriteLine(arithmeticExpression.Execute());

    // Logical operators.
    FunctalExpression<bool> logicalExpression = compiler.Compile<bool>("(1 < 2) && (4 != 3)");
    Console.WriteLine(logicalExpression.Execute());

    Console.ReadKey();
  }
}
```

### Type Conversions

```cs
using System;
using Functal;

public static class Program {
  public static void Main(string[] argv) {
    FunctalExpression<int> expression = new FunctalCompiler().Compile<int>("int(3.5f)");
    Console.WriteLine(expression.Execute());
    Console.ReadKey();
  }
}
```

### If Statements

```cs
using System;
using Functal;

public static class Program {
  public static void Main(string[] argv) {
    FunctalExpression<string> expression = new FunctalCompiler().Compile<string>(
      "if(1 < 2, \"1 is indeed smaller than 2\", \"Something is definitely wrong\")"
    );
    Console.WriteLine(expression.Execute());
    Console.ReadKey();
  }
}
```

### Using Built-In Functions

```cs
using System;
using Functal;

public static class Program {
  public static void Main(string[] argv) {
    FunctalExpression<int> expression = new FunctalCompiler().Compile<int>("Min(100, 200)");
    Console.WriteLine(expression.Execute());
    Console.ReadKey();
  }
}
```

### Using Parameters

```cs
using System;
using System.Collections.Generic;
using Functal;

class Program
{
  static void Main(string[] args) {
    FnVariable<int> MyInteger = new FnVariable<int>(1);
    FnVariable<float> MyFloat = new FnVariable<float>(2.5f);
    
    Dictionary<string, FnObject> parameters = new Dictionary<string, FnObject>() {
      { "MyInteger", MyInteger },
      { "MyFloat", MyFloat },
    };

    FunctalCompiler compiler = new FunctalCompiler();
    FunctalExpression<float> expression = compiler.Compile<float>(
      "[MyInteger] + [MyFloat]", parameters
    );

    Console.WriteLine(expression.Execute()); // Output: 3.5

    // Changing the value of the FnVariable changes the output of the expression!
    MyInteger.Value = 5;
    Console.WriteLine(expression.Execute()); // Output: 7.5

    Console.ReadKey();
  }
}
```

### Creating Constants

```cs
using System;
using Functal;

class Program {
  static void Main(string[] args) {
    FunctalResources.AddConstant<string>("HELLO_WORLD", "Hello, world!");

    FunctalCompiler compiler = new FunctalCompiler();
    Console.WriteLine(compiler.Compile<string>("HELLO_WORLD").Execute());

    Console.ReadKey();
  }
}
```

### Creating Custom Functions

```cs
using System;
using Functal;

/// <summary>
/// Returns true if the specified number is less than 5, false if not.
/// </summary>
class FnFunction_IsLessThanFive : FnFunction<bool> {
  /// <summary>First argument: The number to check.</summary>
  [FnArg] protected FnObject<int> Number;

  public override bool GetValue() {
    return Number.GetValue() < 5;
  }
}

class Program {
  static void Main(string[] args) {
    // Add custom function to Functal.
    FunctalResources.CreateFunctionGroup("IsLessThanFive");
    FunctalResources.AddFunctionToGroup("IsLessThanFive", new FnFunction_IsLessThanFive());

    FunctalCompiler compiler = new FunctalCompiler();
    
    Console.WriteLine(compiler.Compile<string>(
      "\"First Result: \" + ToString(IsLessThanFive(3))", null
    ).Execute());
    
    Console.WriteLine(compiler.Compile<string>(
      "\"Second Result: \" + ToString(IsLessThanFive(7))", null
    ).Execute());

    Console.ReadKey();
  }
}
```

### Creating Function Overloads

```cs
using System;
using Functal;

/// <summary>
/// Returns true if the specified number is less than 5, false if not.
/// </summary>
class FnFunction_IsLessThanFive : FnFunction<bool> {
  /// <summary>First argument: The number to check.</summary>
  [FnArg] protected FnObject<int> Number;

  public override bool GetValue() {
    return Number.GetValue() < 5;
  }
}

/// <summary>
/// Returns true if a string has less than 5 characters, false if not.
/// </summary>
class FnFunction_IsLessThanFiveChars : FnFunction<bool> {
  /// <summary>The string to check.</summary>
  [FnArg] protected FnObject<string> Text;

  public override bool GetValue() {
    return Text.GetValue().Length < 5;
  }
}

class Program {
  static void Main(string[] args) {
    // Add custom function to Functal.
    FunctalResources.CreateFunctionGroup("IsLessThanFive");
    FunctalResources.AddFunctionToGroup("IsLessThanFive", new FnFunction_IsLessThanFive());
    FunctalResources.AddFunctionToGroup("IsLessThanFive", new FnFunction_IsLessThanFiveChars());

    FunctalCompiler compiler = new FunctalCompiler();
    Console.WriteLine(
      compiler.Compile<string>(
        "\"First Result: \" + ToString(IsLessThanFive(3))", null
      ).Execute()
    );
    Console.WriteLine(
      compiler.Compile<string>(
        "\"Second Result: \" + ToString(IsLessThanFive(7))", null
      ).Execute()
    );
    Console.WriteLine(
      compiler.Compile<string>(
        "\"Third Result: \" + ToString(IsLessThanFive(\"Definitely More Than Five Characters\"))",
        null
      ).Execute()
    );

    Console.ReadKey();
  }
}
```

## Contact

If you have feedback (complimentary or critical), problems or just want to say hi, you can email
your thoughts to feedback@functal.com

Copyright (c) 2020 Jayden Tilbrook

