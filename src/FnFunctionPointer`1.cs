// Decompiled with JetBrains decompiler
// Type: Functal.FnFunctionPointer`1
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

using System;
using System.Collections.Generic;

namespace Functal
{
  internal class FnFunctionPointer<T> : FnFunctionPointer
  {
    public readonly FnFunction<T> Target;

    public FnFunctionPointer(FnFunction<T> target)
    {
      this.Target = target;
    }

    public Type GetTypeOfObject()
    {
      return typeof (T);
    }

    public FnObject CreateObjectWithPointer(
      List<FnObject> functionParameters,
      Dictionary<string, FnObject> parameters,
      FnVariable<bool> isImmutableExecute)
    {
      return this.Target.CreateNewFunction(functionParameters, parameters, isImmutableExecute);
    }

    public Type[] GetFunctionTypeArray()
    {
      return this.Target.ArgumentTypes;
    }
  }
}
