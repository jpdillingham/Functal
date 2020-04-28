// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_Pow_UInt64
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

using System;

namespace Functal
{
  internal class FnFunction_Pow_UInt64 : FnFunction<ulong>
  {
    [FnArg]
    protected FnObject<ulong> Num;
    [FnArg]
    protected FnObject<ulong> Pow;

    public override ulong GetValue()
    {
      return (ulong) Math.Pow((double) this.Num.GetValue(), (double) this.Pow.GetValue());
    }
  }
}
