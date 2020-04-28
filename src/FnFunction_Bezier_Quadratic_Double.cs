﻿// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_Bezier_Quadratic_Double
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  internal class FnFunction_Bezier_Quadratic_Double : FnFunction<double>
  {
    [FnArg]
    protected FnObject<double> P0;
    [FnArg]
    protected FnObject<double> P1;
    [FnArg]
    protected FnObject<double> P2;
    [FnArg]
    protected FnObject<double> S;

    public override double GetValue()
    {
      double num1 = this.P0.GetValue();
      double num2 = this.P1.GetValue();
      double num3 = this.P2.GetValue();
      double num4 = this.S.GetValue();
      return (1.0 - num4) * (1.0 - num4) * num1 + 2.0 * (1.0 - num4) * num4 * num2 + num4 * num4 * num3;
    }
  }
}
