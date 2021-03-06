﻿// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_Bezier_Quadratic_Single
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  internal class FnFunction_Bezier_Quadratic_Single : FnFunction<float>
  {
    [FnArg]
    protected FnObject<float> P0;
    [FnArg]
    protected FnObject<float> P1;
    [FnArg]
    protected FnObject<float> P2;
    [FnArg]
    protected FnObject<float> S;

    public override float GetValue()
    {
      float num1 = this.P0.GetValue();
      float num2 = this.P1.GetValue();
      float num3 = this.P2.GetValue();
      float num4 = this.S.GetValue();
      return (float) ((1.0 - (double) num4) * (1.0 - (double) num4) * (double) num1 + 2.0 * (1.0 - (double) num4) * (double) num4 * (double) num2 + (double) num4 * (double) num4 * (double) num3);
    }
  }
}
