// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_Cast_ToSByte_FromDecimal
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

using System;

namespace Functal
{
  internal class FnFunction_Cast_ToSByte_FromDecimal : FnFunction<sbyte>
  {
    [FnArg]
    protected FnObject<Decimal> Value;

    public override sbyte GetValue()
    {
      return (sbyte) this.Value.GetValue();
    }
  }
}
