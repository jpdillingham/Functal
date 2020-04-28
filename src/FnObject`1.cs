// Decompiled with JetBrains decompiler
// Type: Functal.FnObject`1
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

using System;

namespace Functal
{
  public abstract class FnObject<T> : FnObject
  {
    public abstract T GetValue();

    public override Type GetWrappedObjectType()
    {
      return typeof (T);
    }

    internal override FnObject CreateFnVariableWithSameType()
    {
      return (FnObject) new FnVariable<T>(default (T));
    }

    internal override FnObject CreateFnIfWithSameType(
      FnObject<bool> condition,
      FnObject trueArg,
      FnObject falseArg)
    {
      return (FnObject) new FnIf<T>(condition, trueArg, falseArg);
    }
  }
}
