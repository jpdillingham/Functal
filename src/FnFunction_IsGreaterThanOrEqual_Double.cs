﻿// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_IsGreaterThanOrEqual_Double
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  internal class FnFunction_IsGreaterThanOrEqual_Double : FnFunction<bool>
  {
    [FnArg]
    protected FnObject<double> LeftVal;
    [FnArg]
    protected FnObject<double> RightVal;

    public override bool GetValue()
    {
      return this.LeftVal.GetValue() >= this.RightVal.GetValue();
    }
  }
}
