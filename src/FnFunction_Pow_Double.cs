﻿// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_Pow_Double
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

using System;

namespace Functal
{
  internal class FnFunction_Pow_Double : FnFunction<double>
  {
    [FnArg]
    protected FnObject<double> Num;
    [FnArg]
    protected FnObject<double> Pow;

    public override double GetValue()
    {
      return Math.Pow(this.Num.GetValue(), this.Pow.GetValue());
    }
  }
}
