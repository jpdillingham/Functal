﻿// Decompiled with JetBrains decompiler
// Type: Functal.FnFunction_Negative_Int32
// Assembly: Functal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47DC2DAE-D56F-4FC5-A0C3-CC69F2DF9A1F
// Assembly location: \\WSE\Folder Redirection\JP\Downloads\Functal-1_0_0\Functal.dll

namespace Functal
{
  internal class FnFunction_Negative_Int32 : FnFunction<int>
  {
    [FnArg]
    protected FnObject<int> Num;

    public override int GetValue()
    {
      return -this.Num.GetValue();
    }
  }
}
