// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_Min_Decimal
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

using System;

namespace Functal
{
  internal class FnFunction_Min_Decimal : FnFunction<Decimal>
  {
    [FnArg]
    protected FnObject<Decimal> Param0;
    [FnArg]
    protected FnObject<Decimal> Param1;

    public override Decimal GetValue()
    {
      return Math.Min(this.Param0.GetValue(), this.Param1.GetValue());
    }
  }
}
