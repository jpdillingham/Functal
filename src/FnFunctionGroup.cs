// Decompiled with JetBrains decompiler
// Type: Functal.FnFunctionGroup
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

using System;
using System.Collections.Generic;

namespace Functal
{
  internal class FnFunctionGroup
  {
    public readonly string Name;
    public List<FnFunctionPointer> FunctionPointers;

    public FnFunctionGroup(string name)
    {
      this.FunctionPointers = new List<FnFunctionPointer>();
      this.Name = name;
    }

    public void AddFunctionPointer(FnFunctionPointer functionpointer)
    {
      Type[] functionTypeArray1 = functionpointer.GetFunctionTypeArray();
      for (int index1 = 0; index1 < this.FunctionPointers.Count; ++index1)
      {
        Type[] functionTypeArray2 = this.FunctionPointers[index1].GetFunctionTypeArray();
        if (functionTypeArray2.Length == functionTypeArray1.Length)
        {
          for (int index2 = 0; index2 < functionTypeArray2.Length && !(functionTypeArray2[index2] != functionTypeArray1[index2]); ++index2)
          {
            if (index2 == functionTypeArray2.Length - 1)
              throw new ArgumentException("The Argument types you have submitted have been previously entered for another overload", "Conflicting overload data: " + functionTypeArray1.ToString());
          }
        }
      }
      this.FunctionPointers.Add(functionpointer);
    }

    public FnObject CreateObjectWithPointer(
      List<FnObject> arguments,
      Dictionary<string, FnObject> parameters,
      FnVariable<bool> isPreExecute)
    {
      for (int index1 = 0; index1 < this.FunctionPointers.Count; ++index1)
      {
        Type[] functionTypeArray = this.FunctionPointers[index1].GetFunctionTypeArray();
        if (functionTypeArray.Length == arguments.Count)
        {
          for (int index2 = 0; index2 < functionTypeArray.Length && !(functionTypeArray[index2] != arguments[index2].GetWrappedObjectType()); ++index2)
          {
            if (index2 == functionTypeArray.Length - 1)
              return this.FunctionPointers[index1].CreateObjectWithPointer(arguments, parameters, isPreExecute);
          }
        }
      }
      List<int> intList = new List<int>(this.FunctionPointers.Count);
      for (int index1 = 0; index1 < this.FunctionPointers.Count; ++index1)
      {
        Type[] functionTypeArray = this.FunctionPointers[index1].GetFunctionTypeArray();
        if (functionTypeArray.Length == arguments.Count)
        {
          intList.Add(0);
          for (int index2 = 0; index2 < functionTypeArray.Length; ++index2)
          {
            if (functionTypeArray[index2] != arguments[index2].GetWrappedObjectType())
            {
              int ambiguityScore = FunctalResources.GetAmbiguityScore(functionTypeArray[index2], arguments[index2].GetWrappedObjectType());
              if (ambiguityScore <= 0)
              {
                intList[index1] = -1;
                break;
              }
              intList[index1] += ambiguityScore;
            }
          }
        }
        else
          intList.Add(-1);
      }
      int index3 = -1;
      int num = 1;
      for (int index1 = 0; index1 < intList.Count; ++index1)
      {
        if (intList[index1] >= 0)
        {
          if (index3 == -1)
            index3 = index1;
          else if (intList[index1] < intList[index3])
          {
            index3 = index1;
            num = 1;
          }
          else if (intList[index1] == intList[index3])
            ++num;
        }
      }
      if (index3 >= 0 && num == 1)
      {
        for (int index1 = 0; index1 < arguments.Count; ++index1)
        {
          if (this.FunctionPointers[index3].GetFunctionTypeArray()[index1] != arguments[index1].GetWrappedObjectType())
          {
            List<FnObject> fnObjectList = arguments;
            int index2 = index1;
            FnFunctionGroup conversionSwitch = FunctalResources.ImplicitConversionSwitches[this.FunctionPointers[index3].GetFunctionTypeArray()[index1]];
            List<FnObject> arguments1 = new List<FnObject>();
            arguments1.Add(arguments[index1]);
            Dictionary<string, FnObject> parameters1 = parameters;
            FnVariable<bool> isPreExecute1 = isPreExecute;
            FnObject objectWithPointer = conversionSwitch.CreateObjectWithPointer(arguments1, parameters1, isPreExecute1);
            fnObjectList[index2] = objectWithPointer;
          }
        }
        return this.FunctionPointers[index3].CreateObjectWithPointer(arguments, parameters, isPreExecute);
      }
      if (index3 >= 0 && num > 1)
        throw new ArgumentException("The function call is too ambiguous to resolve, use more specific argument types", arguments.ToString());
      throw new ArgumentException("The function has no overloads which match the specified arguments", arguments.ToString());
    }
  }
}
