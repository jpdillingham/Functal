// Decompiled with JetBrains decompiler
// Type: Functal.FunctalCompiler
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace Functal
{
  public class FunctalCompiler
  {
    private List<string> BinaryOperators = new List<string>()
    {
      "&&",
      "!&&",
      "||",
      "!||",
      "^",
      ">",
      "<",
      "==",
      "<=",
      ">=",
      "!=",
      "+",
      "-",
      "*",
      "/",
      "%"
    };
    private Dictionary<string, int> BinaryOperatorPrecedence = new Dictionary<string, int>()
    {
      {
        "&&",
        0
      },
      {
        "!&&",
        0
      },
      {
        "||",
        0
      },
      {
        "!||",
        0
      },
      {
        "^",
        0
      },
      {
        ">",
        1
      },
      {
        "<",
        1
      },
      {
        "==",
        1
      },
      {
        "<=",
        1
      },
      {
        ">=",
        1
      },
      {
        "!=",
        1
      },
      {
        "+",
        2
      },
      {
        "-",
        2
      },
      {
        "*",
        3
      },
      {
        "/",
        3
      },
      {
        "%",
        3
      }
    };
    private List<string> UnaryPrefixOperators = new List<string>()
    {
      "+",
      "-",
      "!"
    };
    private Dictionary<string, int> UnaryPrefixOperatorPrecedence = new Dictionary<string, int>()
    {
      {
        "+",
        4
      },
      {
        "-",
        4
      },
      {
        "!",
        4
      }
    };
    private List<string> UnarySuffixOperators = new List<string>(0);
    private Dictionary<string, int> UnarySuffixOperatorPrecedence = new Dictionary<string, int>(0);
    private char[] OperatorsAndGrouping = new char[15]
    {
      '%',
      '(',
      ')',
      '*',
      '+',
      ',',
      '-',
      '/',
      '<',
      '=',
      '>',
      '&',
      '|',
      '!',
      '^'
    };
    private char[] Operators = new char[12]
    {
      '%',
      '*',
      '+',
      '-',
      '/',
      '<',
      '=',
      '>',
      '&',
      '|',
      '!',
      '^'
    };
    private char[] StartGrouping = new char[1]{ '(' };
    private char[] EndGrouping = new char[1]{ ')' };
    private char[] DivisionGrouping = new char[1]{ ',' };
    private char[] Grouping = new char[3]{ '(', ')', ',' };
    private const char StartParam = '[';
    private const char EndParam = ']';

    public FunctalCompiler()
    {
      Array.Sort<char>(this.OperatorsAndGrouping);
      Array.Sort<char>(this.Operators);
      Array.Sort<char>(this.Grouping);
    }

    public FunctalExpression<T> Compile<T>(string expression)
    {
      return this.Compile<T>(expression, (Dictionary<string, FnObject>) null, (Dictionary<string, FnObject>) null);
    }

    public FunctalExpression<T> Compile<T>(
      string expression,
      Dictionary<string, FnObject> localParameters)
    {
      return this.Compile<T>(expression, localParameters, (Dictionary<string, FnObject>) null);
    }

    public FunctalExpression<T> Compile<T>(
      string expression,
      Dictionary<string, FnObject> localParameters,
      Dictionary<string, FnObject> collectionParameters)
    {
      List<FnObject> executionList = new List<FnObject>();
      FnVariable<bool> isPreExecute1 = new FnVariable<bool>(false);
      List<bool> isBound = new List<bool>();
      Dictionary<string, FnObject> parameters1 = this.AggregateParameters(localParameters, collectionParameters);
      string rawExpression = expression;
      expression = expression.Trim();
      List<FunctalCompiler.FnObjectProfiles> profiles = new List<FunctalCompiler.FnObjectProfiles>(expression.Length);
      for (int index = 0; index < expression.Length; ++index)
        profiles.Add(FunctalCompiler.FnObjectProfiles.Unassessed);
      Stack<int> functionBracketBalances = new Stack<int>();
      int bracketBalance = 0;
      for (int index = 0; index < expression.Length; ++index)
      {
        if (this.FollowsNumericStartRule(expression[index]))
          this.FormatNumber(ref expression, ref profiles, ref index);
        else if (this.FollowsOperatorStartRule(expression[index]))
          this.FormatOperator(ref expression, ref profiles, ref index);
        else if (this.FollowsNameStartRule(expression[index]))
          this.FormatFunctionOrConstant(ref expression, ref profiles, ref index, bracketBalance, functionBracketBalances);
        else if (this.FollowsStartGroupingRule(expression[index]))
          this.FormatStartGrouping(ref expression, ref profiles, ref index, ref bracketBalance);
        else if (this.FollowsEndGroupingRule(expression[index]))
          this.FormatEndGrouping(ref expression, ref profiles, ref index, ref bracketBalance, ref functionBracketBalances);
        else if (this.FollowsDivisionGroupingRule(expression[index]))
          this.FormatDivisionGrouping(ref expression, ref profiles, ref index, ref bracketBalance, ref functionBracketBalances);
        else if (this.FollowsParameterStartRule(expression[index]))
          this.FormatParameter(ref expression, ref profiles, ref parameters1, ref index);
        else if (this.FollowsStringStartRule(expression[index]))
        {
          this.FormatString(ref expression, ref profiles, ref index);
        }
        else
        {
          if (!this.FollowsCharStartRule(expression[index]))
            throw new ArgumentException("Syntax error, consult expression");
          this.FormatChar(ref expression, ref profiles, ref index);
        }
      }
      if (bracketBalance != 0)
        throw new ArgumentException("Open/Close bracket mismatch", expression);
      this.ConvertToExecutionTree(expression, profiles, ref parameters1, ref executionList, ref isBound, isPreExecute1);
      if (executionList.Last<FnObject>().GetWrappedObjectType() != typeof (T))
      {
        if (!FunctalResources.ImplicitConversionSwitches.ContainsKey(typeof (T)))
          throw new ArgumentException("The output type of the expression doesn't match the specified return type", expression);
        List<FnObject> fnObjectList = executionList;
        FnFunctionGroup conversionSwitch = FunctalResources.ImplicitConversionSwitches[typeof (T)];
        List<FnObject> arguments = new List<FnObject>();
        arguments.Add(executionList.Last<FnObject>());
        Dictionary<string, FnObject> parameters2 = parameters1;
        FnVariable<bool> isPreExecute2 = isPreExecute1;
        FnObject objectWithPointer = conversionSwitch.CreateObjectWithPointer(arguments, parameters2, isPreExecute2);
        fnObjectList.Add(objectWithPointer);
        isBound[isBound.Count - 1] = true;
        isBound.Add(false);
      }
      FnObject<T> executionNode = executionList.Last<FnObject>() as FnObject<T>;
      this.CacheExpression<T>(ref executionNode);
      return new FunctalExpression<T>(executionNode, rawExpression, parameters1, isPreExecute1);
    }

    private void ConvertToExecutionTree(
      string expression,
      List<FunctalCompiler.FnObjectProfiles> characterProfiles,
      ref Dictionary<string, FnObject> parameters,
      ref List<FnObject> executionList,
      ref List<bool> isBound,
      FnVariable<bool> isPreExecute)
    {
      Stack<string> operatorStack = new Stack<string>();
      Stack<FunctalCompiler.FnObjectProfiles> operatorProfileStack = new Stack<FunctalCompiler.FnObjectProfiles>();
      for (int index = 0; index < expression.Length; ++index)
      {
        if (this.IsLiteralTypeProfile(characterProfiles[index]))
          this.AddLiteralToExecutionTree(expression, characterProfiles, ref executionList, ref isBound, ref index);
        else if (this.IsOperatorTypeProfile(characterProfiles[index]))
          this.AddOperatorToExecutionTree(expression, characterProfiles, ref index, ref operatorStack, ref operatorProfileStack, ref executionList, ref isBound, parameters, isPreExecute);
        else if (characterProfiles[index] == FunctalCompiler.FnObjectProfiles.StartGrouping)
        {
          operatorStack.Push(expression[index].ToString());
          operatorProfileStack.Push(characterProfiles[index]);
        }
        else if (characterProfiles[index] == FunctalCompiler.FnObjectProfiles.EndGrouping)
        {
          while (operatorStack.Peek() != "(")
            this.PopOperatorToExecutionTree(ref operatorStack, ref operatorProfileStack, ref executionList, ref isBound, parameters, isPreExecute);
          operatorStack.Pop();
          int num = (int) operatorProfileStack.Pop();
        }
        else if (characterProfiles[index] == FunctalCompiler.FnObjectProfiles.ParameterBody)
          this.AddParameterInstanceToExecutionTree(expression, characterProfiles, ref parameters, ref executionList, ref isBound, ref index);
        else if (characterProfiles[index] == FunctalCompiler.FnObjectProfiles.Constant)
        {
          this.AddConstantToExecutionTree(expression, characterProfiles, ref executionList, ref isBound, ref index);
        }
        else
        {
          if (characterProfiles[index] != FunctalCompiler.FnObjectProfiles.FunctionName)
            throw new ArgumentException("The Execution tree doesn't support this type of object");
          this.AddFunctionToExecutionTree(expression, characterProfiles, ref parameters, ref executionList, ref isBound, ref index, isPreExecute);
        }
      }
      while (operatorStack.Count != 0)
        this.PopOperatorToExecutionTree(ref operatorStack, ref operatorProfileStack, ref executionList, ref isBound, parameters, isPreExecute);
    }

    private void CacheExpression<T>(ref FnObject<T> executionNode)
    {
      executionNode = executionNode.CheckAndCache() as FnObject<T>;
    }

    private Dictionary<string, FnObject> AggregateParameters(
      Dictionary<string, FnObject> localParameters,
      Dictionary<string, FnObject> collectionParameters)
    {
      if (localParameters == null)
        localParameters = new Dictionary<string, FnObject>();
      if (collectionParameters == null)
        collectionParameters = new Dictionary<string, FnObject>();
      Dictionary<string, FnObject> dictionary = new Dictionary<string, FnObject>((IDictionary<string, FnObject>) localParameters);
      for (int index = 0; index < collectionParameters.Count; ++index)
      {
        string key = collectionParameters.ElementAt<KeyValuePair<string, FnObject>>(index).Key;
        if (!dictionary.ContainsKey(key))
          dictionary.Add(key, collectionParameters[key]);
      }
      for (int index = 0; index < FunctalResources.GlobalParameters.Count; ++index)
      {
        string key = FunctalResources.GlobalParameters.ElementAt<KeyValuePair<string, FnObject>>(index).Key;
        if (!dictionary.ContainsKey(key))
          dictionary.Add(key, FunctalResources.GlobalParameters[key]);
      }
      return dictionary;
    }

    private void AddLocalGhostArgument_ParentExpression<T>(
      ref List<FnObject> ghostArguments,
      ref FunctalExpression<T> expression)
    {
      ghostArguments.Insert(0, (FnObject) new FnVariable<FunctalExpression>((FunctalExpression) expression));
    }

    private bool IsOperandStartCharacter(char expressionCharacter)
    {
      return this.FollowsStringStartRule(expressionCharacter) || this.FollowsCharStartRule(expressionCharacter) || (this.FollowsNameStartRule(expressionCharacter) || this.FollowsNumericStartRule(expressionCharacter)) || this.FollowsParameterStartRule(expressionCharacter);
    }

    private bool FollowsNumericStartRule(char expressionCharacter)
    {
      return expressionCharacter >= '0' && expressionCharacter <= '9' || this.FollowsNumericDecimalRule(expressionCharacter);
    }

    private bool FollowsNumericBodyRule(char expressionCharacter)
    {
      return this.FollowsNumericStartRule(expressionCharacter);
    }

    private bool FollowsNumericDecimalRule(char expressionCharacter)
    {
      return expressionCharacter == '.';
    }

    private bool FollowsNumericSuffixRule(char expressionCharacter)
    {
      return expressionCharacter >= 'a' && expressionCharacter <= 'z' || expressionCharacter >= 'A' && expressionCharacter <= 'Z';
    }

    private bool FollowsStringStartRule(char expressionCharacter)
    {
      return expressionCharacter == '"';
    }

    private bool FollowsStringEndRule(char expressionCharacter)
    {
      return expressionCharacter == '"';
    }

    private bool FollowsCharStartRule(char expressionCharacter)
    {
      return expressionCharacter == '\'';
    }

    private bool FollowsCharEndRule(char expressionCharacter)
    {
      return expressionCharacter == '\'';
    }

    private bool FollowsParameterStartRule(char expressionCharacter)
    {
      return expressionCharacter == '[';
    }

    private bool FollowsParameterBodyRule(char expressionCharacter)
    {
      return !this.FollowsParameterStartRule(expressionCharacter) && !this.FollowsParameterEndRule(expressionCharacter);
    }

    private bool FollowsParameterEndRule(char expressionCharacter)
    {
      return expressionCharacter == ']';
    }

    private bool FollowsOperatorStartRule(char expressionCharacter)
    {
      return ((IEnumerable<char>) this.Operators).Contains<char>(expressionCharacter);
    }

    private bool FollowsOperatorBodyRule(char expressionCharacter)
    {
      return this.FollowsOperatorStartRule(expressionCharacter);
    }

    private bool FollowsStartGroupingRule(char expressionCharacter)
    {
      return ((IEnumerable<char>) this.StartGrouping).Contains<char>(expressionCharacter);
    }

    private bool FollowsEndGroupingRule(char expressionCharacter)
    {
      return ((IEnumerable<char>) this.EndGrouping).Contains<char>(expressionCharacter);
    }

    private bool FollowsDivisionGroupingRule(char expressionCharacter)
    {
      return ((IEnumerable<char>) this.DivisionGrouping).Contains<char>(expressionCharacter);
    }

    private bool FollowsBinarySurroundingRules(
      ref string expression,
      ref List<FunctalCompiler.FnObjectProfiles> profiles,
      int startIndex,
      int successorIndex)
    {
      if (startIndex <= 0 || profiles[startIndex - 1] != FunctalCompiler.FnObjectProfiles.UnarySuffixOperator && profiles[startIndex - 1] != FunctalCompiler.FnObjectProfiles.EndGrouping && !this.IsOperandEndProfile(profiles[startIndex - 1]))
        return false;
      while (successorIndex < expression.Length && expression[successorIndex] == ' ')
        this.RemoveCharacterFromExpression(ref expression, ref profiles, successorIndex);
      return successorIndex < expression.Length && (this.FollowsOperatorStartRule(expression[successorIndex]) || this.FollowsStartGroupingRule(expression[successorIndex]) || this.IsOperandStartCharacter(expression[successorIndex]));
    }

    private bool FollowsUnaryPrefixSurroundingRules(
      ref string expression,
      ref List<FunctalCompiler.FnObjectProfiles> profiles,
      int startIndex,
      int successorIndex)
    {
      if (startIndex != 0 && profiles[startIndex - 1] != FunctalCompiler.FnObjectProfiles.StartGrouping && (profiles[startIndex - 1] != FunctalCompiler.FnObjectProfiles.DivisionGrouping && profiles[startIndex - 1] != FunctalCompiler.FnObjectProfiles.BinaryOperator))
        return false;
      while (successorIndex < expression.Length && expression[successorIndex] == ' ')
        this.RemoveCharacterFromExpression(ref expression, ref profiles, successorIndex);
      return successorIndex < expression.Length && (this.FollowsStartGroupingRule(expression[successorIndex]) || this.IsOperandStartCharacter(expression[successorIndex]));
    }

    private bool FollowsUnarySuffixSurroundingRules(
      ref string expression,
      ref List<FunctalCompiler.FnObjectProfiles> profiles,
      int startIndex,
      int successorIndex)
    {
      if (startIndex <= 0 || profiles[startIndex - 1] != FunctalCompiler.FnObjectProfiles.EndGrouping && !this.IsOperandEndProfile(profiles[startIndex - 1]))
        return false;
      while (successorIndex < expression.Length && expression[successorIndex] == ' ')
        this.RemoveCharacterFromExpression(ref expression, ref profiles, successorIndex);
      return successorIndex == expression.Length || this.FollowsEndGroupingRule(expression[successorIndex]) || (this.FollowsDivisionGroupingRule(expression[successorIndex]) || this.FollowsOperatorStartRule(expression[successorIndex]));
    }

    private bool FollowsOperandSuccessorRule(
      ref string expression,
      ref List<FunctalCompiler.FnObjectProfiles> profiles,
      int index)
    {
      if (index >= expression.Length)
        return true;
      if (expression[index] == ' ')
      {
        while (index < expression.Length && expression[index] == ' ')
          this.RemoveCharacterFromExpression(ref expression, ref profiles, index);
      }
      return index >= expression.Length || expression[index] == ' ' || (((IEnumerable<char>) this.Operators).Contains<char>(expression[index]) || expression[index] == ',') || expression[index] == ')';
    }

    private bool FollowsNameStartRule(char expressionCharacter)
    {
      return expressionCharacter >= 'A' && expressionCharacter <= 'Z' || expressionCharacter >= 'a' && expressionCharacter <= 'z' || expressionCharacter == '_';
    }

    private bool FollowsNameBodyRule(char expressionCharacter)
    {
      return this.FollowsNameStartRule(expressionCharacter) || expressionCharacter >= '0' && expressionCharacter <= '9';
    }

    private bool FollowsFunctionNameSuccessorRule(
      ref string expression,
      ref List<FunctalCompiler.FnObjectProfiles> profiles,
      int index)
    {
      while (index < expression.Length && expression[index] == ' ')
        this.RemoveCharacterFromExpression(ref expression, ref profiles, index);
      return index < expression.Length && expression[index] == '(';
    }

    private bool IsOperandEndProfile(FunctalCompiler.FnObjectProfiles profile)
    {
      return profile == FunctalCompiler.FnObjectProfiles.StringBody || profile == FunctalCompiler.FnObjectProfiles.CharBody || (profile == FunctalCompiler.FnObjectProfiles.Constant || profile == FunctalCompiler.FnObjectProfiles.ParameterBody) || (profile == FunctalCompiler.FnObjectProfiles.Byte || profile == FunctalCompiler.FnObjectProfiles.SByte || (profile == FunctalCompiler.FnObjectProfiles.Int16 || profile == FunctalCompiler.FnObjectProfiles.UInt16)) || (profile == FunctalCompiler.FnObjectProfiles.Int32 || profile == FunctalCompiler.FnObjectProfiles.UInt32 || (profile == FunctalCompiler.FnObjectProfiles.Int64 || profile == FunctalCompiler.FnObjectProfiles.UInt64) || (profile == FunctalCompiler.FnObjectProfiles.Single || profile == FunctalCompiler.FnObjectProfiles.Double));
    }

    private bool IsNumericTypeProfile(FunctalCompiler.FnObjectProfiles profile)
    {
      return profile == FunctalCompiler.FnObjectProfiles.Byte || profile == FunctalCompiler.FnObjectProfiles.SByte || (profile == FunctalCompiler.FnObjectProfiles.Int16 || profile == FunctalCompiler.FnObjectProfiles.UInt16) || (profile == FunctalCompiler.FnObjectProfiles.Int32 || profile == FunctalCompiler.FnObjectProfiles.UInt32 || (profile == FunctalCompiler.FnObjectProfiles.Int64 || profile == FunctalCompiler.FnObjectProfiles.UInt64)) || (profile == FunctalCompiler.FnObjectProfiles.Single || profile == FunctalCompiler.FnObjectProfiles.Double);
    }

    private bool IsLiteralTypeProfile(FunctalCompiler.FnObjectProfiles profile)
    {
      return profile == FunctalCompiler.FnObjectProfiles.StringBody || profile == FunctalCompiler.FnObjectProfiles.CharBody || (profile == FunctalCompiler.FnObjectProfiles.Byte || profile == FunctalCompiler.FnObjectProfiles.SByte) || (profile == FunctalCompiler.FnObjectProfiles.Int16 || profile == FunctalCompiler.FnObjectProfiles.UInt16 || (profile == FunctalCompiler.FnObjectProfiles.Int32 || profile == FunctalCompiler.FnObjectProfiles.UInt32)) || (profile == FunctalCompiler.FnObjectProfiles.Int64 || profile == FunctalCompiler.FnObjectProfiles.UInt64 || (profile == FunctalCompiler.FnObjectProfiles.Single || profile == FunctalCompiler.FnObjectProfiles.Double));
    }

    private bool IsOperatorTypeProfile(FunctalCompiler.FnObjectProfiles profile)
    {
      return profile == FunctalCompiler.FnObjectProfiles.UnaryPrefixOperator || profile == FunctalCompiler.FnObjectProfiles.UnarySuffixOperator || profile == FunctalCompiler.FnObjectProfiles.BinaryOperator;
    }

    private void FormatString(
      ref string expression,
      ref List<FunctalCompiler.FnObjectProfiles> profiles,
      ref int index)
    {
      int startIndex = index;
      if (!this.FollowsStringStartRule(expression[index]))
        throw new ArgumentException("the position provided isn't the start of a String", index.ToString());
      this.RemoveCharacterFromExpression(ref expression, ref profiles, index);
      while (!this.FollowsStringEndRule(expression[index]))
      {
        if (expression[index] == '\\')
        {
          this.RemoveCharacterFromExpression(ref expression, ref profiles, index);
          if (expression[index] == 'a')
            this.ReplaceAt(ref expression, index, "\a");
          else if (expression[index] == 'b')
            this.ReplaceAt(ref expression, index, "\b");
          else if (expression[index] == 'f')
            this.ReplaceAt(ref expression, index, "\f");
          else if (expression[index] == 'n')
            this.ReplaceAt(ref expression, index, "\n");
          else if (expression[index] == 'r')
            this.ReplaceAt(ref expression, index, "\r");
          else if (expression[index] == 't')
            this.ReplaceAt(ref expression, index, "\t");
          else if (expression[index] == 'v')
            this.ReplaceAt(ref expression, index, "\v");
          else if (expression[index] == '\'')
            this.ReplaceAt(ref expression, index, "'");
          else if (expression[index] == '"')
          {
            this.ReplaceAt(ref expression, index, "\"");
          }
          else
          {
            if (expression[index] != '\\')
              throw new ArgumentException("Unrecognised escape sequence", expression[index].ToString());
            this.ReplaceAt(ref expression, index, "\\");
          }
        }
        profiles[index] = FunctalCompiler.FnObjectProfiles.StringBody;
        ++index;
        if (index >= expression.Length)
          throw new ArgumentException("String was not closed, did you forget a \"?", expression.ToString());
      }
      this.RemoveCharacterFromExpression(ref expression, ref profiles, index);
      int num = index;
      if (startIndex == num)
      {
        this.InsertRangeIntoExpression(ref expression, ref profiles, ref startIndex, "EmptyString");
        index = startIndex - 1;
      }
      else
      {
        index = num - 1;
        if (!this.FollowsOperandSuccessorRule(ref expression, ref profiles, index + 1))
          throw new ArgumentException("invalid operand/operator combination found");
      }
    }

    private void FormatChar(
      ref string expression,
      ref List<FunctalCompiler.FnObjectProfiles> profiles,
      ref int index)
    {
      if (!this.FollowsCharStartRule(expression[index]))
        throw new ArgumentException("the position provided isn't the start of a Char", index.ToString());
      this.RemoveCharacterFromExpression(ref expression, ref profiles, index);
      while (!this.FollowsCharEndRule(expression[index]))
      {
        if (expression[index] == '\\')
        {
          this.RemoveCharacterFromExpression(ref expression, ref profiles, index);
          if (expression[index] == 'a')
            this.ReplaceAt(ref expression, index, "\a");
          else if (expression[index] == 'b')
            this.ReplaceAt(ref expression, index, "\b");
          else if (expression[index] == 'f')
            this.ReplaceAt(ref expression, index, "\f");
          else if (expression[index] == 'n')
            this.ReplaceAt(ref expression, index, "\n");
          else if (expression[index] == 'r')
            this.ReplaceAt(ref expression, index, "\r");
          else if (expression[index] == 't')
            this.ReplaceAt(ref expression, index, "\t");
          else if (expression[index] == 'v')
            this.ReplaceAt(ref expression, index, "\v");
          else if (expression[index] == '\'')
            this.ReplaceAt(ref expression, index, "'");
          else if (expression[index] == '"')
          {
            this.ReplaceAt(ref expression, index, "\"");
          }
          else
          {
            if (expression[index] != '\\')
              throw new ArgumentException("Unrecognised escape sequence", expression[index].ToString());
            this.ReplaceAt(ref expression, index, "\\");
          }
        }
        profiles[index] = FunctalCompiler.FnObjectProfiles.CharBody;
        ++index;
        if (index >= expression.Length)
          throw new ArgumentException("Char was not closed, did you forget a '?", expression.ToString());
      }
      this.RemoveCharacterFromExpression(ref expression, ref profiles, index);
      --index;
      if (!this.FollowsOperandSuccessorRule(ref expression, ref profiles, index + 1))
        throw new ArgumentException("invalid operand/operator combination found");
    }

    private void FormatFunctionOrConstant(
      ref string expression,
      ref List<FunctalCompiler.FnObjectProfiles> profiles,
      ref int index,
      int bracketBalance,
      Stack<int> functionBracketBalances)
    {
      int startIndex = index;
      int num = index + 1;
      if (!this.FollowsNameStartRule(expression[index]))
        throw new ArgumentException("the position provided isn't the start of a function call or constant", index.ToString());
      profiles[index] = FunctalCompiler.FnObjectProfiles.Name;
      ++index;
      while (index < expression.Length && this.FollowsNameBodyRule(expression[index]))
      {
        profiles[index] = FunctalCompiler.FnObjectProfiles.Name;
        ++index;
      }
      int index1 = index;
      string name = expression.Substring(startIndex, index1 - startIndex);
      if (this.FollowsOperandSuccessorRule(ref expression, ref profiles, index))
      {
        if (!FunctalResources.DoesConstantExist(name))
          throw new ArgumentException(string.Format("the specified constant ({0}) does not exist", (object) name));
        for (int index2 = startIndex; index2 < index1; ++index2)
          profiles[index2] = FunctalCompiler.FnObjectProfiles.Constant;
      }
      else
      {
        if (!this.FollowsFunctionNameSuccessorRule(ref expression, ref profiles, index1))
          throw new ArgumentException("Invalid operand/operator combination found.");
        if (!FunctalResources.DoesFunctionGroupExist(name) && name != "if")
          throw new ArgumentException(string.Format("the specified function ({0}) does not exist.", (object) name));
        for (int index2 = startIndex; index2 < index1; ++index2)
          profiles[index2] = FunctalCompiler.FnObjectProfiles.FunctionName;
        functionBracketBalances.Push(bracketBalance + 1);
      }
      index = index1 - 1;
    }

    private void FormatStartGrouping(
      ref string expression,
      ref List<FunctalCompiler.FnObjectProfiles> profiles,
      ref int index,
      ref int bracketBalance)
    {
      if (!this.FollowsStartGroupingRule(expression[index]))
        throw new ArgumentException("The provided index does not denote an open grouping symbol", index.ToString());
      ++bracketBalance;
      profiles[index] = FunctalCompiler.FnObjectProfiles.StartGrouping;
      while (index + 1 < expression.Length && expression[index + 1] == ' ')
        this.RemoveCharacterFromExpression(ref expression, ref profiles, index + 1);
      if (index + 1 >= expression.Length || this.FollowsEndGroupingRule(expression[index + 1]) && profiles[index - 1] != FunctalCompiler.FnObjectProfiles.FunctionName || this.FollowsDivisionGroupingRule(expression[index + 1]))
        throw new ArgumentException("the open grouping symbol you have provided is in the incorrect context");
    }

    private void FormatDivisionGrouping(
      ref string expression,
      ref List<FunctalCompiler.FnObjectProfiles> profiles,
      ref int index,
      ref int bracketBalance,
      ref Stack<int> functionBracketBalances)
    {
      if (!this.FollowsDivisionGroupingRule(expression[index]))
        throw new ArgumentException("The provided index does not denote a division grouping symbol", index.ToString());
      if (functionBracketBalances.Count == 0 || bracketBalance != functionBracketBalances.Peek())
        throw new ArgumentException("The division grouping symbol is in the incorrect context", expression);
      profiles[index] = FunctalCompiler.FnObjectProfiles.DivisionGrouping;
      while (index + 1 < expression.Length && expression[index + 1] == ' ')
        this.RemoveCharacterFromExpression(ref expression, ref profiles, index + 1);
      if (index + 1 >= expression.Length || this.FollowsEndGroupingRule(expression[index + 1]) || this.FollowsDivisionGroupingRule(expression[index + 1]))
        throw new ArgumentException("the division grouping symbol you have provided is in the incorrect context");
    }

    private void FormatEndGrouping(
      ref string expression,
      ref List<FunctalCompiler.FnObjectProfiles> profiles,
      ref int index,
      ref int bracketBalance,
      ref Stack<int> functionBracketBalances)
    {
      if (!this.FollowsEndGroupingRule(expression[index]))
        throw new ArgumentException("The provided index does not denote a close grouping symbol", index.ToString());
      if (bracketBalance - 1 < 0)
        throw new ArgumentException("Open/close bracket mismatch");
      if (functionBracketBalances.Count > 0 && bracketBalance == functionBracketBalances.Peek())
        functionBracketBalances.Pop();
      else if (profiles[index - 1] == FunctalCompiler.FnObjectProfiles.StartGrouping)
        throw new ArgumentException("You cannot have empty brackets", expression);
      --bracketBalance;
      profiles[index] = FunctalCompiler.FnObjectProfiles.EndGrouping;
      while (index + 1 < expression.Length && expression[index + 1] == ' ')
        this.RemoveCharacterFromExpression(ref expression, ref profiles, index + 1);
      if (index + 1 < expression.Length && !this.FollowsOperatorStartRule(expression[index + 1]) && (!this.FollowsEndGroupingRule(expression[index + 1]) && !this.FollowsDivisionGroupingRule(expression[index + 1])))
        throw new ArgumentException("the close bracket you have provided is in the incorrect context");
    }

    private void FormatNumber(
      ref string expression,
      ref List<FunctalCompiler.FnObjectProfiles> profiles,
      ref int index)
    {
      int startIndex = index;
      int num1 = index + 1;
      string paramName = "";
      FunctalCompiler.FnObjectProfiles fnObjectProfiles = FunctalCompiler.FnObjectProfiles.Int32;
      if (!this.FollowsNumericStartRule(expression[index]))
        throw new ArgumentException("the position provided isn't the start of a number", index.ToString());
      profiles[index] = FunctalCompiler.FnObjectProfiles.Number;
      ++index;
      while (index < expression.Length && this.FollowsNumericBodyRule(expression[index]))
      {
        profiles[index] = FunctalCompiler.FnObjectProfiles.Number;
        if (this.FollowsNumericDecimalRule(expression[index]))
          fnObjectProfiles = FunctalCompiler.FnObjectProfiles.Double;
        ++index;
      }
      int num2 = index;
      while (index < expression.Length && this.FollowsNumericSuffixRule(expression[index]))
      {
        profiles[index] = FunctalCompiler.FnObjectProfiles.NumericSuffix;
        paramName += expression[index].ToString();
        ++index;
      }
      if (!this.FollowsOperandSuccessorRule(ref expression, ref profiles, index))
        throw new ArgumentException("Invalid numeric format detected");
      switch (paramName.ToLower())
      {
        case "":
          for (int index1 = 0; index1 < expression.Length; ++index1)
          {
            if (profiles[index1] == FunctalCompiler.FnObjectProfiles.Number)
              profiles[index1] = fnObjectProfiles;
            else if (profiles[index1] == FunctalCompiler.FnObjectProfiles.NumericSuffix)
            {
              this.RemoveCharacterFromExpression(ref expression, ref profiles, index1);
              --index1;
            }
          }
          switch (fnObjectProfiles)
          {
            case FunctalCompiler.FnObjectProfiles.SByte:
              sbyte result1 = 0;
              if (!sbyte.TryParse(expression.Substring(startIndex, num2 - startIndex), out result1))
                throw new ArgumentException("invalid numeric format detected", expression.Substring(startIndex, num2 - startIndex));
              break;
            case FunctalCompiler.FnObjectProfiles.Byte:
              byte result2 = 0;
              if (!byte.TryParse(expression.Substring(startIndex, num2 - startIndex), out result2))
                throw new ArgumentException("invalid numeric format detected", expression.Substring(startIndex, num2 - startIndex));
              break;
            case FunctalCompiler.FnObjectProfiles.Int16:
              short result3 = 0;
              if (!short.TryParse(expression.Substring(startIndex, num2 - startIndex), out result3))
                throw new ArgumentException("invalid numeric format detected", expression.Substring(startIndex, num2 - startIndex));
              break;
            case FunctalCompiler.FnObjectProfiles.UInt16:
              ushort result4 = 0;
              if (!ushort.TryParse(expression.Substring(startIndex, num2 - startIndex), out result4))
                throw new ArgumentException("invalid numeric format detected", expression.Substring(startIndex, num2 - startIndex));
              break;
            case FunctalCompiler.FnObjectProfiles.Int32:
              int result5 = 0;
              if (!int.TryParse(expression.Substring(startIndex, num2 - startIndex), out result5))
                throw new ArgumentException("invalid numeric format detected", expression.Substring(startIndex, num2 - startIndex));
              break;
            case FunctalCompiler.FnObjectProfiles.UInt32:
              uint result6 = 0;
              if (!uint.TryParse(expression.Substring(startIndex, num2 - startIndex), out result6))
                throw new ArgumentException("invalid numeric format detected", expression.Substring(startIndex, num2 - startIndex));
              break;
            case FunctalCompiler.FnObjectProfiles.Int64:
              long result7 = 0;
              if (!long.TryParse(expression.Substring(startIndex, num2 - startIndex), out result7))
                throw new ArgumentException("invalid numeric format detected", expression.Substring(startIndex, num2 - startIndex));
              break;
            case FunctalCompiler.FnObjectProfiles.UInt64:
              ulong result8 = 0;
              if (!ulong.TryParse(expression.Substring(startIndex, num2 - startIndex), out result8))
                throw new ArgumentException("invalid numeric format detected", expression.Substring(startIndex, num2 - startIndex));
              break;
            case FunctalCompiler.FnObjectProfiles.Single:
              float result9 = 0.0f;
              if (!float.TryParse(expression.Substring(startIndex, num2 - startIndex), out result9))
                throw new ArgumentException("invalid numeric format detected", expression.Substring(startIndex, num2 - startIndex));
              break;
            case FunctalCompiler.FnObjectProfiles.Double:
              double result10 = 0.0;
              if (!double.TryParse(expression.Substring(startIndex, num2 - startIndex), out result10))
                throw new ArgumentException("invalid numeric format detected", expression.Substring(startIndex, num2 - startIndex));
              break;
            default:
              throw new Exception("unacceptable numeric data type detected");
          }
          index = num2 - 1;
          break;
        case "b":
          fnObjectProfiles = FunctalCompiler.FnObjectProfiles.Byte;
          goto case "";
        case "f":
          fnObjectProfiles = FunctalCompiler.FnObjectProfiles.Single;
          goto case "";
        case "l":
          fnObjectProfiles = FunctalCompiler.FnObjectProfiles.Int64;
          goto case "";
        case "s":
          fnObjectProfiles = FunctalCompiler.FnObjectProfiles.Int16;
          goto case "";
        case "sb":
          fnObjectProfiles = FunctalCompiler.FnObjectProfiles.SByte;
          goto case "";
        case "u":
          fnObjectProfiles = FunctalCompiler.FnObjectProfiles.UInt32;
          goto case "";
        case "ul":
          fnObjectProfiles = FunctalCompiler.FnObjectProfiles.UInt64;
          goto case "";
        case "us":
          fnObjectProfiles = FunctalCompiler.FnObjectProfiles.UInt16;
          goto case "";
        default:
          throw new ArgumentException("the provided numeric suffix has no implementation", paramName);
      }
    }

    private void FormatParameter(
      ref string expression,
      ref List<FunctalCompiler.FnObjectProfiles> profiles,
      ref Dictionary<string, FnObject> parameters,
      ref int index)
    {
      int startIndex = index;
      int num1 = index + 1;
      if (!this.FollowsParameterStartRule(expression[index]))
        throw new ArgumentException("The position you have specified isn't the start of a parameter", index.ToString());
      this.RemoveCharacterFromExpression(ref expression, ref profiles, index);
      while (this.FollowsParameterBodyRule(expression[index]))
      {
        profiles[index] = FunctalCompiler.FnObjectProfiles.ParameterBody;
        ++index;
      }
      if (!this.FollowsParameterEndRule(expression[index]))
        throw new ArgumentException("Invalid parameter syntax detected");
      int num2 = index;
      if (num2 - startIndex == 0)
        throw new ArgumentException("Empty parameter detected, every parameter must have a name");
      if (!this.FollowsOperandSuccessorRule(ref expression, ref profiles, index + 1))
        throw new ArgumentException("Invalid Operator/Operand border detected");
      this.RemoveCharacterFromExpression(ref expression, ref profiles, index);
      --index;
      string str = expression.Substring(startIndex, num2 - startIndex);
      if (!parameters.ContainsKey(str))
        throw new ArgumentException("The parameter has not been declared in any of the parameter accessibility lists", str);
    }

    private void FormatOperator(
      ref string expression,
      ref List<FunctalCompiler.FnObjectProfiles> profiles,
      ref int index)
    {
      int startIndex = index;
      int num = index + 1;
      if (!this.FollowsOperatorStartRule(expression[index]))
        throw new ArgumentException("The position you have defined is not the start of an operator", index.ToString());
      profiles[index] = FunctalCompiler.FnObjectProfiles.Operator;
      ++index;
      while (index < expression.Length && this.FollowsOperatorBodyRule(expression[index]))
      {
        profiles[index] = FunctalCompiler.FnObjectProfiles.Operator;
        ++index;
      }
      string paramName;
      for (paramName = expression.Substring(startIndex, index - startIndex); !this.BinaryOperators.Contains(paramName) && !this.UnaryPrefixOperators.Contains(paramName) && !this.UnarySuffixOperators.Contains(paramName); paramName = expression.Substring(startIndex, index - startIndex))
      {
        profiles[index] = FunctalCompiler.FnObjectProfiles.Unassessed;
        --index;
      }
      int successorIndex = index;
      if (this.FollowsBinarySurroundingRules(ref expression, ref profiles, startIndex, successorIndex) && this.BinaryOperators.Contains(paramName))
      {
        for (int index1 = startIndex; index1 < successorIndex; ++index1)
          profiles[index1] = FunctalCompiler.FnObjectProfiles.BinaryOperator;
      }
      else if (this.FollowsUnaryPrefixSurroundingRules(ref expression, ref profiles, startIndex, successorIndex) && this.UnaryPrefixOperators.Contains(paramName))
      {
        for (int index1 = startIndex; index1 < successorIndex; ++index1)
          profiles[index1] = FunctalCompiler.FnObjectProfiles.UnaryPrefixOperator;
      }
      else
      {
        if (!this.FollowsUnarySuffixSurroundingRules(ref expression, ref profiles, startIndex, successorIndex) || !this.UnarySuffixOperators.Contains(paramName))
          throw new ArgumentException("The operator provided is in the incorrect context", paramName);
        for (int index1 = startIndex; index1 < successorIndex; ++index1)
          profiles[index1] = FunctalCompiler.FnObjectProfiles.UnarySuffixOperator;
      }
      for (int index1 = successorIndex; index1 < expression.Length; ++index1)
        profiles[index1] = FunctalCompiler.FnObjectProfiles.Unassessed;
      index = successorIndex - 1;
    }

    private void InsertRangeIntoExpression(
      ref string expression,
      ref List<FunctalCompiler.FnObjectProfiles> profiles,
      ref int startIndex,
      string insertString)
    {
      expression = expression.Insert(startIndex, insertString);
      List<FunctalCompiler.FnObjectProfiles> fnObjectProfilesList = new List<FunctalCompiler.FnObjectProfiles>(insertString.Length);
      for (int index = 0; index < insertString.Length; ++index)
        fnObjectProfilesList.Add(FunctalCompiler.FnObjectProfiles.Unassessed);
      profiles.InsertRange(startIndex, (IEnumerable<FunctalCompiler.FnObjectProfiles>) fnObjectProfilesList);
    }

    private void ReplaceAt(ref string expression, int index, string newCharacter)
    {
      expression = expression.Remove(index, 1);
      expression = expression.Insert(index, newCharacter);
    }

    private void RemoveCharacterFromExpression(
      ref string expression,
      ref List<FunctalCompiler.FnObjectProfiles> profiles,
      int index)
    {
      expression = expression.Remove(index, 1);
      profiles.RemoveAt(index);
    }

    private void RemoveCharacterRangeFromExpression(
      ref string expression,
      ref List<FunctalCompiler.FnObjectProfiles> profiles,
      int startIndex,
      int endIndex)
    {
      for (int index = startIndex; index <= endIndex; ++index)
        this.RemoveCharacterFromExpression(ref expression, ref profiles, startIndex);
    }

    private void AddOperatorToExecutionTree(
      string expression,
      List<FunctalCompiler.FnObjectProfiles> profiles,
      ref int index,
      ref Stack<string> operatorStack,
      ref Stack<FunctalCompiler.FnObjectProfiles> operatorProfileStack,
      ref List<FnObject> executionList,
      ref List<bool> isBound,
      Dictionary<string, FnObject> parameters,
      FnVariable<bool> isPreExecute)
    {
      int startIndex = index;
      while (index < expression.Length && profiles[index] == profiles[startIndex])
        ++index;
      int num = index;
      --index;
      string operatorName = expression.Substring(startIndex, num - startIndex);
      while (operatorStack.Count != 0 && this.GetOperatorPrecedence(operatorStack.Peek(), operatorProfileStack.Peek()) >= this.GetOperatorPrecedence(operatorName, profiles[startIndex]))
        this.PopOperatorToExecutionTree(ref operatorStack, ref operatorProfileStack, ref executionList, ref isBound, parameters, isPreExecute);
      operatorStack.Push(operatorName);
      operatorProfileStack.Push(profiles[startIndex]);
    }

    private void PopOperatorToExecutionTree(
      ref Stack<string> operatorStack,
      ref Stack<FunctalCompiler.FnObjectProfiles> operatorProfileStack,
      ref List<FnObject> ExecutionList,
      ref List<bool> IsBound,
      Dictionary<string, FnObject> parameters,
      FnVariable<bool> isPreExecute)
    {
      if (operatorProfileStack.Peek() == FunctalCompiler.FnObjectProfiles.BinaryOperator)
      {
        int nextUnBoundIndex1 = this.GetNextUnBoundIndex(ref IsBound);
        IsBound[nextUnBoundIndex1] = true;
        int nextUnBoundIndex2 = this.GetNextUnBoundIndex(ref IsBound);
        IsBound[nextUnBoundIndex2] = true;
        List<FnObject> fnObjectList = ExecutionList;
        string operatorString = operatorStack.Pop();
        int num = (int) operatorProfileStack.Pop();
        List<FnObject> operands = new List<FnObject>();
        operands.Add(ExecutionList[nextUnBoundIndex2]);
        operands.Add(ExecutionList[nextUnBoundIndex1]);
        Dictionary<string, FnObject> parameters1 = parameters;
        FnVariable<bool> isPreExecute1 = isPreExecute;
        FnObject operatorFunction = this.GetOperatorFunction(operatorString, (FunctalCompiler.FnObjectProfiles) num, operands, parameters1, isPreExecute1);
        fnObjectList.Add(operatorFunction);
      }
      else
      {
        int nextUnBoundIndex = this.GetNextUnBoundIndex(ref IsBound);
        IsBound[nextUnBoundIndex] = true;
        List<FnObject> fnObjectList = ExecutionList;
        string operatorString = operatorStack.Pop();
        int num = (int) operatorProfileStack.Pop();
        List<FnObject> operands = new List<FnObject>();
        operands.Add(ExecutionList[nextUnBoundIndex]);
        Dictionary<string, FnObject> parameters1 = parameters;
        FnVariable<bool> isPreExecute1 = isPreExecute;
        FnObject operatorFunction = this.GetOperatorFunction(operatorString, (FunctalCompiler.FnObjectProfiles) num, operands, parameters1, isPreExecute1);
        fnObjectList.Add(operatorFunction);
      }
      IsBound.Add(false);
    }

    private void AddLiteralToExecutionTree(
      string expression,
      List<FunctalCompiler.FnObjectProfiles> profiles,
      ref List<FnObject> ExecutionList,
      ref List<bool> IsBound,
      ref int index)
    {
      int startIndex = index;
      while (index < profiles.Count && this.IsLiteralTypeProfile(profiles[index]))
        ++index;
      int num = index;
      --index;
      string s = expression.Substring(startIndex, num - startIndex);
      if (profiles[startIndex] == FunctalCompiler.FnObjectProfiles.Byte)
        ExecutionList.Add((FnObject) new FnConstant<byte>(byte.Parse(s)));
      else if (profiles[startIndex] == FunctalCompiler.FnObjectProfiles.SByte)
        ExecutionList.Add((FnObject) new FnConstant<sbyte>(sbyte.Parse(s)));
      else if (profiles[startIndex] == FunctalCompiler.FnObjectProfiles.Int16)
        ExecutionList.Add((FnObject) new FnConstant<short>(short.Parse(s)));
      else if (profiles[startIndex] == FunctalCompiler.FnObjectProfiles.UInt16)
        ExecutionList.Add((FnObject) new FnConstant<ushort>(ushort.Parse(s)));
      else if (profiles[startIndex] == FunctalCompiler.FnObjectProfiles.Int32)
        ExecutionList.Add((FnObject) new FnConstant<int>(int.Parse(s)));
      else if (profiles[startIndex] == FunctalCompiler.FnObjectProfiles.UInt32)
        ExecutionList.Add((FnObject) new FnConstant<uint>(uint.Parse(s)));
      else if (profiles[startIndex] == FunctalCompiler.FnObjectProfiles.Int64)
        ExecutionList.Add((FnObject) new FnConstant<long>(long.Parse(s)));
      else if (profiles[startIndex] == FunctalCompiler.FnObjectProfiles.UInt64)
        ExecutionList.Add((FnObject) new FnConstant<ulong>(ulong.Parse(s)));
      else if (profiles[startIndex] == FunctalCompiler.FnObjectProfiles.Single)
        ExecutionList.Add((FnObject) new FnConstant<float>(float.Parse(s)));
      else if (profiles[startIndex] == FunctalCompiler.FnObjectProfiles.Double)
        ExecutionList.Add((FnObject) new FnConstant<double>(double.Parse(s)));
      else if (profiles[startIndex] == FunctalCompiler.FnObjectProfiles.StringBody)
      {
        ExecutionList.Add((FnObject) new FnConstant<string>(s));
      }
      else
      {
        if (profiles[startIndex] != FunctalCompiler.FnObjectProfiles.CharBody)
          throw new ArgumentException("The data type you have specified isn't a number");
        ExecutionList.Add((FnObject) new FnConstant<char>(Convert.ToChar(s)));
      }
      IsBound.Add(false);
    }

    private void AddParameterInstanceToExecutionTree(
      string expression,
      List<FunctalCompiler.FnObjectProfiles> profiles,
      ref Dictionary<string, FnObject> parameters,
      ref List<FnObject> executionList,
      ref List<bool> isBound,
      ref int index)
    {
      int startIndex = index;
      while (index < profiles.Count && profiles[index] == FunctalCompiler.FnObjectProfiles.ParameterBody)
        ++index;
      int num = index;
      --index;
      this.AddParameterToExecutionTree(expression.Substring(startIndex, num - startIndex), ref parameters, ref executionList);
      isBound.Add(false);
    }

    private void AddConstantToExecutionTree(
      string expression,
      List<FunctalCompiler.FnObjectProfiles> profiles,
      ref List<FnObject> ExecutionList,
      ref List<bool> IsBound,
      ref int index)
    {
      int startIndex = index;
      while (index < profiles.Count && profiles[index] == FunctalCompiler.FnObjectProfiles.Constant)
        ++index;
      int num = index;
      --index;
      string name = expression.Substring(startIndex, num - startIndex);
      ExecutionList.Add(FunctalResources.GetConstant(name));
      IsBound.Add(false);
    }

    private void AddFunctionToExecutionTree(
      string expression,
      List<FunctalCompiler.FnObjectProfiles> profiles,
      ref Dictionary<string, FnObject> parameters,
      ref List<FnObject> executionList,
      ref List<bool> isBound,
      ref int index,
      FnVariable<bool> isImmutableExecute)
    {
      int startIndex1 = index;
      List<FnObject> arguments1 = new List<FnObject>();
      while (index < profiles.Count && profiles[index] == FunctalCompiler.FnObjectProfiles.FunctionName)
        ++index;
      int num1 = index;
      string index1 = expression.Substring(startIndex1, num1 - startIndex1);
      int num2 = 0;
      int startIndex2 = num1 + 1;
      while (true)
      {
        if (profiles[index] == FunctalCompiler.FnObjectProfiles.StartGrouping)
          ++num2;
        else if (profiles[index] == FunctalCompiler.FnObjectProfiles.EndGrouping)
          --num2;
        if (profiles[index] == FunctalCompiler.FnObjectProfiles.DivisionGrouping && num2 == 1 || num2 == 0)
        {
          int num3 = index;
          if (num3 - startIndex2 > 0)
          {
            List<FunctalCompiler.FnObjectProfiles> characterProfiles = new List<FunctalCompiler.FnObjectProfiles>(num3 - startIndex2);
            for (int index2 = startIndex2; index2 < num3; ++index2)
              characterProfiles.Add(profiles[index2]);
            this.ConvertToExecutionTree(expression.Substring(startIndex2, num3 - startIndex2), characterProfiles, ref parameters, ref executionList, ref isBound, isImmutableExecute);
            arguments1.Add(executionList.Last<FnObject>());
            isBound[isBound.Count - 1] = true;
          }
          startIndex2 = num3 + 1;
        }
        if (num2 != 0)
          ++index;
        else
          break;
      }
      if (index1 == "if")
      {
        Type wrappedObjectType1 = arguments1[1].GetWrappedObjectType();
        Type wrappedObjectType2 = arguments1[2].GetWrappedObjectType();
        int num3 = FunctalResources.TypePrecedence.ContainsKey(wrappedObjectType1) ? 1 : 0;
        bool flag = FunctalResources.TypePrecedence.ContainsKey(wrappedObjectType2);
        if (num3 == 0 && !flag)
        {
          if (!wrappedObjectType1.Equals(wrappedObjectType2))
            throw new ArgumentException("The true and false code paths of an if statement must either be the same type, or an implicit conversion must exist between the two types.", expression);
        }
        else if ((int) FunctalResources.TypePrecedence[arguments1[1].GetWrappedObjectType()] > (int) FunctalResources.TypePrecedence[arguments1[2].GetWrappedObjectType()])
        {
          if (!FunctalResources.ImplicitConversionSwitches.ContainsKey(arguments1[1].GetWrappedObjectType()))
            throw new ArgumentException("The true and false code paths of an if statement must either be the same type, or an implicit conversion must exist between the two types.", expression);
          List<FnObject> fnObjectList = executionList;
          FnFunctionGroup conversionSwitch = FunctalResources.ImplicitConversionSwitches[arguments1[1].GetWrappedObjectType()];
          List<FnObject> arguments2 = new List<FnObject>();
          arguments2.Add(arguments1[2]);
          Dictionary<string, FnObject> parameters1 = parameters;
          FnVariable<bool> isPreExecute = isImmutableExecute;
          FnObject objectWithPointer = conversionSwitch.CreateObjectWithPointer(arguments2, parameters1, isPreExecute);
          fnObjectList.Add(objectWithPointer);
          isBound[isBound.Count - 1] = true;
          isBound.Add(false);
          arguments1[2] = executionList.Last<FnObject>();
        }
        else if ((int) FunctalResources.TypePrecedence[arguments1[2].GetWrappedObjectType()] > (int) FunctalResources.TypePrecedence[arguments1[1].GetWrappedObjectType()])
        {
          if (!FunctalResources.ImplicitConversionSwitches.ContainsKey(arguments1[2].GetWrappedObjectType()))
            throw new ArgumentException("The true and false code paths of an if statement must either be the same type, or an implicit conversion must exist between the two types.", expression);
          List<FnObject> fnObjectList = executionList;
          FnFunctionGroup conversionSwitch = FunctalResources.ImplicitConversionSwitches[arguments1[2].GetWrappedObjectType()];
          List<FnObject> arguments2 = new List<FnObject>();
          arguments2.Add(arguments1[1]);
          Dictionary<string, FnObject> parameters1 = parameters;
          FnVariable<bool> isPreExecute = isImmutableExecute;
          FnObject objectWithPointer = conversionSwitch.CreateObjectWithPointer(arguments2, parameters1, isPreExecute);
          fnObjectList.Add(objectWithPointer);
          isBound[isBound.Count - 1] = true;
          isBound.Add(false);
          arguments1[1] = executionList.Last<FnObject>();
        }
        executionList.Add(arguments1[1].CreateFnIfWithSameType(arguments1[0] as FnObject<bool>, arguments1[1], arguments1[2]));
        isBound.Add(false);
      }
      else
      {
        executionList.Add(FunctalResources.FnFunctions[index1].CreateObjectWithPointer(arguments1, parameters, isImmutableExecute));
        isBound.Add(false);
      }
    }

    private void AddParameterToExecutionTree(
      string parameterName,
      ref Dictionary<string, FnObject> parameters,
      ref List<FnObject> executionList)
    {
      if (!parameters.ContainsKey(parameterName))
        throw new ArgumentException("the specified parameter does not exist");
      executionList.Add(parameters[parameterName]);
    }

    private int GetOperatorPrecedence(
      string operatorName,
      FunctalCompiler.FnObjectProfiles operatorProfile)
    {
      switch (operatorProfile)
      {
        case FunctalCompiler.FnObjectProfiles.BinaryOperator:
          return this.BinaryOperatorPrecedence[operatorName];
        case FunctalCompiler.FnObjectProfiles.UnaryPrefixOperator:
          return this.UnaryPrefixOperatorPrecedence[operatorName];
        case FunctalCompiler.FnObjectProfiles.UnarySuffixOperator:
          return this.UnarySuffixOperatorPrecedence[operatorName];
        default:
          if (operatorName == "(")
            return -1;
          int num = operatorName == ")" ? 1 : 0;
          return -1;
      }
    }

    private FnObject GetOperatorFunction(
      string operatorString,
      FunctalCompiler.FnObjectProfiles operatorProfile,
      List<FnObject> operands,
      Dictionary<string, FnObject> parameters,
      FnVariable<bool> isPreExecute)
    {
      if (operatorProfile == FunctalCompiler.FnObjectProfiles.UnaryPrefixOperator)
      {
        if (operatorString == "+")
          return FunctalResources.FnFunctions["Positive"].CreateObjectWithPointer(operands, parameters, isPreExecute);
        if (operatorString == "-")
          return FunctalResources.FnFunctions["Negative"].CreateObjectWithPointer(operands, parameters, isPreExecute);
        if (operatorString == "!")
          return FunctalResources.FnFunctions["Not"].CreateObjectWithPointer(operands, parameters, isPreExecute);
      }
      else if (operatorProfile != FunctalCompiler.FnObjectProfiles.UnarySuffixOperator && operatorProfile == FunctalCompiler.FnObjectProfiles.BinaryOperator)
      {
        if (operatorString == "+")
          return FunctalResources.FnFunctions["Add"].CreateObjectWithPointer(operands, parameters, isPreExecute);
        if (operatorString == "-")
          return FunctalResources.FnFunctions["Subtract"].CreateObjectWithPointer(operands, parameters, isPreExecute);
        if (operatorString == "*")
          return FunctalResources.FnFunctions["Multiply"].CreateObjectWithPointer(operands, parameters, isPreExecute);
        if (operatorString == "/")
          return FunctalResources.FnFunctions["Divide"].CreateObjectWithPointer(operands, parameters, isPreExecute);
        if (operatorString == "%")
          return FunctalResources.FnFunctions["Mod"].CreateObjectWithPointer(operands, parameters, isPreExecute);
        if (operatorString == ">")
          return FunctalResources.FnFunctions["IsGreaterThan"].CreateObjectWithPointer(operands, parameters, isPreExecute);
        if (operatorString == ">=")
          return FunctalResources.FnFunctions["IsGreaterThanOrEqual"].CreateObjectWithPointer(operands, parameters, isPreExecute);
        if (operatorString == "<")
          return FunctalResources.FnFunctions["IsLessThan"].CreateObjectWithPointer(operands, parameters, isPreExecute);
        if (operatorString == "<=")
          return FunctalResources.FnFunctions["IsLessThanOrEqual"].CreateObjectWithPointer(operands, parameters, isPreExecute);
        if (operatorString == "==")
          return FunctalResources.FnFunctions["IsEqual"].CreateObjectWithPointer(operands, parameters, isPreExecute);
        if (operatorString == "!=")
          return FunctalResources.FnFunctions["IsNotEqual"].CreateObjectWithPointer(operands, parameters, isPreExecute);
        if (operatorString == "&&")
          return FunctalResources.FnFunctions["And"].CreateObjectWithPointer(operands, parameters, isPreExecute);
        if (operatorString == "!&&")
          return FunctalResources.FnFunctions["Nand"].CreateObjectWithPointer(operands, parameters, isPreExecute);
        if (operatorString == "||")
          return FunctalResources.FnFunctions["Or"].CreateObjectWithPointer(operands, parameters, isPreExecute);
        if (operatorString == "!||")
          return FunctalResources.FnFunctions["Nor"].CreateObjectWithPointer(operands, parameters, isPreExecute);
        if (operatorString == "^")
          return FunctalResources.FnFunctions["Xor"].CreateObjectWithPointer(operands, parameters, isPreExecute);
      }
      throw new ArgumentException("This operator is not supported", operatorString);
    }

    private int GetNextUnBoundIndex(ref List<bool> IsBound)
    {
      int index = IsBound.Count - 1;
      while (index >= 0 && IsBound[index])
        --index;
      return index;
    }

    private enum FnObjectProfiles
    {
      Constant,
      ParameterBody,
      StringBody,
      CharBody,
      Number,
      NumericSuffix,
      SByte,
      Byte,
      Int16,
      UInt16,
      Int32,
      UInt32,
      Int64,
      UInt64,
      Single,
      Double,
      Operator,
      BinaryOperator,
      UnaryPrefixOperator,
      UnarySuffixOperator,
      Name,
      FunctionName,
      StartGrouping,
      EndGrouping,
      DivisionGrouping,
      Unassessed,
    }
  }
}
